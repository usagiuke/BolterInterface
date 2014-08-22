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
    public class Synthesis : ISynthesis
    {
        private readonly IntPtr _staticSynthPtr;

        public Synthesis()
        {
            _staticSynthPtr = Funcs.GetCurrentSynthPtr();
        }

        public bool SynthWindowIsOpen
        {
            
            get
            {
                var nBool = Marshal.ReadByte(_staticSynthPtr);
                return nBool == 3 || nBool == 9;
            }
        }

        
        public void WaitForAnimationLock(int timeout)
        {
            Funcs.WaitForAnimationLock(timeout);
        }

        public ushort Progress
        {
            
            get { return Marshal.PtrToStructure<UInt16>(_staticSynthPtr + SynthesisOffects.Progress); }
        }

        public ushort ProgressMax
        {
            
            get
            {
                var ptr = Funcs.GetSynthWindow2Ptr();
                return ptr != IntPtr.Zero ? Marshal.PtrToStructure<UInt16>(ptr + SynthesisOffects.ProgressMax) : ushort.MaxValue;
            }
        }

        public ushort Quality
        {
            
            get { return Marshal.PtrToStructure<UInt16>(_staticSynthPtr + SynthesisOffects.Quality); }
        }

        public ushort QualityMax
        {
            
            get
            {
                var ptr = Funcs.GetSynthWindow2Ptr();
                return ptr != IntPtr.Zero ? Marshal.PtrToStructure<UInt16>(ptr + SynthesisOffects.QualityMax) : ushort.MaxValue;
            }
        }

        public ushort Durability
        {
            
            get { return Marshal.PtrToStructure<UInt16>(_staticSynthPtr + SynthesisOffects.Durability); }
        }

        public ushort DurabilityMax
        {
            
            get
            {
                var ptr = Funcs.GetCraftSubWindowPtr();
                return ptr != IntPtr.Zero ? Marshal.PtrToStructure<UInt16>(ptr + SynthesisOffects.DurabilityMax) : ushort.MaxValue;
            }
        }

        public byte HQRate
        {
            
            get { return Marshal.ReadByte(_staticSynthPtr + SynthesisOffects.HQRate); }
        }

        public SynthesisCondition Condition
        {
            
            get { return (SynthesisCondition)Enum.Parse(typeof(SynthesisCondition), Marshal.ReadByte(_staticSynthPtr + SynthesisOffects.Condition).ToString(), false); }
        }

        
        public int StartSynthesis(byte index)
        {
            return Funcs.StartSynthesis(index);
        }

        
        public int ChangeLevelRange(int jobIndex, int levelIndex)
        {
            return Funcs.ChangeLevelRange(jobIndex, levelIndex);
        }
    }
}
