using System.Runtime.InteropServices;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Zone : IZone
    {

        public string CurrentZoneName 
        {
            get { return Funcs.GetZoneName(); }
        }

        public int CurrentZoneID
        {
            get { return Funcs.GetZoneId(); }
        }

        public Weather CurrentWeather
        {
            get { return Marshal.PtrToStructure<Weather>(Funcs.GetWeatherPtr()); }
            set { Marshal.StructureToPtr(value, Funcs.GetWeatherPtr(), false); } 
        }
        public string GetZoneNameFromID(int ID)
        {
            return Funcs.GetZoneNameFromID(ID);
        }
        public int GetZoneIDFromName(string name)
        {
            return Funcs.GetZoneIDFromName(name);
        }
    }
}
