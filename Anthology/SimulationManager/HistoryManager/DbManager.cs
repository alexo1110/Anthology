using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Anthology.SimulationManager.HistoryManager
{
    public static class DbManager
    {
        public static MongoClient DbClient { get; set; } = new MongoClient("mongodb://localhost:27017/");

        public static IMongoDatabase? Database { get; set; }

        public static IMongoCollection<NPC>? NpcCollection { get; set; }

        public static void Init()
        {
            Database = DbClient.GetDatabase("SimManager");
            NpcCollection = Database.GetCollection<NPC>("NPCs");
        }
    }
}
