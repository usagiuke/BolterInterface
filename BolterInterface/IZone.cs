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
    public interface IZone
    {
        string CurrentZoneName { get; }
        int CurrentZoneID { get; }
        Weather CurrentWeather { get; set; }
        string GetZoneNameFromID(int ID);
        int GetZoneIDFromName(string name);
    }
}
