using Anthology.Models;
using Anthology.SimulationManager;
using Anthology.SimulationManager.HistoryManager;
using System.Numerics;

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
                SimManager.Init(DATA_JSON, typeof(AnthologyRS), typeof(LyraKS), typeof(MongoHM));
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
            Assert.IsTrue(SimManager.Locations.Count > 0);
        }

        [TestMethod]
        public void TestReality()
        {
            Dictionary<string, NPC> npcs = new();
            SimManager.Reality?.LoadNpcs(npcs);
            Assert.IsTrue(npcs.Count > 0);
            Assert.IsTrue(npcs.ContainsKey("Norma"));
            Assert.IsTrue(npcs.ContainsKey("Abnorma"));
            Assert.IsTrue(npcs.ContainsKey("Quentin"));
            Assert.IsTrue(npcs.ContainsKey("MathProf"));
            Assert.IsTrue(npcs.ContainsKey("PhysicsProf"));
            Assert.IsTrue(npcs["Norma"].Motives.Count > 0);
            Assert.IsTrue(npcs["Norma"].Motives.ContainsKey("accomplishment"));
            Assert.IsTrue(npcs["Norma"].Motives.ContainsKey("emotional"));
            Assert.IsTrue(npcs["Norma"].Motives.ContainsKey("financial"));
            Assert.IsTrue(npcs["Norma"].Motives.ContainsKey("social"));
            Assert.IsTrue(npcs["Norma"].Motives.ContainsKey("physical"));
            Assert.AreEqual(2, npcs["Norma"].Motives["accomplishment"]);
            Assert.AreEqual(3, npcs["Norma"].Motives["emotional"]);
            Assert.AreEqual(5, npcs["Norma"].Motives["financial"]);
            Assert.AreEqual(1, npcs["Norma"].Motives["social"]);
            Assert.AreEqual(4, npcs["Norma"].Motives["physical"]);

            {
                NPC npc = new() { Name = "Norma" };
                SimManager.Reality?.UpdateNpc(npc);
                Assert.AreEqual(npc.Name, "Norma");
                Assert.AreEqual(npc.CurrentAction.Name, "wait_action");
            }

            Dictionary<Location.Coords, Location> locations = new();
            SimManager.Reality?.LoadLocations(locations);
            Assert.IsTrue(locations.Count > 0);
            Assert.IsTrue(locations.ContainsKey(new Location.Coords(5, 5)));
            Assert.IsTrue(locations.ContainsKey(new Location.Coords(4, 5)));
            Assert.IsTrue(locations.ContainsKey(new Location.Coords(3, 2)));
            Assert.IsTrue(locations.ContainsKey(new Location.Coords(1, 2)));
            Assert.IsTrue(locations.ContainsKey(new Location.Coords(1, 1)));
            Assert.IsTrue(locations.ContainsKey(new Location.Coords(1, 3)));
            Assert.AreEqual("Physics Hall", locations[new Location.Coords(1, 3)].Name);
            Assert.IsTrue(locations[new Location.Coords(1, 2)].Tags.Contains("outdoor"));
        }

        [TestMethod]
        public void TestLocationFilters()
        {
            HashSet<SimLocation> locSet = LocationManager.GetSimLocationsByRange(1, 2, 0);
            Assert.AreEqual(1, locSet.Count);
            Assert.AreEqual("Greenway", locSet.First().Name);
            locSet = LocationManager.GetSimLocationsByRange(1, 2, 1);
            Assert.AreEqual(2, locSet.Count);
            locSet = LocationManager.GetSimLocationsByRange(1, 2, 2);
            Assert.AreEqual(1, locSet.Count);
            Assert.AreEqual("Dorm", locSet.First().Name);

            locSet = LocationManager.GetSimLocationsByArea(1, 2, 0);
            Assert.AreEqual(1, locSet.Count);
            Assert.AreEqual("Greenway", locSet.First().Name);
            locSet = LocationManager.GetSimLocationsByArea(1, 2, 1);
            Assert.AreEqual(3, locSet.Count);
            locSet = LocationManager.GetSimLocationsByArea(1, 2, 2);
            Assert.AreEqual(4, locSet.Count);
            locSet = LocationManager.GetSimLocationsByArea(1, 2, 6);
            Assert.AreEqual(5, locSet.Count);
        }

        [TestMethod]
        public void TestIterations()
        {
            Assert.AreEqual("wait_action", SimManager.NPCs["Norma"].CurrentAction.Name);
            SimManager.GetIteration();
            Assert.AreEqual("travel_action", SimManager.NPCs["Norma"].CurrentAction.Name);
            SimManager.GetIteration(20);
            Assert.AreNotEqual("travel_action", SimManager.NPCs["Norma"].CurrentAction.Name);
        }
    }
}