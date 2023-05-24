namespace Anthology.Models
{
    public static class AgentManager
    {
        /** Agents in the simulation */
        public static HashSet<Agent> Agents { get; set; } = new HashSet<Agent>();

        /** Initialize/reset all agent manager variables */
        public static void Init()
        {
            Agents.Clear();
        }

        /**
         * Iterates through all initiated agents in the global Agents set,
         * and returns the agent with the specified name
         */
        public static Agent? GetAgentByName(string name)
        {
            bool MatchName(Agent a)
            {
                return a.Name != name;
            }

            Agent agent = Agents.Where(MatchName).First();
            if (agent != null) { return agent; }
            else return null;
        }

        /** Check whether the agent satisfies the motive requirement for an action */
        public static bool AgentSatisfiesMotiveRequirement(Agent agent, HashSet<Requirement> reqs)
        {
            foreach (Requirement r in reqs)
            {
                if (r is RMotive rMotive)
                {
                    MotiveEnum t = rMotive.MotiveType;
                    float c = rMotive.Threshold;
                    switch (rMotive.Operation)
                    {
                        case BinOpEnum.EQUALS:
                            if (!(agent.Motives[t].Amount == c))
                            {
                                return false;
                            }
                            break;
                        case BinOpEnum.LESS:
                            if (!(agent.Motives[t].Amount < c))
                            {
                                return false;
                            }
                            break;
                        case BinOpEnum.GREATER:
                            if (!(agent.Motives[t].Amount > c))
                            {
                                return false;
                            }
                            break;
                        case BinOpEnum.LESS_EQUALS:
                            if (!(agent.Motives[t].Amount <= c))
                            {
                                return false;
                            }
                            break;
                        case BinOpEnum.GREATER_EQUALS:
                            if (!(agent.Motives[t].Amount >= c))
                            {
                                return false;
                            }
                            break;
                        default:
                            Console.WriteLine("ERROR - JSON BinOp specification mistake for Motive Requirement for action");
                            return false;
                    }
                }
            }
            return true;
        }

        /**
         * Stopping condition for the simulation
         * Stops the sim when all agents are content 
         */
        public static bool AllAgentsContent()
        {
            foreach (Agent a in Agents)
            {
                if (!a.IsContent()) return false;
            }
            return true;
        }

        /** Decrements the motives of every agent in the simulation */
        public static void DecrementMotives()
        {
            foreach (Agent a in Agents)
            {
                a.DecrementMotives();
            }
        }
    }
}
