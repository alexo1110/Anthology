namespace Anthology.Models
{
    public static class ActionManager
    {
        /** Actions available in the simulation */
        public static HashSet<Action> Actions { get; set; } = new HashSet<Action>();

        /** The "wait_action", which is defaulted to when no other suitable action can be performed by an agent */
        public static Action WaitAction { get; private set; } = new PrimaryAction();

        /** The "travel_action", which is used to denote that an agent is currently traveling to a destination */
        public static Action TravelAction { get; private set; } = new PrimaryAction();

        /** Initialize/reset all action manager variables */
        public static void Init()
        {
            Actions.Clear();
            WaitAction.Name = "wait_action";
            TravelAction.Name = "travel_action";
        }

        /** Retrieves an action with the specified name from the set of actions available in the simulation */
        public static Action? GetActionByName(string actionName)
        {
            bool HasName(Action action)
            {
                return action.Name == actionName;
            }
            Action a = Actions.Where(HasName).First();
            if (a != null) { return a; }
            else { return null; }
        }

        /**
         * Returns the net effect for an action for a specific agent
         * Takes into account the agent's current motivation statuses
         */
        public static float GetEffectDeltaForAgentAction(Agent agent, Action action)
        {
            float deltaUtility = 0f;

            if (action is PrimaryAction pAction)
            {
                foreach (Effect e in pAction.Effects)
                {
                    float delta = e.Delta;
                    float current = agent.Motives[e.Type].Amount;
                    deltaUtility += Math.Clamp(delta + current, Motive.MIN, Motive.MAX) - current;
                }
                return deltaUtility;
            }
            else if (action is ScheduleAction sAction)
            {
                return GetEffectDeltaForAgentAction(agent, sAction.InstigatorAction);
            }

            return deltaUtility;
        }
    }
}
