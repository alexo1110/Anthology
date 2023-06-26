using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using Anthology.SimulationManager.HistoryManager;
using MongoDB.Driver;
using Anthology.SimulationManager;
using MongoDB.Bson;

namespace SimManagerUnitTest
{
    [TestClass]
    public class HistoryManagerUnitTest
    {
        private const string DATA_JSON = "Data\\Paths.json";

        private IMongoDatabase db = new MongoClient("mongodb://localhost:27017/").GetDatabase("SimManager");

        [TestInitialize]
        public void TestInitialize()
        {
            try
            {
                SimManager.Init(DATA_JSON, typeof(AnthologyRS), typeof(LyraKS), typeof(MongoHM));
                SimManager.History?.DeleteState("test_state");
                SimManager.History?.ClearLog("test_log");
            }
            catch (Exception e)
            {
                Assert.Fail("Failed to initialize Sim Manager: " + e.Message);
            }
        }

        [TestMethod]
        public void TestHistoryLogger()
        {
            Assert.IsFalse(db.ListCollectionNames().ToList().Contains("test_state"));
            SimManager.History?.SaveState("test_state");
            Assert.IsTrue(db.ListCollectionNames().ToList().Contains("test_state"));
            
        }
    }
}
