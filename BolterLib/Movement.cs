// file:	Movement.cs
//
// summary:	Implements the movement class

using System;
using System.Runtime.InteropServices;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A movement. </summary>
    ///
    

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Movement : IMovement
    {

        /// <summary>   The structure base. </summary>
        private readonly IntPtr StructBase;

        /// <summary>   Default constructor. </summary>
        ///
        

        public Movement()
        {
            StructBase = Funcs.GetMovementPtr();
        }

        /// <summary>   Gets or sets a value indicating whether the walk left. </summary>
        ///
        /// <value> true if walk left, false if not. </value>

        public bool WalkLeft
        {
            
            get { return Marshal.ReadByte(StructBase, MovementStruct.WalkLeft) == 1; }
            
            set { Marshal.WriteByte(StructBase, MovementStruct.WalkLeft, value ? (byte)1 : (byte)0); }
        }

        /// <summary>   Gets or sets a value indicating whether the walk right. </summary>
        ///
        /// <value> true if walk right, false if not. </value>

        public bool WalkRight
        {
            
            get { return Marshal.ReadByte(StructBase, MovementStruct.WalkRight) == 1; }
            
            set { Marshal.WriteByte(StructBase, MovementStruct.WalkRight, value ? (byte)1 : (byte)0); }
        }

        /// <summary>   Gets or sets a value indicating whether the walk back. </summary>
        ///
        /// <value> true if walk back, false if not. </value>

        public bool WalkBack
        {
            
            get { return Marshal.ReadByte(StructBase, MovementStruct.WalkBack) == 1; }
            
            set { Marshal.WriteByte(StructBase, MovementStruct.WalkBack, value ? (byte)1 : (byte)0); }
        }

        /// <summary>   Gets or sets a value indicating whether the walk forward. </summary>
        ///
        /// <value> true if walk forward, false if not. </value>

        public bool WalkForward
        {
            
            get { return Marshal.ReadByte(StructBase, MovementStruct.WalkForward) == 1; }
            
            set { Marshal.WriteByte(StructBase, MovementStruct.WalkForward, value ? (byte)1 : (byte)0); }
        }

        /// <summary>   Gets or sets a value indicating whether the strafe left. </summary>
        ///
        /// <value> true if strafe left, false if not. </value>

        public bool StrafeLeft
        {
            
            get { return Marshal.ReadByte(StructBase, MovementStruct.StrafeLeft) == 1; }
            
            set { Marshal.WriteByte(StructBase, MovementStruct.StrafeLeft, value ? (byte)1 : (byte)0); }
        }

        /// <summary>   Gets or sets a value indicating whether the strafe right. </summary>
        ///
        /// <value> true if strafe right, false if not. </value>

        public bool StrafeRight
        {
            
            get { return Marshal.ReadByte(StructBase, MovementStruct.StrafeRight) == 1; }
            
            set { Marshal.WriteByte(StructBase, MovementStruct.StrafeRight, value ? (byte)1 : (byte)0); }
        }

        /// <summary>   Gets the current speed. </summary>
        ///
        /// <value> The current speed. </value>

        public float CurrentSpeed
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + MovementStruct.CurrentSpeed, typeof(float)); }
        }

        /// <summary>   Gets or sets the forward speed. </summary>
        ///
        /// <value> The forward speed. </value>

        public float ForwardSpeed
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + MovementStruct.FowardSpeed, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + MovementStruct.FowardSpeed, false); }
        }

        /// <summary>   Gets or sets the left right speed. </summary>
        ///
        /// <value> The left right speed. </value>

        public float LeftRightSpeed
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + MovementStruct.LeftRightSpeed, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + MovementStruct.LeftRightSpeed, false); }
        }

        /// <summary>   Gets or sets the backward speed. </summary>
        ///
        /// <value> The backward speed. </value>

        public float BackwardSpeed
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + MovementStruct.BackwardSpeed, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + MovementStruct.BackwardSpeed, false); }
        }

        /// <summary>   Gets or sets the forward speed. </summary>
        ///
        /// <value> The forward speed. </value>

        public float ForwardSpeedWeaponDrawn
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + MovementStruct.ForwardSpeedWeaponDrawn, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + MovementStruct.ForwardSpeedWeaponDrawn, false); }
        }

        /// <summary>   Gets or sets the left right speed. </summary>
        ///
        /// <value> The left right speed. </value>

        public float LeftRightSpeedWeaponDrawn
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + MovementStruct.LeftRightSpeedWeaponDrawn, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + MovementStruct.LeftRightSpeedWeaponDrawn, false); }
        }

        /// <summary>   Gets or sets the backward speed. </summary>
        ///
        /// <value> The backward speed. </value>

        public float BackwardSpeedWeaponDrawn
        {
            
            get { return (float)Marshal.PtrToStructure(StructBase + MovementStruct.BackwardSpeedWeaponDrawn, typeof(float)); }
            
            set { Marshal.StructureToPtr(value, StructBase + MovementStruct.BackwardSpeedWeaponDrawn, false); }
        }

        /// <summary>   Gets or sets the status. </summary>
        ///
        /// <value> The status. </value>

        public WalkingStatus Status
        {
            
            get { return Funcs.GetMoveStatus(); }
            
            set { Funcs.SetMoveStatus(value); }
        }
    }
}
