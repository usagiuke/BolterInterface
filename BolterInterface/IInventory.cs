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
    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IInventory
    {
        IList ItemsInBag { get; }
 
    }

    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IItem
    {
        byte IndexInBag { get; }
        byte IndexInBlock { get; }
        byte BlockIndex { get; }
        UInt16 ItemID { get; }
        UInt16 Quantity { get; }
        string Name { get; }
        string Signature { get; }

    }
}
