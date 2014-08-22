using System;

namespace BolterInterface
{
    /// <summary>
    /// Enumeration of gathering node types.
    /// </summary>
    public enum GatheringNode : uint
    {
        Lush_Vegetation_Patch,
        Mature_Tree,
        Mineral_Deposit,
        Rocky_Outcrop
    }

    /// <summary>
    /// Target status flags. 
    /// </summary>
    [Flags]
    public enum TargetStatus : uint
    {
        /// <summary>
        /// Nothing currently targeted.
        /// </summary>
        NoTarget = 0x00010001,
        /// <summary>
        /// Is targeting something.
        /// </summary>
        HasTarget = 0x00010000,
        /// <summary>
        /// Target is locked. 
        /// </summary>
        Locked = 0x01010000
    }

    /// <summary>
    /// Character movement flags.
    /// </summary>
    [Flags]
    public enum WalkingStatus
    {
        /// <summary>
        /// Character is not moving.
        /// </summary>
        Standing = 0x00000000,
        /// <summary>
        /// Character is running.
        /// </summary>
        Running = 0x00000001,
        /// <summary>
        /// Character is turning.
        /// </summary>
        Heading = 0x00000100,
        /// <summary>
        /// Character is walking.
        /// </summary>
        Walking = 0x00010000,
        /// <summary>
        /// Character is auto-running.
        /// </summary>
        Autorun = 0x01000000
    }

    /// <summary> 
    /// Enumeration of character axises.
    /// </summary>
    public enum Axis
    {
        X,
        Y,
        Z
    }

    /// <summary>
    /// Enumeration of position types.
    /// </summary>
    public enum PosType
    {
        Server,
        Client
    }

    /// <summary>
    /// Enumeration of entity types.
    /// </summary>
    public enum EntityType
    {
        PCMob,
        Object,
        NPC
    };

    /// <summary>
    /// Enumeration of cardinal directions.
    /// </summary>
    public enum Direction
    {
        N,
        S,
        E,
        W,
        NE,
        NW,
        SE,
        SW,
        Down,
        Up
    };

    /// <summary>
    /// Enumeration of possible synthesis conditions.
    /// </summary>
    public enum SynthesisCondition : byte
    {
        Zero,
        Normal,
        Good,
        Excellent,
        Poor
    }

    /// <summary>
    /// Enumeration of weather types.
    /// </summary>
    public enum Weather : byte
    {
        Empty,
        Clear,
        Fair,
        Overcast,
        Fog,
        Wind,
        Gales,
        Rain,
        Showers,
        Thunder,
        Thunderstorms,
        Dust_Storms,
        Sandstorms,
        Hot_Spells,
        Heat_Wave,
        Snow,
        Blizzards,
        Gloom,
        Aurora,
        Darkness,
        Hopelessness,
        Overcast_2,
        Storm_Clouds,
        Torrential,
        Torrential_2,
        Lour,
        Heat_Wave_2,
        Gloom_2,
        Gales_2,
        Eruptions,
        Fair_2,
        Fair_3,
        Fair_4,
        Fair_5,
        Fair_6,
    }

    /// <summary>
    /// Enumeration of menu types.
    /// </summary>
    public enum MenuType : byte
    {
        CraftLog = 20
    }
}
