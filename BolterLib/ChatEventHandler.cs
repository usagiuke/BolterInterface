// file:	ChatEventHandler.cs
//
// summary:	Implements the chat event handler class

using System;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A chat event handler. </summary>
    ///
    /// <remarks>   Revy, 8/11/2014. </remarks>

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class ChatEventHandler : IChatEventHandler
    {
        /// <summary>   The function pointer. </summary>
        private IntPtr _funcPtr;

        /// <summary>   Gets or sets the on chat line. </summary>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <value> The on chat line. </value>

        public IntPtr OnChatLine
        {
            get { return _funcPtr; }
            [SecuritySafeCritical]
            set
            {
                if (_funcPtr == default(IntPtr))
                {
                    _funcPtr = value;
                    Funcs.RegisterChatEvent(_funcPtr);

                }
                else if (value == IntPtr.Zero)
                {
                    Funcs.UnRegisterChatEvent(_funcPtr);
                }
                else
                    throw new Exception("Tried to set event twice");
            }
        }
    }
}
