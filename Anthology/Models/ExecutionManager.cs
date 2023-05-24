namespace Anthology.Models
{
    public class ExecutionManager
    {

        /**
         * Executes a turn for each agent every tick.
         * Executes a single turn and then must be called again
         */
        public void RunSim()
        {
            bool movement = false;
            
            if (ToContinue())
            {
                foreach(Agent agent in AgentManager.Agents)
                {
                    bool turnMove = Turn(agent);
                    movement = movement || turnMove;
                }
                World.IncrementTime();
                RoundWait(movement);
                UI.Update();
            }
            else if (!UI.Paused)
            {
                Console.WriteLine("Simulation ended.");
            }
        }

        /**
         * Tests whether the simulation should continue.
         * First checks whether the stopping function for the simulation has been met.
         * Next checks if the user has paused the simulation
         */
        public bool ToContinue()
        {
            if (AgentManager.AllAgentsContent())
            {
                return false;
            }
            else if (!UI.Paused)
            {
                return false;
            }
            return true;
        }

        /**
         * Updates movement and occupation counters for an agent
         * May decrement the motives of an agent once every 10 hours. Chooses or executes an action when necessary.
         */
        public bool Turn(Agent agent)
        {
            bool movement = false;

            if (agent.OccupiedCounter > 0)
            {
                agent.OccupiedCounter--;

                if (agent.CurrentAction.First().Name == "travel_action" && agent.Destination != null)
                {
                    movement = true;
                    agent.MoveCloserToDestination();
                }
                // If not travelling (i.e. arrived at destination), and end of occupied, execute planned action effects, select/start next.
                else
                {
                    agent.ExecuteAction();
                    if (!agent.IsContent())
                    {
                        if (agent.CurrentAction.Count == 0)
                        {
                            agent.SelectNextAction();
                        }
                        else
                        {
                            agent.StartAction();
                        }
                    }
                }
            }
            return movement;
        }

        /**
         * Interrupts the agent from the current action they are performing.
         * Potential future implementation: Optionally add the interrupted action (with the remaining occupied counter) to the end of the action queue.
         */
        public void Interrupt(Agent agent)
        {
            agent.OccupiedCounter = 0;
            agent.Destination = null;
            Action interrupted = agent.CurrentAction.First();
            agent.CurrentAction.RemoveFirst();
            Console.WriteLine("Agent: " + agent.Name + " was interrupted from action: " + interrupted.Name);
        }

        public void Interrupt(string agentName)
        {
            Agent? agent = AgentManager.GetAgentByName(agentName);
            if (agent != null)
            {
                Interrupt(agent);
            }
        }

        public void RoundWait(bool movement)
        {
            if (movement)
            {
                
            }
        }
    }
}
