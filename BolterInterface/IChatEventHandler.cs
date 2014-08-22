// file:	IChatEventHandler.cs
//
// summary:	Declares the IChatEventHandler interface

using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace BolterInterface
{
    /// <summary>   Executes the new chat line delegate action. </summary>
    ///
    /// <remarks>   Revy, 8/11/2014. </remarks>
    ///
    /// <param name="pChatLine" type="StringBuilder">   The chat line. </param>
    ///
    /// <returns>   An int. </returns>

    public delegate int OnNewChatLineDelegate(StringBuilder pChatLine);

    /// <summary>   Interface for chat event handler. </summary>
    ///
    /// <remarks>   Revy, 8/11/2014. </remarks>

    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IChatEventHandler
    {
        /// <summary>   Gets or sets the on chat line. </summary>
        ///
        /// <value> The on chat line. </value>

        IntPtr OnChatLine { get; set; }
    }
}
