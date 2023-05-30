namespace Anthology.Models
{
    public static class World
    {
        /** World time, or ticks */
        public static int Time { get; set; } = 0;

        /** Initialize/reset all static world variables */
        public static void Init()
        {
            Time = 0;
            ActionManager.Init();
            AgentManager.Init();
            LocationManager.Init(UI.GridSize);
        }

        /** Increment simulation time by one tick */
        public static void IncrementTime()
        {
            Time += 1;
            if (Time % 1200 == 0)
            {
                foreach (Agent agent in AgentManager.Agents)
                {
                    if (!agent.IsContent())
                    {
                        agent.DecrementMotives();
                    }
                }
            }
        }
    }
}
