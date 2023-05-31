using System.Numerics;

namespace Anthology.SimManager
{
    public class NPC
    {
        public string Name { get; set; } = string.Empty;
        public uint Guid { get; set; }

        public Vector2 Coordinates;

        public Action CurrentAction { get; set; } = null;
        public byte[] Knowledge { get; set; } = null;

        
    }
}
