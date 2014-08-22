// file:	IEntity.cs
//
// summary:	Declares the IEntity interface

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BolterInterface
{
    /// <summary>   Interface for entity. </summary>
    ///


    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IEntity
    {
        /// <summary>   Gets or sets the zero-based index of this object. </summary>
        ///
        /// <value> The e index. </value>

        int eIndex { get; set; }

        /// <summary>   Gets the structure base. </summary>
        ///
        /// <value> The structure base. </value>

        IntPtr StructBase { get; }

        /// <summary>   Gets or sets the x coordinate. </summary>
        ///
        /// <value> The x coordinate. </value>

        float X { get; set; }

        /// <summary>   Gets or sets the y coordinate. </summary>
        ///
        /// <value> The y coordinate. </value>

        float Y { get; set; }

        /// <summary>   Gets or sets the z coordinate. </summary>
        ///
        /// <value> The z coordinate. </value>

        float Z { get; set; }

        /// <summary>   Gets or sets the vector x coordinate. </summary>
        ///
        /// <value> The vector x coordinate. </value>

        float VectorX { get; set; }

        /// <summary>   Gets or sets the vector y coordinate. </summary>
        ///
        /// <value> The vector y coordinate. </value>

        float VectorY { get; set; }

        /// <summary>   Gets or sets the vector z coordinate. </summary>
        ///
        /// <value> The vector z coordinate. </value>

        float VectorZ { get; set; }

        /// <summary>   Gets the name. </summary>
        ///
        /// <value> The name. </value>

        string Name { get; }

        /// <summary>   Gets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>

        Int32 EntityID { get; }

        /// <summary>   Moves. </summary>
        ///
        /// <param name="distance">                     The distance. </param>
        /// <param name="direction" type="Direction">   The direction. </param>

        void Move(float distance, Direction direction);

        /// <summary>   Warps. </summary>
        ///
        /// <param name="x" type="float">   The x coordinate. </param>
        /// <param name="z" type="float">   The z coordinate. </param>
        /// <param name="y" type="float">   The y coordinate. </param>

        void Warp(float x, float z, float y);

        /// <summary>   Gets the identifier. </summary>
        ///
        /// <value> The identifier. </value>

        Int32 ID { get; }

        /// <summary>   Gets the type of the mob. </summary>
        ///
        /// <value> The type of the mob. </value>

        byte MobType { get; }

        /// <summary>   Gets or sets the current target. </summary>
        ///
        /// <value> The current target. </value>

        byte CurrentTarget { get; set; }

        /// <summary>   Gets the distance. </summary>
        ///
        /// <value> The distance. </value>

        byte Distance { get; }

        /// <summary>   Gets or sets the gathering status. </summary>
        ///
        /// <value> The gathering status. </value>

        byte GatheringStatus { get; set; }

        /// <summary>   Gets the identifier of the fate. </summary>
        ///
        /// <value> The identifier of the fate. </value>

        UInt16 FateID { get; }

        /// <summary>   Gets or sets the gathering invs. </summary>
        ///
        /// <value> The gathering invs. </value>

        byte GatheringInvs { get; set; }

        /// <summary>   Gets or sets the camera glide. </summary>
        ///
        /// <value> The camera glide. </value>

        float CamGlide { get; set; }

        /// <summary>   Gets or sets the static camera glide. </summary>
        ///
        /// <value> The static camera glide. </value>

        float StaticCamGlide { get; set; }

        /// <summary>   Gets or sets the status. </summary>
        ///
        /// <value> The status. </value>

        byte Status { get; set; }

        /// <summary>   Gets or sets the is gm. </summary>
        ///
        /// <value> The is gm. </value>

        byte IsGM { get; set; }

        /// <summary>   Gets or sets the icon. </summary>
        ///
        /// <value> The icon. </value>

        byte Icon { get; set; }

        /// <summary>   Gets or sets the is engadged. </summary>
        ///
        /// <value> The is engadged. </value>

        byte IsEngadged { get; set; }

        /// <summary>   Gets the is moving. </summary>
        ///
        /// <value> The is moving. </value>

        Int32 IsMoving { get; }

        /// <summary>   Gets or sets the time traveled. </summary>
        ///
        /// <value> The time traveled. </value>

        float TimeTraveled { get; set; }

        /// <summary>   Gets or sets the identifier of the target. </summary>
        ///
        /// <value> The identifier of the target. </value>

        UInt32 TargetID { get; set; }

        /// <summary>   Gets or sets the current job. </summary>
        ///
        /// <value> The current job. </value>

        byte CurrentJob { get; set; }

        /// <summary>   Gets or sets the current level. </summary>
        ///
        /// <value> The current level. </value>

        byte CurrentLevel { get; set; }

        /// <summary>   Gets or sets the current GC. </summary>
        ///
        /// <value> The current GC. </value>

        byte CurrentGC { get; set; }

        /// <summary>   Gets or sets the GC rank. </summary>
        ///
        /// <value> The GC rank. </value>

        byte GCRank { get; set; }

        /// <summary>   Gets or sets the hp. </summary>
        ///
        /// <value> The hp. </value>

        Int32 HP { get; set; }

        /// <summary>   Gets or sets the maximum hp. </summary>
        ///
        /// <value> The maximum hp. </value>

        Int32 MaxHP { get; set; }

        /// <summary>   Gets or sets the mp. </summary>
        ///
        /// <value> The mp. </value>

        Int32 MP { get; set; }

        /// <summary>   Gets or sets the maximum mp. </summary>
        ///
        /// <value> The maximum mp. </value>

        Int32 MaxMP { get; set; }

        /// <summary>   Gets or sets the TP. </summary>
        ///
        /// <value> The TP. </value>

        Int16 TP { get; set; }

        /// <summary>   Gets or sets the gp. </summary>
        ///
        /// <value> The gp. </value>

        Int16 GP { get; set; }

        /// <summary>   Gets or sets the unknown points. </summary>
        ///
        /// <value> The unknown points. </value>

        Int16 UnknownPoints { get; set; }

        /// <summary>   Gets or sets the cp. </summary>
        ///
        /// <value> The cp. </value>

        Int16 CP { get; set; }

        /// <summary>   Gets or sets the maximum cp. </summary>
        ///
        /// <value> The maximum cp. </value>

        Int16 MaxCP { get; set; }

    }
}
