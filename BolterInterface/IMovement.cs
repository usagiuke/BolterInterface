// file:	IMovement.cs
//
// summary:	Declares the IMovement interface

using System.Runtime.InteropServices;
using System.Security;

namespace BolterInterface
{
    /// <summary>   Interface for movement. </summary>
    ///


    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IMovement
    {
        /// <summary>   Gets or sets a value indicating whether the walk left. </summary>
        ///
        /// <value> true if walk left, false if not. </value>

        bool WalkLeft { get; set; }

        /// <summary>   Gets or sets a value indicating whether the walk right. </summary>
        ///
        /// <value> true if walk right, false if not. </value>

        bool WalkRight { get; set; }

        /// <summary>   Gets or sets a value indicating whether the walk back. </summary>
        ///
        /// <value> true if walk back, false if not. </value>

        bool WalkBack { get; set; }

        /// <summary>   Gets or sets a value indicating whether the walk forward. </summary>
        ///
        /// <value> true if walk forward, false if not. </value>

        bool WalkForward { get; set; }

        /// <summary>   Gets or sets a value indicating whether the strafe left. </summary>
        ///
        /// <value> true if strafe left, false if not. </value>

        bool StrafeLeft { get; set; }

        /// <summary>   Gets or sets a value indicating whether the strafe right. </summary>
        ///
        /// <value> true if strafe right, false if not. </value>

        bool StrafeRight { get; set; }

        /// <summary>   Gets the current speed. </summary>
        ///
        /// <value> The current speed. </value>

        float CurrentSpeed { get; }

        /// <summary>   Gets or sets the forward speed. </summary>
        ///
        /// <value> The forward speed. </value>

        float ForwardSpeed { get; set; }

        /// <summary>   Gets or sets the left right speed. </summary>
        ///
        /// <value> The left right speed. </value>

        float LeftRightSpeed { get; set; }

        /// <summary>   Gets or sets the backward speed. </summary>
        ///
        /// <value> The backward speed. </value>

        float BackwardSpeed { get; set; }

        /// <summary>   Gets or sets the forward speed weapon drawn. </summary>
        ///
        /// <value> The forward speed weapon drawn. </value>

        float ForwardSpeedWeaponDrawn { get; set; }

        /// <summary>   Gets or sets the left right speed weapon drawn. </summary>
        ///
        /// <value> The left right speed weapon drawn. </value>

        float LeftRightSpeedWeaponDrawn { get; set; }

        /// <summary>   Gets or sets the backward speed weapon drawn. </summary>
        ///
        /// <value> The backward speed weapon drawn. </value>

        float BackwardSpeedWeaponDrawn { get; set; }

        /// <summary>   Gets or sets the status. </summary>
        ///
        /// <value> The status. </value>

        WalkingStatus Status { get; set; }
    }
}
