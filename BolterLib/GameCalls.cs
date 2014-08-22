using System;
using System.Runtime.InteropServices;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A game calls. </summary>
    ///
    

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class GameCalls : IGameCalls
    {
        /// <summary>   Gather item. </summary>
        ///
        
        ///
        /// <param name="ItemID" type="uint">   Identifier for the item. </param>
        ///
        /// <returns>   An int. </returns>

        public int GatherItem(uint ItemID)
        {
            return Funcs.MyGatherInvoke(ItemID);
        }

        /// <summary>   Sends a command. </summary>
        ///
        
        ///
        /// <param name="command" type="string">    The command. </param>

        public void SendCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return;
            var pCommand = Marshal.StringToHGlobalAnsi(command);
            Funcs.SendCommand(pCommand);
            try
            {
                Marshal.FreeHGlobal(pCommand);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>   Trigger hot bar. </summary>
        ///
        
        ///
        /// <param name="barIndex" type="int">  Zero-based index of the bar. </param>
        /// <param name="slotIndex" type="int"> Zero-based index of the slot. </param>
        ///
        /// <returns>   A byte. </returns>

        public byte TriggerHotBar(int barIndex, int slotIndex)
        {
            return Funcs.InvokeHotBar(barIndex, slotIndex);
        }

        public int OpenMenu(MenuType mType)
        {
            return Funcs.OpenMenu(mType);
        }

        public bool IsMenuOpen(MenuType mType)
        {
            return Funcs.IsMenuOpen(mType);
        }
    }
}
