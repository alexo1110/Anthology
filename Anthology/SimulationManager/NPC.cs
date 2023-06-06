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
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { Dirty = true; name = value; }
        }

        /** 
         * The GUID of the NPC
         * (Might be unused)
         */
        private Guid id;
        public Guid ID
        {
            get { return id; }
            set { Dirty = true; id = value; }
        }

        /** The (X,Y) coordinate location of the NPC */
        private Vector2 coordinates;
        public ref Vector2 Coordinates
        {
            get { Dirty = true; return ref coordinates; }
        }

        /** The action current being performed by the NPC */
        private Action currentAction = new(); 
        public Action CurrentAction
        {
            get { return currentAction; }
            set { Dirty = true; currentAction = value; }
        }

        /** Data representing the knowledge/beliefs/opinions of the NPC */
        private byte[] knowledge { get; set; } = { };
        public byte[] Knowledge
        {
            get { return knowledge; }
            set { Dirty = true; knowledge = value; }
        }

        /** Whether or not this NPC has been modified and needs to have its update pushed */
        public bool Dirty { get; set; } = false;

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
