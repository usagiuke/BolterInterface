// file:	Offsets.cs
//
// summary:	Implements the offsets class

namespace BolterLib
{
    /// <summary>   A PC mob structure. </summary>
    ///
    /// <remarks>   Bunny 2, 3/14/2014. </remarks>

    public class NaviMapOffsets
    {
        internal const int UISizeMultiplier = 0x11C, Zoom = 0x1AC, XCord = 0x1C88, YCord = 0x1C8C;
    }

    public class SynthesisOffects
    {
        internal const int Progress = 0x1C, ProgressMax = 0x150, Quality = 0x24, QualityMax = 0x152, Durability = 0x30, DurabilityMax = 0x8E4, HQRate = 0x2C, Condition = 0x38;
    }

    public class PCMobStruct
    {
        /// <summary>   The patch offset. </summary>
        public static int patchOffset;
        /// <summary>   The buffer other. </summary>
        internal const int Name = 0x30,
            ID = 0x74,
            NPCID = 0x78,
            MobType = 0x8A,
            CurrentTarget = 0x8C,
            Distance = 0x8D,
            GatheringStatus = 0x8E,
            POS = 0xA0,
            Heading = 0xB0,
            ServerHight = 0xB4,
            FateId = 0xE8,
            subStruct = 0xEC,
            GatheringInvisible = 0x10C,
            CamGlide = 0x124,
            StaticCamGlide = 0x164,
            StatusAdjust = 0x17C,
            IsGM = 0x179,
            Icon = 0x184,
            IsEngaged = 0x185,
            EntityID = 0x1C0,
            IsMoving = 0x1E0,
            TimeTraveled = 0x230,
            ChatPoint = 0x584,
            TargetID = 0xA28,
            CurrentJob = 0x17E0,
            CurrentLevel = 0x17E1,
            CurrentGC = 0x17E2,
            GCRank = 0x17E3,
            CurrentHP = 0x17E8,
            MaxHP = 0x17EC,
            CurrentMP = 0x17F0,
            MaxMP = 0x17F4,
            TP = 0x17F8,
            GP = 0x17FA,
            UnknownPoints = 0x17FC,
            CurrentCP = 0x17FE,
            MaxCP = 0x1800,
            BuffID = 0x3168,
            BuffParam = 0x316A,
            BuffTime = 0x316C,
            BuffOther = 0x3170;
    }

    /// <summary>   A camera structure. </summary>
    ///
    

    public class CamStruct
    {
        /// <summary>   The pitch maximum. </summary>
        internal const int Zoom = 0xE8,
            ZoomMin = 0xEC,
            ZoomMax = 0xF0,
            Pitch = 0x104,
            PitchMin = 0x118,
            PitchMax = 0x11C;
    }

    /// <summary>   A movement structure. </summary>
    ///
    

    public class MovementStruct
    {
        /// <summary>   The walk forward. </summary>
        internal const int
            Status = 0x0,
            CurrentSpeed = 0x18,
            FowardSpeed = 0x20,
            LeftRightSpeed = 0x28,
            BackwardSpeed = 0x30,
            ForwardSpeedWeaponDrawn = 0x34,
            LeftRightSpeedWeaponDrawn = 0x38,
            BackwardSpeedWeaponDrawn = 0x3C,
            WalkLeft = 0x68C,
            WalkRight = 0x698,
            StrafeRight = 0x69C,
            StrafeLeft = 0x6CC,
            WalkBack = 0x6D4,
            WalkForward = 0x6E4;
    }
}
