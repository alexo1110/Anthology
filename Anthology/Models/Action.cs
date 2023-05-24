namespace Anthology.Models
{
    /**
 * Effect Class
 * Contains the delta change in the momtive of an agent implementing the action.
 * One effect per motive type.
 * eg. Sleep action may affect the physical motive
 */
    public class Effect
    {
        /**
         * describes th emotive affected by this effected.
         * eg. if an action affects the social motive of an agent,
         * then motive = MotiveEnum.SOCIAL
         */
        public MotiveEnum Type { get; set; }

        /** valence of effect on the motive */
        public float Delta { get; set; }
    }

    /**
     * Target type enum
     * List of values that determine who the target effects of an action (if applicable), are applied to.
     * This roughly mirrors the parameters of the people requirement
     */
    public enum TargetEnum
    {
        /**
         * all agents present when the action is started (ie at the action's associated location when the
         * agent begins to perform it) receive the target effects
         * This target type could be used for an agent making a public speech
         */
        ALL = 0,

        /**
         * only agents who are present when the action is started 9ie at the action's associated location 
         * when the agent begins to perform it), and who fit the SpecificPeoplePresent criteria of the people
         * requirement receive the target effects.
         * This is used for actions that only apply to a certain few people.
         */
        SPECIFIC = 1,

        /**
         * a single, random agent who is present when the action is started (ie at the action's associated 
         * location when the agent begins to perform it), and who fits the SpecificPeoplePresent criteria of the
         * people requirement receives the target effects
         * This could be used for an action that has one agent chat with a single friend out of a few specific options
         */
        SPECIFIC_SINGLE = 2,

        /**
         * a single, random agent who is present when the action is started (ie at the action's associated 
         * location when the agent begins to perform it) receives the target effects
         * This can be used for an action such as asking a stranger for directions
         */
        RANDOM_PRESENT = 3
    }

    /**
     * Action class all actions should inherit from
     * All actions have at least a name, requirements, and minimum time taken
     */
    public abstract class Action
    {
        /** Name of the action */
        public string Name { get; set; } = string.Empty;

        /** List of preconditions or requirements that must be fulfilled for this action to execute */
        public HashSet<Requirement> Requirements { get; set; } = new HashSet<Requirement>();

        /** The minimum amount of time an action takes to execute */
        public int MinTime { get; set; }

        /** Optional flag to be set if this action cannot be selected by agents normally */
        public bool Hidden = false;

        /** Filter through the set of requirements of this action to find the set of the given requirement type */
        public HashSet<Requirement> GetRequirementsByType(ReqEnum type)
        {
            bool MismatchesType(Requirement req)
            {
                return req.Type != type;
            }

            HashSet<Requirement> reqs = new();
            reqs.UnionWith(Requirements);
            reqs.RemoveWhere(MismatchesType);

            return reqs;
        }
    }

    /**
     * Action or Behavior to be executed by an agent
     * ex. sleep
     */
    public class PrimaryAction : Action
    {
        /** List of reuslting changes to the motives of the agent that occur after this action is executed */
        public HashSet<Effect> Effects { get; set; } = new HashSet<Effect>();
    }

    /**
     * Action or Behavior to be executed by an agent
     * ex. go to dinner
     */
    public class ScheduleAction : Action
    {
        /** Optional flag to be set if this action is performed immediately rather than scheduled for later */
        public bool Interrupt = false;

        /** Primary action that will be performed by the instigator of this action */
        public PrimaryAction InstigatorAction { get; set; } = new PrimaryAction();

        /** Primary action that will be performed by the target of this action */
        public PrimaryAction TargetAction { get; set; } = new PrimaryAction();

        /** 
         * The method of choosing which agent(s) will be the target of this action
         * NOTE: some target methods require the action to have a people requirement to function properly
         */
        public TargetEnum Target { get; set; }
    }


    public class SerializableScheduleAction : ScheduleAction
    {
        /** Primary action that will be performed by the instigator of this action */
        public new string InstigatorAction { get; set; } = string.Empty;

        /** Primary action that will be performed by the target of this action */
        public new string TargetAction { get; set; } = string.Empty;
    }
}
