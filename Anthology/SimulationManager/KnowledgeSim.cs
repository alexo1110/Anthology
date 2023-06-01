namespace Anthology.SimulationManager
{
    public abstract class KnowledgeSim
    {
        public abstract void Init(string pathFile = "");

        public abstract void LoadNpcs(Dictionary<string, NPC> npcs);

        public abstract void UpdateNpc(NPC npc);

        public abstract void PushUpdatedNpc(NPC npc);

        public abstract void Run(int steps = 1);
    }
}
