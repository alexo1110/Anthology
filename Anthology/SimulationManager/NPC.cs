using System.Numerics;
using System.Text;

namespace Anthology.SimulationManager
{
    public class NPC
    {
        public string Name { get; set; } = string.Empty;
        public uint Guid { get; set; }

        public Vector2 Coordinates;

        public Action CurrentAction { get; set; } = null;
        public byte[] Knowledge { get; set; } = null;

        public NPC()
        {
            CurrentAction = new Action();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name: {0}, ", Name);
            sb.AppendFormat("X: {0}, Y: {1}, ", Coordinates.X, Coordinates.Y);
            sb.AppendFormat("Current Action: {0}", CurrentAction.Name);
            return sb.ToString();
        }
    }
}
