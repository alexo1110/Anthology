namespace Anthology.Models
{
    /**
 * Relationship class
 * Relationships are composed by agents, so the owning agent will always be the source of the relationship.
 * eg. an agent that has the 'brother' relationship with Norma is Norma's brother
 */
    public class Relationship
    {
        /** The type of relationship, eg. 'student' or 'teacher' */
        public string Type { get; set; } = string.Empty;

        /** The agent that this relationship is with */
        public Agent With { get; set; } = new Agent();

        /** How strong the relationship is */
        public float Valence { get; set; }
    }

    /**
     * Agent class
     * Describes the agent object or NPCs in the simulation 
     */
    public class Agent
    {
        /** Name of the agent */
        public string Name { get; set; } = string.Empty;

        /** Container of all the motive properties of this agent */
        public Dictionary<MotiveEnum, Motive> Motives { get; set; } = new Dictionary<MotiveEnum, Motive>()
                                                                      {
                                                                        { MotiveEnum.ACCOMPLISHMENT, new MAccomplishment() },
                                                                        { MotiveEnum.EMOTIONAL, new MEmotional() },
                                                                        { MotiveEnum.FINANCIAL, new MFinancial() },
                                                                        { MotiveEnum.SOCIAL, new MSocial() },
                                                                        { MotiveEnum.PHYSICAL, new MPhysical() } 
                                                                      };

        /** Set of all the relationships of this agent */
        public HashSet<Relationship> Relationships { get; set; } = new HashSet<Relationship>();

        /** Current location of the agent */
        public SimLocation CurrentLocation { get; set; } = new SimLocation();

        /** How long the agent will be occupied with the current action they are executing */
        public int OccupiedCounter { get; set; }

        /** A queue containing the next few actions being executed by the agent */
        public LinkedList<Action> CurrentAction { get; set; } = new LinkedList<Action>();

        /**
         * The destination that the agent is heading to
         * Can be null if the agent has reached their previous destination and is 
         * executing an action at that location.
         */
        public SimLocation? Destination { get; set; }

        /** List of targets for the agent's current action */
        public HashSet<Agent> CurrentTargets { get; set; } = new HashSet<Agent>();

        /** Actual current X and Y coordinates, used for traveling */
        private int CurrentX { get; set; }
        private int CurrentY { get; set; }

        /** Starts travel to the agent's destination */
        public void StartTravelToLocation(SimLocation destination, float time)
        {
            Destination = destination;
            CurrentX = CurrentLocation.X;
            CurrentY = CurrentLocation.Y;
            OccupiedCounter = LocationManager.FindManhattanDistance(CurrentLocation, Destination);
            Console.WriteLine("time: " + time.ToString() + " | " + Name + ": Started " + CurrentAction.First().Name + "; Destination: " + Destination.Name);
        }

        /**
         * Move closer to the agent's destination
         * Uses the manhattan distance to move the agent, so either moves along the x or y axis during any tick 
         */
        public void MoveCloserToDestination()
        {
            if (Destination == null) return;
            
            if (CurrentX != Destination.X)
            {
                CurrentX += CurrentX > Destination.X ? -1 : 1;
            }
            else if (CurrentY != Destination.Y)
            {
                CurrentY += CurrentY > Destination.Y ? -1 : 1;
            }
        }

        /** Applies the effect of an action to this agent */
        public void ExecuteAction()
        {
            Destination = null;
            OccupiedCounter = 0;

            if (CurrentAction.Count > 0)
            {
                Action action = CurrentAction.First();
                CurrentAction.RemoveFirst();

                if (action is PrimaryAction pAction)
                {
                    foreach (Effect e in pAction.Effects)
                    {
                        float delta = e.Delta;
                        float current = Motives[e.Type].Amount;
                        Motives[e.Type].Amount = Math.Clamp(delta + current, Motive.MIN, Motive.MAX);
                    }
                    Console.WriteLine("time: " + World.Time.ToString() + " | " + Name + ": Finished " + action.Name);
                }
                else if (action is ScheduleAction sAction)
                {
                    if (sAction.Interrupt)
                    {
                        CurrentAction.AddFirst(sAction.InstigatorAction);
                    }
                    else
                    {
                        CurrentAction.AddLast(sAction.InstigatorAction);
                    }
                    foreach(Agent target in CurrentTargets)
                    {
                        if (sAction.Interrupt)
                        {
                            target.CurrentAction.AddFirst(sAction.TargetAction);
                        }
                        else
                        {
                            target.CurrentAction.AddLast(sAction.TargetAction);
                        }
                        Console.WriteLine("time: " + World.Time.ToString() + " | " + target.Name + ": Affected by " + sAction.TargetAction.Name);
                    }
                }
            }
        }

        /**
         * Starts an action (if the agent is at a location where the action can be performed)
         * else makes the agent travel to a suitable location to perform the action
         */
        public void StartAction()
        {
            Action action = CurrentAction.First();
            OccupiedCounter = action.MinTime;
            
            if (action is ScheduleAction)
            {
                CurrentTargets.Clear();
                CurrentTargets.UnionWith(CurrentLocation.AgentsPresent);
            }
            Console.WriteLine("time: " + World.Time.ToString() + " | " + Name + ": Started " + action.Name);
        }

        /**
         * Selects an action from a set of valid actions to be performed by this agent.
         * Selects the action with the maximal utility of the agent (motive increase / time).
         */
        public void SelectNextAction()
        {
            float maxDeltaUtility = 0f;
            List<Action> currentChoice = new() { ActionManager.WaitAction };
            List<SimLocation> currentDest = new();
            List<string> actionSelectLog = new();

            foreach(Action action in ActionManager.Actions)
            {
                if (action.Hidden) continue;
                actionSelectLog.Add("Action: " + action.Name);

                int travelTime = 0;
                HashSet<SimLocation> possibleLocations = new();
                possibleLocations.UnionWith(LocationManager.SimLocations);

                HashSet<Requirement> rMotives = action.GetRequirementsByType(ReqEnum.MOTIVE);
                HashSet<Requirement> rLocations = action.GetRequirementsByType(ReqEnum.LOCATION);
                HashSet<Requirement> rPeople = action.GetRequirementsByType(ReqEnum.PEOPLE);

                if(possibleLocations.Count > 0 && rMotives.Count > 0)
                {
                    if (!AgentManager.AgentSatisfiesMotiveRequirement(this, rMotives))
                    {
                        possibleLocations.Clear();
                    }
                }
                if (possibleLocations.Count > 0 && rLocations.Count > 0)
                {
                    if (rLocations.First() is RLocation rLoc)
                    {
                        possibleLocations = LocationManager.LocationsSatisfyingLocationRequirement(possibleLocations, rLoc);
                    }
                }
                if (possibleLocations.Count > 0 && rPeople.Count > 0)
                {
                    if (rPeople.First() is RPeople rPpl)
                    {
                        possibleLocations = LocationManager.LocationsSatisfyingPeopleRequirement(possibleLocations, rPpl);
                    }
                }

                if (possibleLocations.Count > 0)
                {
                    SimLocation? nearestLocation = LocationManager.FindNearestLocationFrom(possibleLocations, this);
                    if (nearestLocation == null) continue;
                    travelTime = LocationManager.FindManhattanDistance(nearestLocation, CurrentLocation);
                    float deltaUtility = ActionManager.GetEffectDeltaForAgentAction(this, action);
                    actionSelectLog.Add("Action Utility: " + deltaUtility.ToString());
                    deltaUtility /= (action.MinTime + travelTime);
                    actionSelectLog.Add("Action Weighted Utility: " + deltaUtility.ToString());

                    if (deltaUtility == maxDeltaUtility)
                    {
                        currentChoice.Add(action);
                        currentDest.Add(nearestLocation);
                    }
                    else if (deltaUtility > maxDeltaUtility)
                    {
                        currentChoice.Clear();
                        currentDest.Clear();
                        currentChoice.Add(action);
                        currentDest.Add(nearestLocation);
                    }

                    actionSelectLog.Add("Current Choice: " + currentChoice.First().Name);
                    actionSelectLog.Add("Current Destination: " + currentDest.First().Name);
                }
            }

            Random r = new();
            int idx = r.Next(0, currentChoice.Count);
            Action choice = currentChoice[idx];
            SimLocation dest = currentDest[idx];
            CurrentAction.AddLast(choice);
            
            if (dest != null && dest != CurrentLocation)
            {
                CurrentAction.AddFirst(ActionManager.TravelAction);
                StartTravelToLocation(dest, World.Time);
            }
            else if (dest == null || dest == CurrentLocation)
            {
                StartAction();
            }
        }

        /** Returns whether the agent is content, ie. checks to see if an agent has the maximum motives */
        public bool IsContent()
        {
            foreach (Motive m in Motives.Values)
            {
                if (m.Amount < Motive.MAX) return false;
            }
            return true;
        }

        /** Decrements all the motives of this agent */
        public void DecrementMotives()
        {
            foreach (Motive m in Motives.Values)
            {
                m.Amount = Math.Clamp(m.Amount - 1, Motive.MIN, Motive.MAX);
            }
        }
    }

    /**
     * Agent class received from a JSON file
     * The action is provided as a string and matched to the Agent.CurrentAction object accordingly
     */
    public class SerializableAgent
    {
        /** initializedd to the name of the agent */
        public string Name { get; set; } = string.Empty;

        /** motives intiailized with values for the agent */
        public Dictionary<MotiveEnum, Motive> Motives { get; set; } = new Dictionary<MotiveEnum, Motive>()
                                                                      {
                                                                        { MotiveEnum.ACCOMPLISHMENT, new MAccomplishment() },
                                                                        { MotiveEnum.EMOTIONAL, new MEmotional() },
                                                                        { MotiveEnum.FINANCIAL, new MFinancial() },
                                                                        { MotiveEnum.SOCIAL, new MSocial() },
                                                                        { MotiveEnum.PHYSICAL, new MPhysical() }
                                                                      };

        /** starting location initialized for the agent */
        public SimLocation CurrentLocation { get; set; } = new SimLocation();

        /** describes whether the agent is currently occupied */
        public int OccupiedCounter { get; set; }

        /** queue containing the next few actions being executed by the agent */
        public Queue<string> CurrentAction { get; set; } = new Queue<string>();

        /** Location the agent is currently headed to */
        public SimLocation Destination { get; set; } = new SimLocation();

        /** list of targets for the agent's current action */
        public List<Agent> CurrentTargets { get; set; } = new List<Agent>();
    }
}
