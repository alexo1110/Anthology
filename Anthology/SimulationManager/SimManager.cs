namespace Anthology.SimulationManager
{
    public static class SimManager
    {
        public static Dictionary<string, NPC> NPCs = new();

        public static RealitySim? Reality { get; set; } 

        public static KnowledgeSim? Knowledge { get; set; }

        public static void Init(string JSONfile, Type reality, Type knowledge)
        {
            try
            {
                if (reality.IsSubclassOf(typeof(RealitySim)))
                {
                    Reality = Activator.CreateInstance(reality) as RealitySim;
                    if (Reality == null)
                        throw new NullReferenceException("Could not create reality sim");
                    Reality.Init(JSONfile);
                    Reality.LoadNpcs(NPCs);
                }
                else
                    throw new InvalidCastException("Failed to recognize reality sim type");
                if (knowledge.IsSubclassOf(typeof(KnowledgeSim)))
                {
                    Knowledge = Activator.CreateInstance(knowledge) as KnowledgeSim;
                    if (Knowledge == null)
                        throw new NullReferenceException("Could not create knowledge sim");
                    Knowledge.Init(JSONfile);
                    Knowledge.LoadNpcs(NPCs);
                }
                else
                    throw new InvalidCastException("Failed to recognize knowledge sim type");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void GetIteration(int steps = 1)
        {
            Reality.Run(steps);
            Knowledge.Run(steps);
            foreach (NPC npc in NPCs.Values)
            {
                Reality.UpdateNpc(npc);
                Knowledge.UpdateNpc(npc);
            }
        }

        //public static NPC GetNPCByUUID(uint uuid)
        //{
        //    return NPCs[uuid];
        //}

        public static void PushUpdatedNpc(NPC npc)
        {
            Reality.PushUpdatedNpc(npc);
            Knowledge.PushUpdatedNpc(npc);
        }
    }
}
