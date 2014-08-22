// file:	ITarget.cs
//
// summary:	Declares the ITarget interface

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace BolterInterface
{
    /// <summary>   Interface for target. </summary>
    ///


    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface ITarget
    {
        /// <summary>   Gets or sets the identifier of the targeted entity. </summary>
        ///
        /// <value> The identifier of the targeted entity. </value>

        Int32 TargetedEntityID { get; set; }

        /// <summary>   Gets or sets the identifier of the last targeted entity. </summary>
        ///
        /// <value> The identifier of the last targeted entity. </value>

        Int32 LastTargetedEntityID { get; set; }

        /// <summary>   Gets or sets the status. </summary>
        ///
        /// <value> The status. </value>

        TargetStatus Status { get; set; }
    }
}
