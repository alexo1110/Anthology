using System.Diagnostics;
using System.Net.Http.Headers;

namespace Anthology.SimulationManager
{
    /**
     * Concrete example implementation of KnowledgeSim using the Lyra API 
     * Currently unimplemented until the Lyra API is complete
     */
    public class LyraKS : KnowledgeSim
    {
        private static string LYRA_URI = "http://127.0.0.1:8000";

        private HttpClient client = new HttpClient();

        /** TODO */
        public async override void Init(string pathFile = "")
        {
            client.BaseAddress = new Uri(LYRA_URI);

            var result = await client.GetAsync("lyra/sim/start");
            Debug.WriteLine(result);
        }

        /** TODO */
        public override void LoadNpcs(Dictionary<string, NPC> npcs)
        {
            throw new NotImplementedException();
        }

        /** TODO */
        public override void PushUpdatedNpc(NPC npc)
        {
            throw new NotImplementedException();
        }

        /** TODO */
        public override void Run(int steps = 1)
        {
            throw new NotImplementedException();
        }

        /** TODO */
        public override void UpdateNpc(NPC npc)
        {
            throw new NotImplementedException();
        }
    }
}
