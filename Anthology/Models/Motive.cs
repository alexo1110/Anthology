namespace Anthology.Models
{
    // Five motive types
    /**
     * Motive types enum
     * Currently has a preset list of 5 motives - physical, emotional, social, financial, accomplishment
     * In future, this will be pulled from the json file.
     */
    public enum MotiveEnum
    {
        // deals with the agent's physical needs - eg. eat or sleep
        PHYSICAL = 0,

        // deals with the agent's emotional needs - eg. happiness from watching a movie
        EMOTIONAL = 1,

        // deals with the agent's social needs - eg. spending time with other agents
        SOCIAL = 2,

        // deals with the agent's financial needs - eg. working for a living
        FINANCIAL = 3,

        // deals with the agent's sense of accomplishment - eg. skill learnt by doing a hobby
        ACCOMPLISHMENT = 4
    };

    /** Motive class all motive types should inherit from */
    public abstract class Motive
    {
        /** all motives should have an enumerated type (or a string for file IO?) */
        public abstract MotiveEnum Type { get; }

        /** all motives should have a numeric amount */
        public float Amount { get; set; }

        /** the maximum value of a motive */
        public const float MAX = 5f;

        /** the minimum value of a motive */
        public const float MIN = 1f;
    }

    public class MPhysical : Motive
    {
        public override MotiveEnum Type
        {
            get { return MotiveEnum.PHYSICAL; }
        }
    }

    public class MEmotional : Motive
    {
        public override MotiveEnum Type
        {
            get { return MotiveEnum.EMOTIONAL; }
        }
    }

    public class MSocial : Motive
    {
        public override MotiveEnum Type
        {
            get { return MotiveEnum.SOCIAL; }
        }
    }

    public class MFinancial : Motive
    {
        public override MotiveEnum Type
        {
            get { return MotiveEnum.FINANCIAL; }
        }
    }

    public class MAccomplishment : Motive
    {
        public override MotiveEnum Type
        {
            get { return MotiveEnum.ACCOMPLISHMENT; }
        }
    }
}
