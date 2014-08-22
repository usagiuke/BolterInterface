// file:	ICommandEventHandler.cs
//
// summary:	Declares the ICommandEventHandler interface

using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace BolterInterface
{
    /// <summary>   Executes the command delegate action. </summary>
    ///
    /// <remarks>   Revy, 8/11/2014. </remarks>
    ///
    /// <param name="pCommand" type="StringBuilder">    The command. </param>
    ///
    /// <returns>   An int. </returns>

    public delegate int OnCommandDelegate(StringBuilder pCommand);

    /// <summary>   Interface for command event handler. </summary>
    ///
    /// <remarks>   Revy, 8/11/2014. </remarks>

    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface ICommandEventHandler
    {
        /// <summary>   Gets or sets the on command. </summary>
        ///
        /// <value> The on command. </value>

        IntPtr OnCommand { get; set; }
    }
}
