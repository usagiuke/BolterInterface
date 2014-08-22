// file:	IInput.cs
//
// summary:	Declares the IInput interface

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace BolterInterface
{
    /// <summary>   Interface for input. </summary>
    ///


    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IInput
    {
        /// <summary>   Sends a key press. </summary>
        ///
        /// <param name="state" type="KeyStates">   The state. </param>
        /// <param name="key" type="Key">           The key. </param>

        void SendKeyPress(KeyStates state, Key key);
    }

    #region Stuff

    /// <summary>   Bitfield of flags for specifying KeyStates. </summary>
    ///
    

    [Flags]
    public enum KeyStates : byte
    {
        /// <summary>   A binary constant representing the none flag. </summary>
        None = 0,
        /// <summary>   A binary constant representing the down flag. </summary>
        Down = 1,
        /// <summary>   A binary constant representing the toggled flag. </summary>
        Toggled = 2,
    }

    /// <summary>   A key interop. </summary>
    ///
    

    public static class KeyInterop
    {
        /// <summary>   Key from virtual key. </summary>
        ///
        
        ///
        /// <param name="virtualKey" type="int">    The virtual key. </param>
        ///
        /// <returns>   A Key. </returns>

        public static Key KeyFromVirtualKey(int virtualKey)
        {
            Key key;
            switch (virtualKey)
            {
                case 3:
                    key = Key.Cancel;
                    break;
                case 8:
                    key = Key.Back;
                    break;
                case 9:
                    key = Key.Tab;
                    break;
                case 12:
                    key = Key.Clear;
                    break;
                case 13:
                    key = Key.Return;
                    break;
                case 16:
                case 160:
                    key = Key.LeftShift;
                    break;
                case 17:
                case 162:
                    key = Key.LeftCtrl;
                    break;
                case 18:
                case 164:
                    key = Key.LeftAlt;
                    break;
                case 19:
                    key = Key.Pause;
                    break;
                case 20:
                    key = Key.Capital;
                    break;
                case 21:
                    key = Key.KanaMode;
                    break;
                case 23:
                    key = Key.JunjaMode;
                    break;
                case 24:
                    key = Key.FinalMode;
                    break;
                case 25:
                    key = Key.HanjaMode;
                    break;
                case 27:
                    key = Key.Escape;
                    break;
                case 28:
                    key = Key.ImeConvert;
                    break;
                case 29:
                    key = Key.ImeNonConvert;
                    break;
                case 30:
                    key = Key.ImeAccept;
                    break;
                case 31:
                    key = Key.ImeModeChange;
                    break;
                case 32:
                    key = Key.Space;
                    break;
                case 33:
                    key = Key.Prior;
                    break;
                case 34:
                    key = Key.Next;
                    break;
                case 35:
                    key = Key.End;
                    break;
                case 36:
                    key = Key.Home;
                    break;
                case 37:
                    key = Key.Left;
                    break;
                case 38:
                    key = Key.Up;
                    break;
                case 39:
                    key = Key.Right;
                    break;
                case 40:
                    key = Key.Down;
                    break;
                case 41:
                    key = Key.Select;
                    break;
                case 42:
                    key = Key.Print;
                    break;
                case 43:
                    key = Key.Execute;
                    break;
                case 44:
                    key = Key.Snapshot;
                    break;
                case 45:
                    key = Key.Insert;
                    break;
                case 46:
                    key = Key.Delete;
                    break;
                case 47:
                    key = Key.Help;
                    break;
                case 48:
                    key = Key.D0;
                    break;
                case 49:
                    key = Key.D1;
                    break;
                case 50:
                    key = Key.D2;
                    break;
                case 51:
                    key = Key.D3;
                    break;
                case 52:
                    key = Key.D4;
                    break;
                case 53:
                    key = Key.D5;
                    break;
                case 54:
                    key = Key.D6;
                    break;
                case 55:
                    key = Key.D7;
                    break;
                case 56:
                    key = Key.D8;
                    break;
                case 57:
                    key = Key.D9;
                    break;
                case 65:
                    key = Key.A;
                    break;
                case 66:
                    key = Key.B;
                    break;
                case 67:
                    key = Key.C;
                    break;
                case 68:
                    key = Key.D;
                    break;
                case 69:
                    key = Key.E;
                    break;
                case 70:
                    key = Key.F;
                    break;
                case 71:
                    key = Key.G;
                    break;
                case 72:
                    key = Key.H;
                    break;
                case 73:
                    key = Key.I;
                    break;
                case 74:
                    key = Key.J;
                    break;
                case 75:
                    key = Key.K;
                    break;
                case 76:
                    key = Key.L;
                    break;
                case 77:
                    key = Key.M;
                    break;
                case 78:
                    key = Key.N;
                    break;
                case 79:
                    key = Key.O;
                    break;
                case 80:
                    key = Key.P;
                    break;
                case 81:
                    key = Key.Q;
                    break;
                case 82:
                    key = Key.R;
                    break;
                case 83:
                    key = Key.S;
                    break;
                case 84:
                    key = Key.T;
                    break;
                case 85:
                    key = Key.U;
                    break;
                case 86:
                    key = Key.V;
                    break;
                case 87:
                    key = Key.W;
                    break;
                case 88:
                    key = Key.X;
                    break;
                case 89:
                    key = Key.Y;
                    break;
                case 90:
                    key = Key.Z;
                    break;
                case 91:
                    key = Key.LWin;
                    break;
                case 92:
                    key = Key.RWin;
                    break;
                case 93:
                    key = Key.Apps;
                    break;
                case 95:
                    key = Key.Sleep;
                    break;
                case 96:
                    key = Key.NumPad0;
                    break;
                case 97:
                    key = Key.NumPad1;
                    break;
                case 98:
                    key = Key.NumPad2;
                    break;
                case 99:
                    key = Key.NumPad3;
                    break;
                case 100:
                    key = Key.NumPad4;
                    break;
                case 101:
                    key = Key.NumPad5;
                    break;
                case 102:
                    key = Key.NumPad6;
                    break;
                case 103:
                    key = Key.NumPad7;
                    break;
                case 104:
                    key = Key.NumPad8;
                    break;
                case 105:
                    key = Key.NumPad9;
                    break;
                case 106:
                    key = Key.Multiply;
                    break;
                case 107:
                    key = Key.Add;
                    break;
                case 108:
                    key = Key.Separator;
                    break;
                case 109:
                    key = Key.Subtract;
                    break;
                case 110:
                    key = Key.Decimal;
                    break;
                case 111:
                    key = Key.Divide;
                    break;
                case 112:
                    key = Key.F1;
                    break;
                case 113:
                    key = Key.F2;
                    break;
                case 114:
                    key = Key.F3;
                    break;
                case 115:
                    key = Key.F4;
                    break;
                case 116:
                    key = Key.F5;
                    break;
                case 117:
                    key = Key.F6;
                    break;
                case 118:
                    key = Key.F7;
                    break;
                case 119:
                    key = Key.F8;
                    break;
                case 120:
                    key = Key.F9;
                    break;
                case 121:
                    key = Key.F10;
                    break;
                case 122:
                    key = Key.F11;
                    break;
                case 123:
                    key = Key.F12;
                    break;
                case 124:
                    key = Key.F13;
                    break;
                case 125:
                    key = Key.F14;
                    break;
                case 126:
                    key = Key.F15;
                    break;
                case sbyte.MaxValue:
                    key = Key.F16;
                    break;
                case 128:
                    key = Key.F17;
                    break;
                case 129:
                    key = Key.F18;
                    break;
                case 130:
                    key = Key.F19;
                    break;
                case 131:
                    key = Key.F20;
                    break;
                case 132:
                    key = Key.F21;
                    break;
                case 133:
                    key = Key.F22;
                    break;
                case 134:
                    key = Key.F23;
                    break;
                case 135:
                    key = Key.F24;
                    break;
                case 144:
                    key = Key.NumLock;
                    break;
                case 145:
                    key = Key.Scroll;
                    break;
                case 161:
                    key = Key.RightShift;
                    break;
                case 163:
                    key = Key.RightCtrl;
                    break;
                case 165:
                    key = Key.RightAlt;
                    break;
                case 166:
                    key = Key.BrowserBack;
                    break;
                case 167:
                    key = Key.BrowserForward;
                    break;
                case 168:
                    key = Key.BrowserRefresh;
                    break;
                case 169:
                    key = Key.BrowserStop;
                    break;
                case 170:
                    key = Key.BrowserSearch;
                    break;
                case 171:
                    key = Key.BrowserFavorites;
                    break;
                case 172:
                    key = Key.BrowserHome;
                    break;
                case 173:
                    key = Key.VolumeMute;
                    break;
                case 174:
                    key = Key.VolumeDown;
                    break;
                case 175:
                    key = Key.VolumeUp;
                    break;
                case 176:
                    key = Key.MediaNextTrack;
                    break;
                case 177:
                    key = Key.MediaPreviousTrack;
                    break;
                case 178:
                    key = Key.MediaStop;
                    break;
                case 179:
                    key = Key.MediaPlayPause;
                    break;
                case 180:
                    key = Key.LaunchMail;
                    break;
                case 181:
                    key = Key.SelectMedia;
                    break;
                case 182:
                    key = Key.LaunchApplication1;
                    break;
                case 183:
                    key = Key.LaunchApplication2;
                    break;
                case 186:
                    key = Key.Oem1;
                    break;
                case 187:
                    key = Key.OemPlus;
                    break;
                case 188:
                    key = Key.OemComma;
                    break;
                case 189:
                    key = Key.OemMinus;
                    break;
                case 190:
                    key = Key.OemPeriod;
                    break;
                case 191:
                    key = Key.Oem2;
                    break;
                case 192:
                    key = Key.Oem3;
                    break;
                case 193:
                    key = Key.AbntC1;
                    break;
                case 194:
                    key = Key.AbntC2;
                    break;
                case 219:
                    key = Key.Oem4;
                    break;
                case 220:
                    key = Key.Oem5;
                    break;
                case 221:
                    key = Key.Oem6;
                    break;
                case 222:
                    key = Key.Oem7;
                    break;
                case 223:
                    key = Key.Oem8;
                    break;
                case 226:
                    key = Key.Oem102;
                    break;
                case 229:
                    key = Key.ImeProcessed;
                    break;
                case 240:
                    key = Key.OemAttn;
                    break;
                case 241:
                    key = Key.OemFinish;
                    break;
                case 242:
                    key = Key.OemCopy;
                    break;
                case 243:
                    key = Key.OemAuto;
                    break;
                case 244:
                    key = Key.OemEnlw;
                    break;
                case 245:
                    key = Key.OemBackTab;
                    break;
                case 246:
                    key = Key.Attn;
                    break;
                case 247:
                    key = Key.CrSel;
                    break;
                case 248:
                    key = Key.ExSel;
                    break;
                case 249:
                    key = Key.EraseEof;
                    break;
                case 250:
                    key = Key.Play;
                    break;
                case 251:
                    key = Key.Zoom;
                    break;
                case 252:
                    key = Key.NoName;
                    break;
                case 253:
                    key = Key.Pa1;
                    break;
                case 254:
                    key = Key.OemClear;
                    break;
                default:
                    key = Key.None;
                    break;
            }
            return key;
        }

        /// <summary>   Virtual key from key. </summary>
        ///
        
        ///
        /// <param name="key" type="Key">   The key. </param>
        ///
        /// <returns>   An int. </returns>

        public static int VirtualKeyFromKey(Key key)
        {
            int num;
            switch (key)
            {
                case Key.Cancel:
                    num = 3;
                    break;
                case Key.Back:
                    num = 8;
                    break;
                case Key.Tab:
                    num = 9;
                    break;
                case Key.Clear:
                    num = 12;
                    break;
                case Key.Return:
                    num = 13;
                    break;
                case Key.Pause:
                    num = 19;
                    break;
                case Key.Capital:
                    num = 20;
                    break;
                case Key.KanaMode:
                    num = 21;
                    break;
                case Key.JunjaMode:
                    num = 23;
                    break;
                case Key.FinalMode:
                    num = 24;
                    break;
                case Key.HanjaMode:
                    num = 25;
                    break;
                case Key.Escape:
                    num = 27;
                    break;
                case Key.ImeConvert:
                    num = 28;
                    break;
                case Key.ImeNonConvert:
                    num = 29;
                    break;
                case Key.ImeAccept:
                    num = 30;
                    break;
                case Key.ImeModeChange:
                    num = 31;
                    break;
                case Key.Space:
                    num = 32;
                    break;
                case Key.Prior:
                    num = 33;
                    break;
                case Key.Next:
                    num = 34;
                    break;
                case Key.End:
                    num = 35;
                    break;
                case Key.Home:
                    num = 36;
                    break;
                case Key.Left:
                    num = 37;
                    break;
                case Key.Up:
                    num = 38;
                    break;
                case Key.Right:
                    num = 39;
                    break;
                case Key.Down:
                    num = 40;
                    break;
                case Key.Select:
                    num = 41;
                    break;
                case Key.Print:
                    num = 42;
                    break;
                case Key.Execute:
                    num = 43;
                    break;
                case Key.Snapshot:
                    num = 44;
                    break;
                case Key.Insert:
                    num = 45;
                    break;
                case Key.Delete:
                    num = 46;
                    break;
                case Key.Help:
                    num = 47;
                    break;
                case Key.D0:
                    num = 48;
                    break;
                case Key.D1:
                    num = 49;
                    break;
                case Key.D2:
                    num = 50;
                    break;
                case Key.D3:
                    num = 51;
                    break;
                case Key.D4:
                    num = 52;
                    break;
                case Key.D5:
                    num = 53;
                    break;
                case Key.D6:
                    num = 54;
                    break;
                case Key.D7:
                    num = 55;
                    break;
                case Key.D8:
                    num = 56;
                    break;
                case Key.D9:
                    num = 57;
                    break;
                case Key.A:
                    num = 65;
                    break;
                case Key.B:
                    num = 66;
                    break;
                case Key.C:
                    num = 67;
                    break;
                case Key.D:
                    num = 68;
                    break;
                case Key.E:
                    num = 69;
                    break;
                case Key.F:
                    num = 70;
                    break;
                case Key.G:
                    num = 71;
                    break;
                case Key.H:
                    num = 72;
                    break;
                case Key.I:
                    num = 73;
                    break;
                case Key.J:
                    num = 74;
                    break;
                case Key.K:
                    num = 75;
                    break;
                case Key.L:
                    num = 76;
                    break;
                case Key.M:
                    num = 77;
                    break;
                case Key.N:
                    num = 78;
                    break;
                case Key.O:
                    num = 79;
                    break;
                case Key.P:
                    num = 80;
                    break;
                case Key.Q:
                    num = 81;
                    break;
                case Key.R:
                    num = 82;
                    break;
                case Key.S:
                    num = 83;
                    break;
                case Key.T:
                    num = 84;
                    break;
                case Key.U:
                    num = 85;
                    break;
                case Key.V:
                    num = 86;
                    break;
                case Key.W:
                    num = 87;
                    break;
                case Key.X:
                    num = 88;
                    break;
                case Key.Y:
                    num = 89;
                    break;
                case Key.Z:
                    num = 90;
                    break;
                case Key.LWin:
                    num = 91;
                    break;
                case Key.RWin:
                    num = 92;
                    break;
                case Key.Apps:
                    num = 93;
                    break;
                case Key.Sleep:
                    num = 95;
                    break;
                case Key.NumPad0:
                    num = 96;
                    break;
                case Key.NumPad1:
                    num = 97;
                    break;
                case Key.NumPad2:
                    num = 98;
                    break;
                case Key.NumPad3:
                    num = 99;
                    break;
                case Key.NumPad4:
                    num = 100;
                    break;
                case Key.NumPad5:
                    num = 101;
                    break;
                case Key.NumPad6:
                    num = 102;
                    break;
                case Key.NumPad7:
                    num = 103;
                    break;
                case Key.NumPad8:
                    num = 104;
                    break;
                case Key.NumPad9:
                    num = 105;
                    break;
                case Key.Multiply:
                    num = 106;
                    break;
                case Key.Add:
                    num = 107;
                    break;
                case Key.Separator:
                    num = 108;
                    break;
                case Key.Subtract:
                    num = 109;
                    break;
                case Key.Decimal:
                    num = 110;
                    break;
                case Key.Divide:
                    num = 111;
                    break;
                case Key.F1:
                    num = 112;
                    break;
                case Key.F2:
                    num = 113;
                    break;
                case Key.F3:
                    num = 114;
                    break;
                case Key.F4:
                    num = 115;
                    break;
                case Key.F5:
                    num = 116;
                    break;
                case Key.F6:
                    num = 117;
                    break;
                case Key.F7:
                    num = 118;
                    break;
                case Key.F8:
                    num = 119;
                    break;
                case Key.F9:
                    num = 120;
                    break;
                case Key.F10:
                    num = 121;
                    break;
                case Key.F11:
                    num = 122;
                    break;
                case Key.F12:
                    num = 123;
                    break;
                case Key.F13:
                    num = 124;
                    break;
                case Key.F14:
                    num = 125;
                    break;
                case Key.F15:
                    num = 126;
                    break;
                case Key.F16:
                    num = sbyte.MaxValue;
                    break;
                case Key.F17:
                    num = 128;
                    break;
                case Key.F18:
                    num = 129;
                    break;
                case Key.F19:
                    num = 130;
                    break;
                case Key.F20:
                    num = 131;
                    break;
                case Key.F21:
                    num = 132;
                    break;
                case Key.F22:
                    num = 133;
                    break;
                case Key.F23:
                    num = 134;
                    break;
                case Key.F24:
                    num = 135;
                    break;
                case Key.NumLock:
                    num = 144;
                    break;
                case Key.Scroll:
                    num = 145;
                    break;
                case Key.LeftShift:
                    num = 160;
                    break;
                case Key.RightShift:
                    num = 161;
                    break;
                case Key.LeftCtrl:
                    num = 162;
                    break;
                case Key.RightCtrl:
                    num = 163;
                    break;
                case Key.LeftAlt:
                    num = 164;
                    break;
                case Key.RightAlt:
                    num = 165;
                    break;
                case Key.BrowserBack:
                    num = 166;
                    break;
                case Key.BrowserForward:
                    num = 167;
                    break;
                case Key.BrowserRefresh:
                    num = 168;
                    break;
                case Key.BrowserStop:
                    num = 169;
                    break;
                case Key.BrowserSearch:
                    num = 170;
                    break;
                case Key.BrowserFavorites:
                    num = 171;
                    break;
                case Key.BrowserHome:
                    num = 172;
                    break;
                case Key.VolumeMute:
                    num = 173;
                    break;
                case Key.VolumeDown:
                    num = 174;
                    break;
                case Key.VolumeUp:
                    num = 175;
                    break;
                case Key.MediaNextTrack:
                    num = 176;
                    break;
                case Key.MediaPreviousTrack:
                    num = 177;
                    break;
                case Key.MediaStop:
                    num = 178;
                    break;
                case Key.MediaPlayPause:
                    num = 179;
                    break;
                case Key.LaunchMail:
                    num = 180;
                    break;
                case Key.SelectMedia:
                    num = 181;
                    break;
                case Key.LaunchApplication1:
                    num = 182;
                    break;
                case Key.LaunchApplication2:
                    num = 183;
                    break;
                case Key.Oem1:
                    num = 186;
                    break;
                case Key.OemPlus:
                    num = 187;
                    break;
                case Key.OemComma:
                    num = 188;
                    break;
                case Key.OemMinus:
                    num = 189;
                    break;
                case Key.OemPeriod:
                    num = 190;
                    break;
                case Key.Oem2:
                    num = 191;
                    break;
                case Key.Oem3:
                    num = 192;
                    break;
                case Key.AbntC1:
                    num = 193;
                    break;
                case Key.AbntC2:
                    num = 194;
                    break;
                case Key.Oem4:
                    num = 219;
                    break;
                case Key.Oem5:
                    num = 220;
                    break;
                case Key.Oem6:
                    num = 221;
                    break;
                case Key.Oem7:
                    num = 222;
                    break;
                case Key.Oem8:
                    num = 223;
                    break;
                case Key.Oem102:
                    num = 226;
                    break;
                case Key.ImeProcessed:
                    num = 229;
                    break;
                case Key.OemAttn:
                    num = 240;
                    break;
                case Key.OemFinish:
                    num = 241;
                    break;
                case Key.OemCopy:
                    num = 242;
                    break;
                case Key.OemAuto:
                    num = 243;
                    break;
                case Key.OemEnlw:
                    num = 244;
                    break;
                case Key.OemBackTab:
                    num = 245;
                    break;
                case Key.Attn:
                    num = 246;
                    break;
                case Key.CrSel:
                    num = 247;
                    break;
                case Key.ExSel:
                    num = 248;
                    break;
                case Key.EraseEof:
                    num = 249;
                    break;
                case Key.Play:
                    num = 250;
                    break;
                case Key.Zoom:
                    num = 251;
                    break;
                case Key.NoName:
                    num = 252;
                    break;
                case Key.Pa1:
                    num = 253;
                    break;
                case Key.OemClear:
                    num = 254;
                    break;
                case Key.DeadCharProcessed:
                    num = 0;
                    break;
                default:
                    num = 0;
                    break;
            }
            return num;
        }
    }

    /// <summary>   A key converter. </summary>
    ///
    

    public class KeyConverter : TypeConverter
    {
        /// <summary>   Default constructor. </summary>
        ///
        

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public KeyConverter()
        {
        }

        /// <summary>
        ///     Returns whether this converter can convert an object of the given type to the type of
        ///     this converter, using the specified context.
        /// </summary>
        ///
        
        ///
        /// <param name="context">
        ///     An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format
        ///     context.
        /// </param>
        /// <param name="sourceType">
        ///     A <see cref="T:System.Type" /> that represents the type you want to convert from.
        /// </param>
        ///
        /// <returns>   true if this converter can perform the conversion; otherwise, false. </returns>

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        /// <summary>
        ///     Returns whether this converter can convert the object to the specified type, using the
        ///     specified context.
        /// </summary>
        ///
        
        ///
        /// <param name="context">
        ///     An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format
        ///     context.
        /// </param>
        /// <param name="destinationType">
        ///     A <see cref="T:System.Type" /> that represents the type you want to convert to.
        /// </param>
        ///
        /// <returns>   true if this converter can perform the conversion; otherwise, false. </returns>

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (!(destinationType == typeof(string)) || context == null || context.Instance == null)
                return false;
            var key = (Key)context.Instance;
            if (key >= Key.None)
                return key <= Key.DeadCharProcessed;
            return false;
        }

        /// <summary>
        ///     Converts the given object to the type of this converter, using the specified context and
        ///     culture information.
        /// </summary>
        ///
        
        ///
        /// <exception cref="GetConvertFromException">
        ///     Thrown when a Get Convert From error condition occurs.
        /// </exception>
        ///
        /// <param name="context">
        ///     An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format
        ///     context.
        /// </param>
        /// <param name="culture">
        ///     The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.
        /// </param>
        /// <param name="source" type="object"> Source for the. </param>
        ///
        /// <returns>   An <see cref="T:System.Object" /> that represents the converted value. </returns>
        ///
        /// ### <param name="value">    The <see cref="T:System.Object" /> to convert. </param>

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object source)
        {
            if (!(source is string))
                throw GetConvertFromException(source);
            var keyToken = ((string)source).Trim();
            var key = GetKey(keyToken, CultureInfo.InvariantCulture);
            return (Key)key;
        }

        /// <summary>
        ///     Converts the given value object to the specified type, using the specified context and
        ///     culture information.
        /// </summary>
        ///
        
        ///
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are null.
        /// </exception>
        /// <exception cref="GetConvertToException">
        ///     Thrown when a Get Convert To error condition occurs.
        /// </exception>
        ///
        /// <param name="context">
        ///     An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format
        ///     context.
        /// </param>
        /// <param name="culture">
        ///     A <see cref="T:System.Globalization.CultureInfo" />. If null is passed, the current
        ///     culture is assumed.
        /// </param>
        /// <param name="value">            The <see cref="T:System.Object" /> to convert. </param>
        /// <param name="destinationType">
        ///     The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.
        /// </param>
        ///
        /// <returns>   An <see cref="T:System.Object" /> that represents the converted value. </returns>

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
                throw new ArgumentNullException("destinationType");
            if (destinationType == typeof(string) && value != null)
            {
                var key = (Key)value;
                if (key == Key.None)
                    return string.Empty;
                if (key >= Key.D0 && key <= Key.D9)
                    return char.ToString((char)(key - 34 + 48));
                if (key >= Key.A && key <= Key.Z)
                    return char.ToString((char)(key - 44 + 65));
                var str = MatchKey(key, culture);
                if (str != null && (str.Length != 0 || str == string.Empty))
                    return str;
            }
            throw GetConvertToException(value, destinationType);
        }

        /// <summary>   Gets a key. </summary>
        ///
        
        ///
        /// <param name="keyToken" type="string">       The key token. </param>
        /// <param name="culture" type="CultureInfo">   The culture. </param>
        ///
        /// <returns>   The key. </returns>

        private object GetKey(string keyToken, CultureInfo culture)
        {
            if (keyToken == string.Empty)
                return Key.None;
            keyToken = keyToken.ToUpper(culture);
            if (keyToken.Length == 1 && char.IsLetterOrDigit(keyToken[0]))
            {
                if (char.IsDigit(keyToken[0]) && keyToken[0] >= 48 && keyToken[0] <= 57)
                    return 34 + keyToken[0] - 48;
                if (char.IsLetter(keyToken[0]) && keyToken[0] >= 65 && keyToken[0] <= 90)
                    return 44 + keyToken[0] - 65;
            }
            else
            {
                Key key;
                switch (keyToken)
                {
                    case "ENTER":
                        key = Key.Return;
                        break;
                    case "ESC":
                        key = Key.Escape;
                        break;
                    case "PGUP":
                        key = Key.Prior;
                        break;
                    case "PGDN":
                        key = Key.Next;
                        break;
                    case "PRTSC":
                        key = Key.Snapshot;
                        break;
                    case "INS":
                        key = Key.Insert;
                        break;
                    case "DEL":
                        key = Key.Delete;
                        break;
                    case "WINDOWS":
                        key = Key.LWin;
                        break;
                    case "WIN":
                        key = Key.LWin;
                        break;
                    case "LEFTWINDOWS":
                        key = Key.LWin;
                        break;
                    case "RIGHTWINDOWS":
                        key = Key.RWin;
                        break;
                    case "APPS":
                        key = Key.Apps;
                        break;
                    case "APPLICATION":
                        key = Key.Apps;
                        break;
                    case "BREAK":
                        key = Key.Cancel;
                        break;
                    case "BACKSPACE":
                        key = Key.Back;
                        break;
                    case "BKSP":
                        key = Key.Back;
                        break;
                    case "BS":
                        key = Key.Back;
                        break;
                    case "SHIFT":
                        key = Key.LeftShift;
                        break;
                    case "LEFTSHIFT":
                        key = Key.LeftShift;
                        break;
                    case "RIGHTSHIFT":
                        key = Key.RightShift;
                        break;
                    case "CONTROL":
                        key = Key.LeftCtrl;
                        break;
                    case "CTRL":
                        key = Key.LeftCtrl;
                        break;
                    case "LEFTCTRL":
                        key = Key.LeftCtrl;
                        break;
                    case "RIGHTCTRL":
                        key = Key.RightCtrl;
                        break;
                    case "ALT":
                        key = Key.LeftAlt;
                        break;
                    case "LEFTALT":
                        key = Key.LeftAlt;
                        break;
                    case "RIGHTALT":
                        key = Key.RightAlt;
                        break;
                    case "SEMICOLON":
                        key = Key.Oem1;
                        break;
                    case "PLUS":
                        key = Key.OemPlus;
                        break;
                    case "COMMA":
                        key = Key.OemComma;
                        break;
                    case "MINUS":
                        key = Key.OemMinus;
                        break;
                    case "PERIOD":
                        key = Key.OemPeriod;
                        break;
                    case "QUESTION":
                        key = Key.Oem2;
                        break;
                    case "TILDE":
                        key = Key.Oem3;
                        break;
                    case "OPENBRACKETS":
                        key = Key.Oem4;
                        break;
                    case "PIPE":
                        key = Key.Oem5;
                        break;
                    case "CLOSEBRACKETS":
                        key = Key.Oem6;
                        break;
                    case "QUOTES":
                        key = Key.Oem7;
                        break;
                    case "BACKSLASH":
                        key = Key.Oem102;
                        break;
                    case "FINISH":
                        key = Key.OemFinish;
                        break;
                    case "ATTN":
                        key = Key.Attn;
                        break;
                    case "CRSEL":
                        key = Key.CrSel;
                        break;
                    case "EXSEL":
                        key = Key.ExSel;
                        break;
                    case "ERASEEOF":
                        key = Key.EraseEof;
                        break;
                    case "PLAY":
                        key = Key.Play;
                        break;
                    case "ZOOM":
                        key = Key.Zoom;
                        break;
                    case "PA1":
                        key = Key.Pa1;
                        break;
                    default:
                        key = (Key)Enum.Parse(typeof(Key), keyToken, true);
                        break;
                }
                if (key != (Key)(-1))
                    return key;
                return null;
            }
            return null;
        }

        /// <summary>   Match key. </summary>
        ///
        
        ///
        /// <param name="key" type="Key">               The key. </param>
        /// <param name="culture" type="CultureInfo">   The culture. </param>
        ///
        /// <returns>   A string. </returns>

        private static string MatchKey(Key key, CultureInfo culture)
        {
            if (key == Key.None)
                return string.Empty;
            switch (key)
            {
                case Key.Back:
                    return "Backspace";
                case Key.LineFeed:
                    return "Clear";
                case Key.Escape:
                    return "Esc";
                default:
                    if (key >= Key.None && key <= Key.DeadCharProcessed)
                        return ((object)key).ToString();
                    return null;
            }
        }
    }

    /// <summary>   Values that represent Key. </summary>
    ///
    

    public enum Key
    {
        /// <summary>   An enum constant representing the none option. </summary>
        None = 0,
        /// <summary>   An enum constant representing the cancel option. </summary>
        Cancel = 1,
        /// <summary>   An enum constant representing the back option. </summary>
        Back = 2,
        /// <summary>   An enum constant representing the tab option. </summary>
        Tab = 3,
        /// <summary>   An enum constant representing the line feed option. </summary>
        LineFeed = 4,
        /// <summary>   An enum constant representing the clear option. </summary>
        Clear = 5,
        /// <summary>   An enum constant representing the enter option. </summary>
        Enter = 6,
        /// <summary>   An enum constant representing the return option. </summary>
        Return = 6,
        /// <summary>   An enum constant representing the pause option. </summary>
        Pause = 7,
        /// <summary>   An enum constant representing the capital option. </summary>
        Capital = 8,
        /// <summary>   An enum constant representing the capabilities lock option. </summary>
        CapsLock = 8,
        /// <summary>   An enum constant representing the hangul mode option. </summary>
        HangulMode = 9,
        /// <summary>   An enum constant representing the kana mode option. </summary>
        KanaMode = 9,
        /// <summary>   An enum constant representing the junja mode option. </summary>
        JunjaMode = 10,
        /// <summary>   An enum constant representing the final mode option. </summary>
        FinalMode = 11,
        /// <summary>   An enum constant representing the hanja mode option. </summary>
        HanjaMode = 12,
        /// <summary>   An enum constant representing the kanji mode option. </summary>
        KanjiMode = 12,
        /// <summary>   An enum constant representing the escape option. </summary>
        Escape = 13,
        /// <summary>   An enum constant representing the ime convert option. </summary>
        ImeConvert = 14,
        /// <summary>   An enum constant representing the ime non convert option. </summary>
        ImeNonConvert = 15,
        /// <summary>   An enum constant representing the ime accept option. </summary>
        ImeAccept = 16,
        /// <summary>   An enum constant representing the ime mode change option. </summary>
        ImeModeChange = 17,
        /// <summary>   An enum constant representing the space option. </summary>
        Space = 18,
        /// <summary>   An enum constant representing the page up option. </summary>
        PageUp = 19,
        /// <summary>   An enum constant representing the prior option. </summary>
        Prior = 19,
        /// <summary>   An enum constant representing the next option. </summary>
        Next = 20,
        /// <summary>   An enum constant representing the page down option. </summary>
        PageDown = 20,
        /// <summary>   An enum constant representing the end option. </summary>
        End = 21,
        /// <summary>   An enum constant representing the home option. </summary>
        Home = 22,
        /// <summary>   An enum constant representing the left option. </summary>
        Left = 23,
        /// <summary>   An enum constant representing the up option. </summary>
        Up = 24,
        /// <summary>   An enum constant representing the right option. </summary>
        Right = 25,
        /// <summary>   An enum constant representing the down option. </summary>
        Down = 26,
        /// <summary>   An enum constant representing the select option. </summary>
        Select = 27,
        /// <summary>   An enum constant representing the print option. </summary>
        Print = 28,
        /// <summary>   An enum constant representing the execute option. </summary>
        Execute = 29,
        /// <summary>   An enum constant representing the print screen option. </summary>
        PrintScreen = 30,
        /// <summary>   An enum constant representing the snapshot option. </summary>
        Snapshot = 30,
        /// <summary>   An enum constant representing the insert option. </summary>
        Insert = 31,
        /// <summary>   An enum constant representing the delete option. </summary>
        Delete = 32,
        /// <summary>   An enum constant representing the help option. </summary>
        Help = 33,
        /// <summary>   An enum constant representing the d 0 option. </summary>
        D0 = 34,
        /// <summary>   An enum constant representing the d 1 option. </summary>
        D1 = 35,
        /// <summary>   An enum constant representing the d 2 option. </summary>
        D2 = 36,
        /// <summary>   An enum constant representing the d 3 option. </summary>
        D3 = 37,
        /// <summary>   An enum constant representing the d 4 option. </summary>
        D4 = 38,
        /// <summary>   An enum constant representing the d 5 option. </summary>
        D5 = 39,
        /// <summary>   An enum constant representing the d 6 option. </summary>
        D6 = 40,
        /// <summary>   An enum constant representing the d 7 option. </summary>
        D7 = 41,
        /// <summary>   An enum constant representing the d 8 option. </summary>
        D8 = 42,
        /// <summary>   An enum constant representing the d 9 option. </summary>
        D9 = 43,
        /// <summary>   An enum constant representing a option. </summary>
        A = 44,
        /// <summary>   An enum constant representing the b option. </summary>
        B = 45,
        /// <summary>   An enum constant representing the c option. </summary>
        C = 46,
        /// <summary>   An enum constant representing the d option. </summary>
        D = 47,
        /// <summary>   An enum constant representing the e option. </summary>
        E = 48,
        /// <summary>   An enum constant representing the f option. </summary>
        F = 49,
        /// <summary>   An enum constant representing the g option. </summary>
        G = 50,
        /// <summary>   An enum constant representing the h option. </summary>
        H = 51,
        /// <summary>   An enum constant representing the i option. </summary>
        I = 52,
        /// <summary>   An enum constant representing the j option. </summary>
        J = 53,
        /// <summary>   An enum constant representing the k option. </summary>
        K = 54,
        /// <summary>   An enum constant representing the l option. </summary>
        L = 55,
        /// <summary>   An enum constant representing the m option. </summary>
        M = 56,
        /// <summary>   An enum constant representing the n option. </summary>
        N = 57,
        /// <summary>   An enum constant representing the o option. </summary>
        O = 58,
        /// <summary>   An enum constant representing the p option. </summary>
        P = 59,
        /// <summary>   An enum constant representing the q option. </summary>
        Q = 60,
        /// <summary>   An enum constant representing the r option. </summary>
        R = 61,
        /// <summary>   An enum constant representing the s option. </summary>
        S = 62,
        /// <summary>   An enum constant representing the t option. </summary>
        T = 63,
        /// <summary>   An enum constant representing the u option. </summary>
        U = 64,
        /// <summary>   An enum constant representing the v option. </summary>
        V = 65,
        /// <summary>   An enum constant representing the w option. </summary>
        W = 66,
        /// <summary>   An enum constant representing the x coordinate option. </summary>
        X = 67,
        /// <summary>   An enum constant representing the y coordinate option. </summary>
        Y = 68,
        /// <summary>   An enum constant representing the z coordinate option. </summary>
        Z = 69,
        /// <summary>   An enum constant representing the window option. </summary>
        LWin = 70,
        /// <summary>   An enum constant representing the window option. </summary>
        RWin = 71,
        /// <summary>   An enum constant representing the apps option. </summary>
        Apps = 72,
        /// <summary>   An enum constant representing the sleep option. </summary>
        Sleep = 73,
        /// <summary>   An enum constant representing the number pad 0 option. </summary>
        NumPad0 = 74,
        /// <summary>   An enum constant representing the number pad 1 option. </summary>
        NumPad1 = 75,
        /// <summary>   An enum constant representing the number pad 2 option. </summary>
        NumPad2 = 76,
        /// <summary>   An enum constant representing the number pad 3 option. </summary>
        NumPad3 = 77,
        /// <summary>   An enum constant representing the number pad 4 option. </summary>
        NumPad4 = 78,
        /// <summary>   An enum constant representing the number pad 5 option. </summary>
        NumPad5 = 79,
        /// <summary>   An enum constant representing the number pad 6 option. </summary>
        NumPad6 = 80,
        /// <summary>   An enum constant representing the number pad 7 option. </summary>
        NumPad7 = 81,
        /// <summary>   An enum constant representing the number pad 8 option. </summary>
        NumPad8 = 82,
        /// <summary>   An enum constant representing the number pad 9 option. </summary>
        NumPad9 = 83,
        /// <summary>   An enum constant representing the multiply option. </summary>
        Multiply = 84,
        /// <summary>   An enum constant representing the add option. </summary>
        Add = 85,
        /// <summary>   An enum constant representing the separator option. </summary>
        Separator = 86,
        /// <summary>   An enum constant representing the subtract option. </summary>
        Subtract = 87,
        /// <summary>   An enum constant representing the decimal option. </summary>
        Decimal = 88,
        /// <summary>   An enum constant representing the divide option. </summary>
        Divide = 89,
        /// <summary>   An enum constant representing the f 1 option. </summary>
        F1 = 90,
        /// <summary>   An enum constant representing the f 2 option. </summary>
        F2 = 91,
        /// <summary>   An enum constant representing the f 3 option. </summary>
        F3 = 92,
        /// <summary>   An enum constant representing the f 4 option. </summary>
        F4 = 93,
        /// <summary>   An enum constant representing the f 5 option. </summary>
        F5 = 94,
        /// <summary>   An enum constant representing the f 6 option. </summary>
        F6 = 95,
        /// <summary>   An enum constant representing the f 7 option. </summary>
        F7 = 96,
        /// <summary>   An enum constant representing the f 8 option. </summary>
        F8 = 97,
        /// <summary>   An enum constant representing the f 9 option. </summary>
        F9 = 98,
        /// <summary>   An enum constant representing the 10 option. </summary>
        F10 = 99,
        /// <summary>   An enum constant representing the 11 option. </summary>
        F11 = 100,
        /// <summary>   An enum constant representing the 12 option. </summary>
        F12 = 101,
        /// <summary>   An enum constant representing the 13 option. </summary>
        F13 = 102,
        /// <summary>   An enum constant representing the 14 option. </summary>
        F14 = 103,
        /// <summary>   An enum constant representing the 15 option. </summary>
        F15 = 104,
        /// <summary>   An enum constant representing the 16 option. </summary>
        F16 = 105,
        /// <summary>   An enum constant representing the 17 option. </summary>
        F17 = 106,
        /// <summary>   An enum constant representing the 18 option. </summary>
        F18 = 107,
        /// <summary>   An enum constant representing the 19 option. </summary>
        F19 = 108,
        /// <summary>   An enum constant representing the 20 option. </summary>
        F20 = 109,
        /// <summary>   An enum constant representing the 21 option. </summary>
        F21 = 110,
        /// <summary>   An enum constant representing the 22 option. </summary>
        F22 = 111,
        /// <summary>   An enum constant representing the 23 option. </summary>
        F23 = 112,
        /// <summary>   An enum constant representing the 24 option. </summary>
        F24 = 113,
        /// <summary>   An enum constant representing the number lock option. </summary>
        NumLock = 114,
        /// <summary>   An enum constant representing the scroll option. </summary>
        Scroll = 115,
        /// <summary>   An enum constant representing the left shift option. </summary>
        LeftShift = 116,
        /// <summary>   An enum constant representing the right shift option. </summary>
        RightShift = 117,
        /// <summary>   An enum constant representing the left control option. </summary>
        LeftCtrl = 118,
        /// <summary>   An enum constant representing the right control option. </summary>
        RightCtrl = 119,
        /// <summary>   An enum constant representing the left alternate option. </summary>
        LeftAlt = 120,
        /// <summary>   An enum constant representing the right alternate option. </summary>
        RightAlt = 121,
        /// <summary>   An enum constant representing the browser back option. </summary>
        BrowserBack = 122,
        /// <summary>   An enum constant representing the browser forward option. </summary>
        BrowserForward = 123,
        /// <summary>   An enum constant representing the browser refresh option. </summary>
        BrowserRefresh = 124,
        /// <summary>   An enum constant representing the browser stop option. </summary>
        BrowserStop = 125,
        /// <summary>   An enum constant representing the browser search option. </summary>
        BrowserSearch = 126,
        /// <summary>   An enum constant representing the browser favorites option. </summary>
        BrowserFavorites = 127,
        /// <summary>   An enum constant representing the browser home option. </summary>
        BrowserHome = 128,
        /// <summary>   An enum constant representing the volume mute option. </summary>
        VolumeMute = 129,
        /// <summary>   An enum constant representing the volume down option. </summary>
        VolumeDown = 130,
        /// <summary>   An enum constant representing the volume up option. </summary>
        VolumeUp = 131,
        /// <summary>   An enum constant representing the media next track option. </summary>
        MediaNextTrack = 132,
        /// <summary>   An enum constant representing the media previous track option. </summary>
        MediaPreviousTrack = 133,
        /// <summary>   An enum constant representing the media stop option. </summary>
        MediaStop = 134,
        /// <summary>   An enum constant representing the media play pause option. </summary>
        MediaPlayPause = 135,
        /// <summary>   An enum constant representing the launch mail option. </summary>
        LaunchMail = 136,
        /// <summary>   An enum constant representing the select media option. </summary>
        SelectMedia = 137,
        /// <summary>   An enum constant representing the launch application 1 option. </summary>
        LaunchApplication1 = 138,
        /// <summary>   An enum constant representing the launch application 2 option. </summary>
        LaunchApplication2 = 139,
        /// <summary>   An enum constant representing the OEM 1 option. </summary>
        Oem1 = 140,
        /// <summary>   An enum constant representing the OEM semicolon option. </summary>
        OemSemicolon = 140,
        /// <summary>   An enum constant representing the OEM plus option. </summary>
        OemPlus = 141,
        /// <summary>   An enum constant representing the OEM comma option. </summary>
        OemComma = 142,
        /// <summary>   An enum constant representing the OEM minus option. </summary>
        OemMinus = 143,
        /// <summary>   An enum constant representing the OEM period option. </summary>
        OemPeriod = 144,
        /// <summary>   An enum constant representing the OEM 2 option. </summary>
        Oem2 = 145,
        /// <summary>   An enum constant representing the OEM question option. </summary>
        OemQuestion = 145,
        /// <summary>   An enum constant representing the OEM 3 option. </summary>
        Oem3 = 146,
        /// <summary>   An enum constant representing the OEM tilde option. </summary>
        OemTilde = 146,
        /// <summary>   An enum constant representing the abnt c 1 option. </summary>
        AbntC1 = 147,
        /// <summary>   An enum constant representing the abnt c 2 option. </summary>
        AbntC2 = 148,
        /// <summary>   An enum constant representing the OEM 4 option. </summary>
        Oem4 = 149,
        /// <summary>   An enum constant representing the OEM open brackets option. </summary>
        OemOpenBrackets = 149,
        /// <summary>   An enum constant representing the OEM 5 option. </summary>
        Oem5 = 150,
        /// <summary>   An enum constant representing the OEM pipe option. </summary>
        OemPipe = 150,
        /// <summary>   An enum constant representing the OEM 6 option. </summary>
        Oem6 = 151,
        /// <summary>   An enum constant representing the OEM close brackets option. </summary>
        OemCloseBrackets = 151,
        /// <summary>   An enum constant representing the OEM 7 option. </summary>
        Oem7 = 152,
        /// <summary>   An enum constant representing the OEM quotes option. </summary>
        OemQuotes = 152,
        /// <summary>   An enum constant representing the OEM 8 option. </summary>
        Oem8 = 153,
        /// <summary>   An enum constant representing the OEM 102 option. </summary>
        Oem102 = 154,
        /// <summary>   An enum constant representing the OEM backslash option. </summary>
        OemBackslash = 154,
        /// <summary>   An enum constant representing the ime processed option. </summary>
        ImeProcessed = 155,
        /// <summary>   An enum constant representing the system option. </summary>
        System = 156,
        /// <summary>   An enum constant representing the dbe alphanumeric option. </summary>
        DbeAlphanumeric = 157,
        /// <summary>   An enum constant representing the OEM attn option. </summary>
        OemAttn = 157,
        /// <summary>   An enum constant representing the dbe katakana option. </summary>
        DbeKatakana = 158,
        /// <summary>   An enum constant representing the OEM finish option. </summary>
        OemFinish = 158,
        /// <summary>   An enum constant representing the dbe hiragana option. </summary>
        DbeHiragana = 159,
        /// <summary>   An enum constant representing the OEM copy option. </summary>
        OemCopy = 159,
        /// <summary>   An enum constant representing the dbe sbcs character option. </summary>
        DbeSbcsChar = 160,
        /// <summary>   An enum constant representing the OEM automatic option. </summary>
        OemAuto = 160,
        /// <summary>   An enum constant representing the dbe dbcs character option. </summary>
        DbeDbcsChar = 161,
        /// <summary>   An enum constant representing the OEM enlw option. </summary>
        OemEnlw = 161,
        /// <summary>   An enum constant representing the dbe roman option. </summary>
        DbeRoman = 162,
        /// <summary>   An enum constant representing the OEM back tab option. </summary>
        OemBackTab = 162,
        /// <summary>   An enum constant representing the attn option. </summary>
        Attn = 163,
        /// <summary>   An enum constant representing the dbe no roman option. </summary>
        DbeNoRoman = 163,
        /// <summary>   An enum constant representing the carriage return selected option. </summary>
        CrSel = 164,
        /// <summary>   An enum constant representing the dbe enter word register mode option. </summary>
        DbeEnterWordRegisterMode = 164,
        /// <summary>   An enum constant representing the dbe enter ime configure mode option. </summary>
        DbeEnterImeConfigureMode = 165,
        /// <summary>   An enum constant representing the ex selected option. </summary>
        ExSel = 165,
        /// <summary>   An enum constant representing the dbe flush string option. </summary>
        DbeFlushString = 166,
        /// <summary>   An enum constant representing the erase EOF option. </summary>
        EraseEof = 166,
        /// <summary>   An enum constant representing the dbe code input option. </summary>
        DbeCodeInput = 167,
        /// <summary>   An enum constant representing the play option. </summary>
        Play = 167,
        /// <summary>   An enum constant representing the dbe no code input option. </summary>
        DbeNoCodeInput = 168,
        /// <summary>   An enum constant representing the zoom option. </summary>
        Zoom = 168,
        /// <summary>   An enum constant representing the dbe determine string option. </summary>
        DbeDetermineString = 169,
        /// <summary>   An enum constant representing the no name option. </summary>
        NoName = 169,
        /// <summary>   An enum constant representing the dbe enter dialog conversion mode option. </summary>
        DbeEnterDialogConversionMode = 170,
        /// <summary>   An enum constant representing the pa 1 option. </summary>
        Pa1 = 170,
        /// <summary>   An enum constant representing the OEM clear option. </summary>
        OemClear = 171,
        /// <summary>   An enum constant representing the dead character processed option. </summary>
        DeadCharProcessed = 172,
    }
    #endregion
}
