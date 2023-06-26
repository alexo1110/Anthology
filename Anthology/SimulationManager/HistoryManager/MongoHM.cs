using MongoDB.Driver;

namespace Anthology.SimulationManager.HistoryManager
{
    public class MongoHM : HistoryLogger
    {
        private MongoClient DbClient { get; set; } = new MongoClient("mongodb://localhost:27017/");

        private IMongoDatabase Database { get; set; }
        
        private IMongoCollection<EventLog> LastUsedLog { get; set; }

        public MongoHM()
        {
            Database = DbClient.GetDatabase("SimManager");
            LastUsedLog = Database.GetCollection<EventLog>("EventLog");
            if (LastUsedLog == null)
            {
                Database.CreateCollection("EventLog");
                LastUsedLog = Database.GetCollection<EventLog>("EventLog");
            }
        }

        public override void AddNpcToLog(NPC npc)
        {
            ELog.NpcChanges.Add(npc.Name, npc);
        }

        public override void LogNpcStates(string? destination)
        {
            IMongoCollection<EventLog> logCollection;
            if (destination != null)
            {
                logCollection = Database.GetCollection<EventLog>(destination);
                if (logCollection == null)
                {
                    Database.CreateCollection(destination);
                    logCollection = Database.GetCollection<EventLog>(destination);
                }
            }
            else
            {
                logCollection = LastUsedLog;
            }
            LastUsedLog = logCollection;
            if (ELog.NpcChanges.Count > 0)
            {
                logCollection.InsertOne(ELog);
                ELog = new();
            }
        }

        public override void SaveState(string destination)
        {
            IMongoCollection<SimState> stateCollection = Database.GetCollection<SimState>(destination);
            if (stateCollection == null)
            {
                Database.CreateCollection(destination);
                stateCollection = Database.GetCollection<SimState>(destination);
            }
            stateCollection.InsertOne(new SimState());
        }

        public override void LoadState(string state)
        {
            throw new NotImplementedException();
        }

        public override void DeleteState(string state)
        {
            Database.DropCollection(state);
        }

        public override void ClearLog(string log)
        {
            Database.GetCollection<EventLog>(log).DeleteMany(Builders<EventLog>.Filter.Empty);
        }
    }
}
