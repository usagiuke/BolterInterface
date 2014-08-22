// file:	IResources.cs
//
// summary:	Declares the IResources interface

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BolterInterface
{
    /// <summary>   Interface for resources. </summary>
    ///


    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IResources
    {
        /// <summary>   Gets the items. </summary>
        ///
        /// <value> The items. </value>

        IDictionary Items { get; }
    }
}
