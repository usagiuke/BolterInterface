// file:	CommandEventHandler.cs
//
// summary:	Implements the command event handler class

using System;
using System.Security;
using System.Text;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A command event handler. </summary>
    ///
    /// <remarks>   Revy, 8/11/2014. </remarks>

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class CommandEventHandler : ICommandEventHandler
    {

        /// <summary>   The function pointer. </summary>
        private IntPtr _funcPtr;

        //private Func<StringBuilder, int> _onCommandEvent;

        /// <summary>   Gets or sets the on command. </summary>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <value> The on command. </value>

        public IntPtr OnCommand
        {
            get { return _funcPtr; }
            [SecuritySafeCritical]
            set
            {
                if (_funcPtr == default(IntPtr))
                {
                    if (value == IntPtr.Zero)
                        return;
                    _funcPtr = value;
                    Funcs.RegisterCommandEvent(_funcPtr);
                }
                else if (value == IntPtr.Zero)
                {
                    Funcs.UnRegisterCommandEvent(_funcPtr);
                }
                else
                    throw new Exception("Tried to set event twice");
            }
        }
    }
}
