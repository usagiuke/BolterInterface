// file:	Gather.cs
//
// summary:	Implements the gather class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A gather. </summary>
    ///


    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Gather : IGather
    {
        /// <summary>   Searches for the first closest node. </summary>
        ///
        
        ///
        /// <param name="nodeType" type="GatheringNode">    Type of the node. </param>
        ///
        /// <returns>
        ///     The zero-based index of the found closest node, or -1 if no match was found.
        /// </returns>

        public int IndexOfClosestNode(GatheringNode nodeType)
        {
            return Funcs.GetIndexOfClosestNode(nodeType);
        }
    }
}
