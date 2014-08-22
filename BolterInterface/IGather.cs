// file:	IGather.cs
//
// summary:	Declares the IGather interface

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BolterInterface
{
    /// <summary>   Interface for gather. </summary>
    ///


    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IGather
    {
        /// <summary>   Searches for the first closest node. </summary>
        ///
        /// <param name="nodeType" type="GatheringNode">    Type of the node. </param>
        ///
        /// <returns>
        ///     The zero-based index of the found closest node, or -1 if no match was found.
        /// </returns>

        int IndexOfClosestNode(GatheringNode nodeType);
    }
}
