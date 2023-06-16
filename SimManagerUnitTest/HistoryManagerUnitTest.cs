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

        [TestInitialize]
        public void TestInitialize()
        {
            try
            {
                SimManager.Init(DATA_JSON, typeof(AnthologyRS), typeof(LyraKS));
                DbManager.Init();
                DbManager.NpcCollection?.DeleteMany(Builders<NPC>.Filter.Empty);
            }
            catch (Exception e)
            {
                Assert.Fail("Failed to initialize Sim Manager: " + e.Message);
            }
        }

        [TestMethod]
        public void TestDBClient()
        {
            Assert.AreEqual(4, DbManager.DbClient.ListDatabases().ToList().Count);
            Assert.AreEqual("SimManager", DbManager.Database?.DatabaseNamespace.DatabaseName);
            DbManager.NpcCollection?.InsertMany(SimManager.NPCs.Values);
            Assert.AreEqual(5, DbManager.NpcCollection?.EstimatedDocumentCount());
        }
    }
}
