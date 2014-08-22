// file:	Entity.cs
//
// summary:	Implements the entity class

using System;
using System.Runtime.InteropServices;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   An entity. </summary>
    ///
    

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Entity : IEntity
    {
        /// <summary>   Constructor. </summary>
        ///
        
        ///
        /// <param name="eType">            The e type. </param>
        /// <param name="index" type="int"> Zero-based index of the. </param>

        public Entity(EntityType eType, int index)
        {
            EType = eType;
            eIndex = index;
            StructBase = Funcs.GetEntity(EType, eIndex);
        }

        /// <summary>   Gets or sets the zero-based index of this object. </summary>
        ///
        /// <value> The e index. </value>

        public int eIndex { get; set; }

        /// <summary>   Gets or sets the type. </summary>
        ///
        /// <value> The e type. </value>

        public EntityType EType { get; set; }

        /// <summary>   Gets or sets the structure base. </summary>
        ///
        /// <value> The structure base. </value>

        public IntPtr StructBase { get; protected set; }

        /// <summary>   Moves. </summary>
        ///
        
        ///
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown when one or more arguments are outside the required range.
        /// </exception>
        ///
        /// <param name="distance" type="float">        The distance. </param>
        /// <param name="direction" type="Direction">   The direction. </param>

        public void Move(float distance, Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    Y -= distance;
                    break;
                case Direction.S:
                    Y += distance;
                    break;
                case Direction.E:
                    X += distance;
                    break;
                case Direction.W:
                    X -= distance;
                    break;
                case Direction.NE:
                    X += distance;
                    Y -= distance;
                    break;
                case Direction.NW:
                    X -= distance;
                    Y -= distance;
                    break;
                case Direction.SE:
                    X += distance;
                    X += distance;
                    break;
                case Direction.SW:
                    X -= distance;
                    Y += distance;
                    break;
                case Direction.Down:
                    Z -= distance;
                    break;
                case Direction.Up:
                    Z += distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        /// <summary>   Warps. </summary>
        ///
        
        ///
        /// <param name="x" type="float">   The x coordinate. </param>
        /// <param name="z" type="float">   The z coordinate. </param>
        /// <param name="y" type="float">   The y coordinate. </param>

        public void Warp(float x, float z, float y)
        {
            X = x;
            Z = z;
            Y = y;
        }

        /// <summary>   Gets or sets the x coordinate. </summary>
        ///
        /// <value> The x coordinate. </value>

        public float X
        {
            
            get { return Funcs.GetPOS(EType, Axis.X, eIndex); }
            
            set { Funcs.SetPOS(EType, Axis.X, eIndex, value); }
        }

        /// <summary>   Gets or sets the y coordinate. </summary>
        ///
        /// <value> The y coordinate. </value>

        public float Y
        {
            
            get { return Funcs.GetPOS(EType, Axis.Y, eIndex); }
            
            set { Funcs.SetPOS(EType, Axis.Y, eIndex, value); }
        }

        /// <summary>   Gets or sets the z coordinate. </summary>
        ///
        /// <value> The z coordinate. </value>

        public float Z
        {
            
            get { return Funcs.GetPOS(EType, Axis.Z, eIndex); }
            
            set { Funcs.SetPOS(EType, Axis.Z, eIndex, value); }
        }

        /// <summary>   Gets or sets the vector x coordinate. </summary>
        ///
        /// <value> The vector x coordinate. </value>

        public float VectorX
        {
            
            get { return Funcs.Get3DVector(EType, Axis.X, eIndex); }
            
            set { Funcs.Set3DVector(EType, Axis.X, eIndex, value); }
        }

        /// <summary>   Gets or sets the vector y coordinate. </summary>
        ///
        /// <value> The vector y coordinate. </value>

        public float VectorY
        {
            
            get { return Funcs.Get3DVector(EType, Axis.Y, eIndex); }
            
            set { Funcs.Set3DVector(EType, Axis.Y, eIndex, value); }
        }

        /// <summary>   Gets or sets the vector z coordinate. </summary>
        ///
        /// <value> The vector z coordinate. </value>

        public float VectorZ
        {
            
            get { return Funcs.Get3DVector(EType, Axis.Z, eIndex); }
            
            set { Funcs.Set3DVector(EType, Axis.Z, eIndex, value); }
        }

        /// <summary>   Gets the name. </summary>
        ///
        /// <value> The name. </value>

        public string Name
        {
            
            get { return Funcs.GetName(EType, eIndex); }
        }

        /// <summary>   Gets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>

        public Int32 EntityID
        {
            
            get { return Funcs.GetEntityID(EType, eIndex); }
        }

        /// <summary>   Gets buffer debuff. </summary>
        ///
        
        ///
        /// <param name="index" type="int"> Zero-based index of the. </param>
        ///
        /// <returns>   The buffer debuff. </returns>

        public virtual BuffStruct GetBuffDebuff(int index)
        {
            return null;
        }

        /// <summary>   Gets the identifier. </summary>
        ///
        /// <value> The identifier. </value>

        public Int32 ID
        {
            
            get { return Marshal.ReadInt32(StructBase, PCMobStruct.ID); }
        }

        /// <summary>   Gets the type of the mob. </summary>
        ///
        /// <value> The type of the mob. </value>

        public byte MobType
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.MobType); }
        }

        /// <summary>   Gets or sets the current target. </summary>
        ///
        /// <value> The current target. </value>

        public byte CurrentTarget
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.CurrentTarget); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.CurrentTarget, value); }
        }

        /// <summary>   Gets the distance. </summary>
        ///
        /// <value> The distance. </value>

        public byte Distance
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.Distance); }
        }

        /// <summary>   Gets or sets the gathering status. </summary>
        ///
        /// <value> The gathering status. </value>

        public byte GatheringStatus
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.GatheringStatus); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.GatheringStatus, value); }
        }

        /// <summary>   Gets the identifier of the fate. </summary>
        ///
        /// <value> The identifier of the fate. </value>

        public UInt16 FateID
        {
            
            get { return (UInt16)Marshal.PtrToStructure(StructBase + PCMobStruct.FateId, typeof(UInt16)); }
        }

        /// <summary>   Gets or sets the gathering invs. </summary>
        ///
        /// <value> The gathering invs. </value>

        public byte GatheringInvs
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.GatheringInvisible); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.GatheringInvisible, value); }
        }

        /// <summary>   Gets or sets the camera glide. </summary>
        ///
        /// <value> The camera glide. </value>

        public float CamGlide
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + PCMobStruct.CamGlide, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.CamGlide, false); }
        }

        /// <summary>   Gets or sets the static camera glide. </summary>
        ///
        /// <value> The static camera glide. </value>

        public float StaticCamGlide
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + PCMobStruct.StaticCamGlide, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.StaticCamGlide, false); }
        }

        /// <summary>   Gets or sets the status. </summary>
        ///
        /// <value> The status. </value>

        public byte Status
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.StatusAdjust); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.StatusAdjust, value); }
        }

        /// <summary>   Gets or sets the is gm. </summary>
        ///
        /// <value> The is gm. </value>

        public byte IsGM
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.IsGM); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.IsGM, value); }
        }

        /// <summary>   Gets or sets the icon. </summary>
        ///
        /// <value> The icon. </value>

        public byte Icon
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.Icon); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.Icon, value); }
        }

        /// <summary>   Gets or sets the is engadged. </summary>
        ///
        /// <value> The is engadged. </value>

        public byte IsEngadged
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.IsEngaged); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.IsEngaged, value); }
        }

        /// <summary>   Gets the is moving. </summary>
        ///
        /// <value> The is moving. </value>

        public Int32 IsMoving
        {
            
            get { return Marshal.ReadInt32(StructBase, PCMobStruct.IsMoving); }
        }

        /// <summary>   Gets or sets the time traveled. </summary>
        ///
        /// <value> The time traveled. </value>

        public float TimeTraveled
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + PCMobStruct.TimeTraveled, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.TimeTraveled, false); }
        }

        /// <summary>   Gets or sets the identifier of the target. </summary>
        ///
        /// <value> The identifier of the target. </value>

        public UInt32 TargetID
        {
            
            get { return (UInt32)Marshal.PtrToStructure(StructBase + PCMobStruct.TargetID, typeof(UInt32)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.TargetID, false); }
        }

        /// <summary>   Gets or sets the current job. </summary>
        ///
        /// <value> The current job. </value>

        public byte CurrentJob
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.CurrentJob); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.CurrentJob, value); }
        }

        /// <summary>   Gets or sets the current level. </summary>
        ///
        /// <value> The current level. </value>

        public byte CurrentLevel
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.CurrentLevel); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.CurrentLevel, value); }
        }

        /// <summary>   Gets or sets the current GC. </summary>
        ///
        /// <value> The current GC. </value>

        public byte CurrentGC
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.CurrentGC); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.CurrentGC, value); }
        }

        /// <summary>   Gets or sets the GC rank. </summary>
        ///
        /// <value> The GC rank. </value>

        public byte GCRank
        {
            
            get { return Marshal.ReadByte(StructBase, PCMobStruct.GCRank); }
            
            set { Marshal.WriteByte(StructBase, PCMobStruct.GCRank, value); }
        }

        /// <summary>   Gets or sets the hp. </summary>
        ///
        /// <value> The hp. </value>

        public Int32 HP
        {
            
            get { return Marshal.ReadInt32(StructBase, PCMobStruct.CurrentHP); }
            
            set { Marshal.WriteInt32(StructBase, PCMobStruct.CurrentHP, value); }
        }

        /// <summary>   Gets or sets the maximum hp. </summary>
        ///
        /// <value> The maximum hp. </value>

        public Int32 MaxHP
        {
            
            get { return Marshal.ReadInt32(StructBase, PCMobStruct.MaxHP); }
            
            set { Marshal.WriteInt32(StructBase, PCMobStruct.MaxHP, value); }
        }

        /// <summary>   Gets or sets the mp. </summary>
        ///
        /// <value> The mp. </value>

        public Int32 MP
        {
            
            get { return Marshal.ReadInt32(StructBase, PCMobStruct.CurrentMP); }
            
            set { Marshal.WriteInt32(StructBase, PCMobStruct.CurrentMP, value); }
        }

        /// <summary>   Gets or sets the maximum mp. </summary>
        ///
        /// <value> The maximum mp. </value>

        public Int32 MaxMP
        {
            
            get { return Marshal.ReadInt32(StructBase, PCMobStruct.MaxMP); }
            
            set { Marshal.WriteInt32(StructBase, PCMobStruct.MaxMP, value); }
        }

        /// <summary>   Gets or sets the TP. </summary>
        ///
        /// <value> The TP. </value>

        public Int16 TP
        {
            
            get { return (Int16)Marshal.PtrToStructure(StructBase + PCMobStruct.TP, typeof(Int16)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.TP, false); }
        }

        /// <summary>   Gets or sets the gp. </summary>
        ///
        /// <value> The gp. </value>

        public Int16 GP
        {
            
            get { return (Int16)Marshal.PtrToStructure(StructBase + PCMobStruct.GP, typeof(Int16)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.GP, false); }
        }

        /// <summary>   Gets or sets the unknown points. </summary>
        ///
        /// <value> The unknown points. </value>

        public Int16 UnknownPoints
        {
            
            get { return (Int16)Marshal.PtrToStructure(StructBase + PCMobStruct.UnknownPoints, typeof(Int16)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.UnknownPoints, false); }
        }

        /// <summary>   Gets or sets the cp. </summary>
        ///
        /// <value> The cp. </value>

        public Int16 CP
        {
            
            get { return (Int16)Marshal.PtrToStructure(StructBase + PCMobStruct.CurrentCP, typeof(Int16)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.CurrentCP, false); }
        }

        /// <summary>   Gets or sets the maximum cp. </summary>
        ///
        /// <value> The maximum cp. </value>

        public Int16 MaxCP
        {
            
            get { return (Int16)Marshal.PtrToStructure(StructBase + PCMobStruct.MaxCP, typeof(Int16)); }
            
            set { Marshal.StructureToPtr(value, StructBase + PCMobStruct.MaxCP, false); }
        }

        /// <summary>   Gets or sets the is active. </summary>
        ///
        /// <value> The is active. </value>

        public virtual int IsActive { get; set; }
    }

    /// <summary>   A buffer structure. </summary>
    ///
    

    public class BuffStruct
    {
    }
}
