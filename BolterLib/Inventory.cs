using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using BolterInterface;

namespace BolterLib
{
    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Inventory : IInventory
    {
        public Inventory()
        {
            ItemsInBag = new List<IItem>();
            for (byte x = 0, bi = 0, i = 0; x < 100; x++)
            {
                ItemsInBag.Add(new Item(bi, i));
                i++;
                if (i != 25) continue;
                bi++;
                i = 0;
            }
        }

        public IList ItemsInBag { get; private set; }
    }

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Item : IItem
    {
        public Item(byte blockIndex, byte itemIndex)
        {
            BlockIndex = blockIndex;
            IndexInBlock = itemIndex;
            IndexInBag = (byte)((blockIndex*25)+itemIndex);
        }
        public byte IndexInBag { get; private set; }
        public byte IndexInBlock { get; private set; }
        public byte BlockIndex { get; private set; }
        public ushort ItemID 
        {
            get { return Marshal.PtrToStructure<ushort>(Funcs.GetInventoryObject(BlockIndex, IndexInBlock) + 8); }
        }

        public ushort Quantity
        {
            get { return Marshal.PtrToStructure<ushort>(Funcs.GetInventoryObject(BlockIndex, IndexInBlock) + 12); }
        }

        public string Name
        {
            get
            {
                try
                {
                    return ((Dictionary<int, string>) Bolter.GlobalInterface.GlobalResources.Items)[ItemID];
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public string Signature
        {
            get
            {
                var sig = Marshal.ReadInt64(Funcs.GetInventoryObject(BlockIndex, IndexInBlock) + 24);
                return sig == 0 ? String.Empty : Marshal.PtrToStringAnsi(Funcs.GetItemSignature(sig));
            }
        }
    }
}
