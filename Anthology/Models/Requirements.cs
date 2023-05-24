namespace Anthology.Models
{
    // Three types of requirements
    /**
     * Requirement types enum
     * Consists of three types of requirements
     */
    public enum ReqEnum
    {
        // indicates a location requirement
        LOCATION = 0,

        // indicates a people requirement
        PEOPLE = 1,

        // indicates a motive requirement
        MOTIVE = 2
    }

    /**
     * Binary operations enum
     * Used primarily in requirements to test conditions
     * eg. RMotive : social motive must be greater than 5
     */
    public enum BinOpEnum
    {
        EQUALS = 0,
        GREATER = 1,
        LESS = 2,
        GREATER_EQUALS = 3,
        LESS_EQUALS = 4
    }

    /** Requirement class all requirement types should inherit from */
    public abstract class Requirement
    {
        /** all requirements should have an enumerated type (or a string for file IO?) */
        public abstract ReqEnum Type { get; }
    }

    /** 
     * Location Requirement
     * Requirements on the type of location the action takes place in.
     * Based on a tags system for locations.
     * eg: HasAllOf: { "restaurant" } implies to execute the action, one must be at a restaurant.
     */
    public class RLocation : Requirement
    {
        public override ReqEnum Type
        {
            get { return ReqEnum.LOCATION; }
        }

        /** set of string tags that must be a subset of the location's tags for the action to occur */
        public HashSet<string> HasAllOf { get; set; } = new HashSet<string>(); 

        /** set of string tags in which their must exist at least one match with the location's tags for the action to occur */
        public HashSet<string> HasOneOrMoreOf { get; set; } = new HashSet<string>();

        /** set of string tags that must be a disjoint set of the location's tags for the action to occur */
        public HashSet<string> HasNoneOf { get; set; } = new HashSet<string>();
    }

    /**
     * People Requirement
     * Requirements on who is or must be present for an action.
     * eg. MinNumPeople = 2 implies that at least 2 people must be present for the action to occur
     */
    public class RPeople : Requirement
    {
        public override ReqEnum Type
        {
            get { return ReqEnum.PEOPLE; }
        }

        /** the minimum number of people that must be present for the action to occur */
        public short MinNumPeople { get; set; }

        /** the maximum number of people that may be present for the action to occur */
        public short MaxNumPeople { get; set; }

        /** 
         * set of agents that must be present for the action to be completed.
         * eg. A cook must be present at a restaurant for food to be served to a customer.
         */
        public HashSet<Agent> SpecificPeoplePresent { get; set; } = new HashSet<Agent>();

        /** set of agents that must be absent for the action to be completed. */
        public HashSet<Agent> SpecificPeopleAbsent { get; set; } = new HashSet<Agent>();

        /**
         * Relationships that must exist between participating agents in order for the action to execute
         * eg. [teacher, student] relationships for the action "submit_homework"
         */
        public HashSet<string> RelationshipsPresent { get; set; } = new HashSet<string>();

        /**
         * Relationships that must not exist between participating agents in order for the action to execute
         * eg. [siblings] relationship for the action "kiss_romantically"
         */
        public HashSet<string> RelationshipsAbsent { get; set; } = new HashSet<string>();
    }


    public class RMotive : Requirement
    {
        public override ReqEnum Type
        {
            get { return ReqEnum.MOTIVE; }
        }

        /** 
         * describes the type of motive that must be tested for this requirement 
         * eg. Emotional, Social, Financial, etc.
         */
        public MotiveEnum MotiveType { get; set; }

        /** Binary Operation used to test condition */
        public BinOpEnum Operation { get; set; }

        /** Threshold value for testing the condition */
        public float Threshold { get; set; }
    }
}
