// file:	HostAdapter.cs
//
// summary:	Implements the host adapter class

using System;
using System.Runtime.InteropServices;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   Host interface exchange delegate. </summary>
    ///
    
    ///
    /// <returns>   An IBolterInterface. </returns>

    public delegate IBolterInterface HostInterfaceExchangeDelegate();

    /// <summary>   A host adapter. </summary>
    ///
    

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class HostAdapter
    {

        /// <summary>   The host interface exchange. </summary>
        public static HostInterfaceExchangeDelegate HostInterfaceExchange;
        /// <summary>   The bolter host interface. </summary>
        public static IBolterInterface BolterHostInterface;
        /// <summary>   The host interface exchange pointer. </summary>
        public static IntPtr HostInterfaceExchangePtr;

        /// <summary>   Default constructor. </summary>
        ///
        

        public HostAdapter()
        {
            BolterHostInterface = new BolterInterface();
            HostInterfaceExchange = InterfaceExchange;
            HostInterfaceExchangePtr = Marshal.GetFunctionPointerForDelegate(HostInterfaceExchange);
        }

        /// <summary>   Interface exchange. </summary>
        ///
        
        ///
        /// <returns>   An IBolterInterface. </returns>

        public IBolterInterface InterfaceExchange()
        {
            return BolterHostInterface;
        }
    }
}
