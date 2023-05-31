using Anthology.Models;

namespace Anthology.SimManager
{
    public class AnthologyRS : RealitySim
    {
        
        public override void Init(string pathFile = "")
        {
            ExecutionManager.Init(pathFile);
        }

        public override void LoadNpcs(Dictionary<string, NPC> npcs)
        {
            HashSet<Agent> agents = AgentManager.Agents;
            foreach (Agent a in agents)
            {
                if (!npcs.ContainsKey(a.Name)) { npcs[a.Name] = new NPC(); }
                NPC currentNpc = npcs[a.Name];
                currentNpc.Name = a.Name;
                currentNpc.Coordinates.X = a.XLocation;
                currentNpc.Coordinates.Y = a.YLocation;
                currentNpc.CurrentAction.Name = a.CurrentAction.First().Name;
            }
        }

        public override void UpdateNpc(NPC npc)
        {
            Agent agent = AgentManager.GetAgentByName(npc.Name);
            npc.Coordinates.X = agent.XLocation;
            npc.Coordinates.Y = agent.YLocation;
            npc.CurrentAction.Name = agent.CurrentAction.First().Name;
        }

        public override void PushUpdatedNpc(NPC npc)
        {
            Agent agent = AgentManager.GetAgentByName(npc.Name);
            agent.XLocation = (int)npc.Coordinates.X;
            agent.YLocation = (int)npc.Coordinates.Y;
        }

        public override void Run(int steps = 1)
        {
            ExecutionManager.RunSim(steps);
        }
    }
}
