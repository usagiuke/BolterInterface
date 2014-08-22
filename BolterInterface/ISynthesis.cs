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
    public interface ISynthesis
    {
        UInt16 Progress { get; }
        UInt16 ProgressMax { get; }
        UInt16 Quality { get; }
        UInt16 QualityMax { get; }
        UInt16 Durability { get; }
        UInt16 DurabilityMax { get; }
        byte HQRate { get; }
        SynthesisCondition Condition { get; }
        bool SynthWindowIsOpen { get; }
        void WaitForAnimationLock(int timeout);
        int ChangeLevelRange(int jobIndex, int levelIndex);
        int StartSynthesis(byte index);
    }
}
