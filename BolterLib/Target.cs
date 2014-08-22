// file:	Target.cs
//
// summary:	Implements the target class

using System;
using System.Runtime.InteropServices;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A target. </summary>
    ///
    

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Target : ITarget
    {
        /// <summary>   The structure base. </summary>
        private readonly IntPtr StructBase;

        /// <summary>   Default constructor. </summary>
        ///
        

        public Target()
        {
            StructBase = Funcs.GetTargetStruct();
        }

        /// <summary>   Gets or sets the identifier of the targeted entity. </summary>
        ///
        /// <value> The identifier of the targeted entity. </value>

        public Int32 TargetedEntityID
        {
            
            get { return Marshal.ReadInt32(StructBase, 0x88); }
            
            set { Marshal.WriteInt32(StructBase, 0x88, value); }
        }

        /// <summary>   Gets or sets the identifier of the last targeted entity. </summary>
        ///
        /// <value> The identifier of the last targeted entity. </value>

        public Int32 LastTargetedEntityID
        {
            
            get { return Marshal.ReadInt32(StructBase, 0xE0); }
            
            set { Marshal.WriteInt32(StructBase, 0xE0, value); }
        }

        /// <summary>   Gets or sets the status. </summary>
        ///
        /// <value> The status. </value>

        public TargetStatus Status
        {
            
            get { return (TargetStatus)Marshal.PtrToStructure<uint>(StructBase + 0xE0); }
            
            set { Marshal.StructureToPtr((uint)value, StructBase + 0xE0, false); }
        }
    }

}
