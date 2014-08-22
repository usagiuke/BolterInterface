using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BolterInterface
{
    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface INaviMap
    {
        float UISizeMultiplier { get; set; }
        float Zoom { get; set; }
        int XCord { get; }
        int YCord { get; }
    }
}
