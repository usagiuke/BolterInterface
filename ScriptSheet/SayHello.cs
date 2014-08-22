//Ref System.dll
//Ref System.Core.dll
//Ref C:\Users\Khimaira\Desktop\Bolterv3 Alpha\Plugins\BolterInterface.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using BolterInterface;

[ScriptEntryClass]
public class CamORama
{
    public IInventory Inv;
    public IList<IItem> InvItems;
    public IGameCalls GameCall;
    // This gets invoked when the script is loaded.
    [ScriptEntryPoint]
    public CamORama()
    {
        try
        {
            Inv = Bolter.GlobalInterface.GlobalInventory;
            InvItems = Inv.ItemsInBag.Cast<IItem>().ToList();
            GameCall = Bolter.GlobalInterface.GameCalls;
            GameCall.SendCommand("/echo " + (InvItems == null));
            GameCall.SendCommand("/echo " + InvItems[1].Name);
        }
        catch(Exception e)
        {
            File.WriteAllText("error.txt", e.ToString());
        }
    }

    // This gets called every time a command is sent in-game. 
    // Returning 1 will keep the command within the script. 
    // Returning 0 will pass the command back to the game's command handler.
    public int OnNewChatLine(StringBuilder pCommand)
    {
        // Check if the command starts with "/craftderp".
        if (pCommand.ToString().Contains("itemtell"))
        {
           // new Thread(delegate()
           // {
                GameCall.SendCommand("/echo hi1");
                Marshal.WriteByte(IntPtr.Zero, 0);
                GameCall.SendCommand("/echo hi2");
            //}).Start();
            
            return 1;
        }
        // So let's return 0, so the game can handle it.
        return 0;
    }
}