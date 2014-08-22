using System.Runtime.InteropServices;
using System.Security;

namespace BolterInterface
{
    /// <summary>   Interface for game calls. </summary>
    ///

    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IGameCalls
    {
        /// <summary>   Gather item. </summary>
        ///
        /// <param name="ItemID" type="uint">   Identifier for the item. </param>
        ///
        /// <returns>   An int. </returns>

        int GatherItem(uint ItemID);

        /// <summary>   Sends a command. </summary>
        ///
        /// <param name="command" type="string">    The command. </param>

        void SendCommand(string command);

        /// <summary>   Trigger hot bar. </summary>
        ///
        /// <param name="barIndex" type="int">  Zero-based index of the bar. </param>
        /// <param name="slotIndex" type="int"> Zero-based index of the slot. </param>
        ///
        /// <returns>   A byte. </returns>

        byte TriggerHotBar(int barIndex, int slotIndex);

        int OpenMenu(MenuType mType);

        bool IsMenuOpen(MenuType mType);

    }
}
