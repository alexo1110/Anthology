using Anthology.SimulationManager;

namespace SimManagerUnitTest
{
    [TestClass]
    public class SimManagerUnitTest
    {
        private const string DATA_JSON = "Data\\Paths.json";

        [TestInitialize]
        public void TestInitialize()
        {
            try
            {
                SimManager.Init(DATA_JSON, typeof(AnthologyRS), typeof(LyraKS));
            }
            catch (Exception e)
            {
                Assert.Fail("Failed to initialize Sim Manager: " + e.Message);
            }
        }

        [TestMethod]
        public void TestInitAnthologyLyra()
        {
            Assert.IsNotNull(SimManager.Reality);
            // Assert.IsNotNull(SimManager.Knowledge); ignored until LyraKS is implemented
            Assert.IsTrue(SimManager.NPCs.Count > 0);
        }

        [TestMethod]
        public void TestReality()
        {
            Dictionary<string, NPC> npcs = new Dictionary<string, NPC>();
            SimManager.Reality?.LoadNpcs(npcs);
            Assert.IsTrue(npcs.Count > 0);
            Assert.IsTrue(npcs.ContainsKey("Norma"));
            Assert.IsTrue(npcs.ContainsKey("Abnorma"));
            Assert.IsTrue(npcs.ContainsKey("Quentin"));
            Assert.IsTrue(npcs.ContainsKey("MathProf"));
            Assert.IsTrue(npcs.ContainsKey("PhysicsProf"));

            {
                NPC npc = new() { Name = "Norma" };
                SimManager.Reality?.UpdateNpc(npc);
                Assert.AreEqual(npc.Name, "Norma");
                Assert.AreEqual(npc.CurrentAction.Name, "wait_action");
            }
        }
    }
}