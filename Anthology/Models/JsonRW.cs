namespace Anthology.Models 
{
    /** Abstracts away JSON reading for compatibility with legacy JSON readers */
    public abstract class JsonRW 
    {
        /** Load actions from the given file path directly into the ActionManager */
        public static void LoadActionsFromFile(string path);

        /** Load agents from the given file path directly into the AgentManager */
        public static void LoadAgentsFromFile(string path);

        /** Load locations from the given file path directly into the LocationManager */
        public static void LoadLocationsFromFile(string path);
    }
}