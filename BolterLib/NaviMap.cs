using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using BolterInterface;

namespace BolterLib
{
    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class NaviMap : INaviMap
    {
        public float UISizeMultiplier 
        {
            
            get { return Marshal.PtrToStructure<float>(Funcs.GetNaviMapPtr() + NaviMapOffsets.UISizeMultiplier); }
            
            set { Marshal.StructureToPtr(value, Funcs.GetNaviMapPtr() + NaviMapOffsets.UISizeMultiplier, false); }
        }

        public float Zoom
        {
            
            get { return Marshal.PtrToStructure<float>(Funcs.GetNaviMapPtr() + NaviMapOffsets.Zoom); }
            
            set { Marshal.StructureToPtr(value, Funcs.GetNaviMapPtr() + NaviMapOffsets.Zoom, false); }
        }

        public int XCord
        {
            
            get { return Marshal.ReadInt32(Funcs.GetNaviMapPtr() + NaviMapOffsets.XCord); }
        }
        public int YCord
        {
            
            get { return Marshal.ReadInt32(Funcs.GetNaviMapPtr() + NaviMapOffsets.YCord); }
        }
    }
}
