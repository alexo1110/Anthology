using System.Text.Json.S

namespace Anthology.Models
{
    public class NetJson : JsonRW 
    {
        private static JsonSerializerOptions Jso { get; } = new()
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public override LoadActionsFromFile(string path) 
        {
            string actionsText = File.ReadAllText(path);
            ActionContainer? actions = JsonSerializer.Deserialize<ActionContainer>(actionsText, Jso);
            if (actions == null) return;
            Actions = actions;
        }

        public override LoadAgentsFromFile(string path) 
        {
            string agentsText = File.ReadAllText(path);
            List<SerializableAgent>? sAgents = JsonSerializer.Deserialize<List<SerializableAgent>>(agentsText, Jso);

            if (sAgents == null) return;
            foreach (SerializableAgent s in sAgents)
            {
                Agents.Add(SerializableAgent.DeserializeToAgent(s));
            }
        }

        public override LoadLocationsFromFile(string path) 
        {
            string agentsText = File.ReadAllText(path);
            List<SerializableAgent>? sAgents = JsonSerializer.Deserialize<List<SerializableAgent>>(agentsText, Jso);

            if (sAgents == null) return;
            foreach (SerializableAgent s in sAgents)
            {
                Agents.Add(SerializableAgent.DeserializeToAgent(s));
            }
        }
    }
}