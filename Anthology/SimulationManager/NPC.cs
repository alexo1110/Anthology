using System.Numerics;
using System.Text;

namespace Anthology.SimulationManager
{
  /**
   * An Agent/Actor/Individual/Unit/NPC to be maintained by the simulation manager
   * Contains data necessary for coordinating behavior across simulations and for
   * displaying information on the frontend
   */
  public class NPC
  {
        /** The name of the NPC */      
        public string Name { get; set; } = string.Empty;
        
        /** 
         * The GUID of the NPC
         * (Might be unused)
         */
        public uint Guid { get; set; }

        /** The (X,Y) coordinate location of the NPC */
        public Vector2 Coordinates;

        /** The action current being performed by the NPC */
        public Action CurrentAction { get; set; } = new();

        /** Data representing the knowledge/beliefs/opinions of the NPC */
        public byte[] Knowledge { get; set; } = { };

        /**
         * Gets a string representation of the NPC, in the following format:
         * 
         * "Name: {name}
         *  X: {x}, Y: {y}
         *  Current Action: {name of action}"
         */
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
