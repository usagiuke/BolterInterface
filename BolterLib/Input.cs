// file:	Input.cs
//
// summary:	Implements the input class

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   An input. </summary>
    ///


    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Input : IInput
    {
        /// <summary>   Sends a key press. </summary>
        ///
        
        ///
        /// <param name="state" type="KeyStates">   The state. </param>
        /// <param name="key" type="Key">           The key. </param>

        
        public void SendKeyPress(KeyStates state, Key key)
        {

            if (state != KeyStates.Toggled)
            {
                if (PostMessage(
                    hWnd: _ffxivHWnd,
                    Msg: state == KeyStates.Down ? 0x100u : 0x101u,
                    wParam: (IntPtr)KeyInterop.VirtualKeyFromKey(key),
                    lParam: state == KeyStates.Down ? (UIntPtr)0x00500001 : (UIntPtr)0xC0500001)) return;
                Console.WriteLine(ErrorCode);
                return;
            }
            if (!PostMessage(
                    hWnd: _ffxivHWnd,
                    Msg: 0x100u,
                    wParam: (IntPtr)KeyInterop.VirtualKeyFromKey(key),
                    lParam: (UIntPtr)0x00500001))
            {
                Console.WriteLine(ErrorCode);
                return;
            }
            Thread.Sleep(1);
            if (!PostMessage(
                hWnd: _ffxivHWnd,
                Msg: 0x101u,
                wParam: (IntPtr)KeyInterop.VirtualKeyFromKey(key),
                lParam: (UIntPtr)0xC0500001))
                Console.WriteLine(ErrorCode);
        }

        /// <summary>   Default constructor. </summary>
        ///
        

        public Input()
        {
            EnumWindows(EnumTheWindows, IntPtr.Zero);
            _ffxivHWnd = Hwnd;
        }

        /// <summary>   The ffxiv h window. </summary>
        private readonly IntPtr _ffxivHWnd;

        /// <summary>   Gets the error code. </summary>
        ///
        /// <value> The error code. </value>

        private string ErrorCode
        {
            get { return string.Format("PostMessage Error {0:X8}", Marshal.GetLastWin32Error()); }
        }

        /// <summary>   The. </summary>
        private static IntPtr Hwnd;

        /// <summary>   Enum windows proc. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="hWnd">     The window. </param>
        /// <param name="lParam">   The parameter. </param>
        ///
        /// <returns>   A bool. </returns>

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>   Posts a message. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="hWnd">     The window. </param>
        /// <param name="Msg">      The message. </param>
        /// <param name="wParam">   The parameter. </param>
        /// <param name="lParam">   The parameter. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, UIntPtr lParam);

        /// <summary>   Gets window thread process identifier. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="hWnd">             The window. </param>
        /// <param name="lpdwProcessId">    [out] Identifier for the lpdw process. </param>
        ///
        /// <returns>   The window thread process identifier. </returns>

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        /// <summary>   Searches for the first window. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="lpClassName">  Name of the class. </param>
        /// <param name="lpWindowName"> Name of the window. </param>
        ///
        /// <returns>   The found window. </returns>

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>   Gets window text. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="hWnd">     The window. </param>
        /// <param name="strText">  The text. </param>
        /// <param name="maxCount"> Number of maximums. </param>
        ///
        /// <returns>   The window text. </returns>

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        /// <summary>   Gets window text length. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="hWnd"> The window. </param>
        ///
        /// <returns>   The window text length. </returns>

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>   Enum windows. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="enumProc"> The enum proc. </param>
        /// <param name="lParam">   The parameter. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        /// <summary>   Query if 'hWnd' is window visible. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="hWnd"> The window. </param>
        ///
        /// <returns>   true if window visible, false if not. </returns>

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>   Enum the windows. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="hWnd">     The window. </param>
        /// <param name="lParam">   The parameter. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        
        private bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            var size = GetWindowTextLength(hWnd);

            if (size++ <= 0 || !IsWindowVisible(hWnd)) return true;

            var sb = new StringBuilder(size);

            GetWindowText(hWnd, sb, size);

            if (sb.ToString() != "FINAL FANTASY XIV: A Realm Reborn") return true;

            uint PID;

            GetWindowThreadProcessId(hWnd, out PID);

            if (PID == Process.GetCurrentProcess().Id)
                Hwnd = hWnd;
            return true;
        }

    }
}

