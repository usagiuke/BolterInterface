// file:	NativeRoutines.cs
//
// summary:	Implements the native routines class

using System;
using System.Runtime.InteropServices;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A funcs. </summary>
    ///

    [SuppressUnmanagedCodeSecurity]
    public class Funcs
    {
        /// <summary>   Unload iterator. </summary>
        ///
        
        ///
        /// <param name="domainName" type="string"> Name of the domain. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void UnloadIt([MarshalAs(UnmanagedType.LPStr)] string domainName);

        /// <summary>   Gets a position. </summary>
        ///
        
        ///
        /// <param name="eType" type="EntityType">  The type. </param>
        /// <param name="axis" type="Axis">         The axis. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        ///
        /// <returns>   The position. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern float GetPOS(EntityType eType, Axis axis, Int32 index);

        /// <summary>   Gets a name. </summary>
        ///
        
        ///
        /// <param name="eType" type="EntityType">  The type. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        ///
        /// <returns>   The name. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetName(EntityType eType, Int32 index);

        /// <summary>   Sets a position. </summary>
        ///
        
        ///
        /// <param name="type" type="EntityType">   The type. </param>
        /// <param name="axis" type="Axis">         The axis. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        /// <param name="value" type="float">       The value. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetPOS(EntityType type, Axis axis, Int32 index, [MarshalAs(UnmanagedType.R4)]float value);

        /// <summary>   Sets a heading. </summary>
        ///
        
        ///
        /// <param name="type" type="EntityType">   The type. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        /// <param name="value" type="float">       The value. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetHeading(EntityType type, Int32 index, float value);

        /// <summary>   Gets a heading. </summary>
        ///
        
        ///
        /// <param name="type" type="EntityType">   The type. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        ///
        /// <returns>   The heading. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern float GetHeading(EntityType type, Int32 index);

        /// <summary>   Sets 3 d vector. </summary>
        ///
        
        ///
        /// <param name="type" type="EntityType">   The type. </param>
        /// <param name="axis" type="Axis">         The axis. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        /// <param name="value" type="float">       The value. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Set3DVector(EntityType type, Axis axis, Int32 index, float value);

        /// <summary>   Gets 3 d vector. </summary>
        ///
        
        ///
        /// <param name="type" type="EntityType">   The type. </param>
        /// <param name="axis" type="Axis">         The axis. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        ///
        /// <returns>   The 3 d vector. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern float Get3DVector(EntityType type, Axis axis, Int32 index);

        /// <summary>   Gets a buffer. </summary>
        ///
        
        ///
        /// <param name="buffIndex" type="Int32">       Zero-based index of the buffer. </param>
        /// <param name="eIndex" type="Int32">          The index. </param>
        /// <param name="pData" type="byte[]">          The data. </param>
        /// <param name="set" type="bool">              true to set. </param>
        /// <param name="pInfo" type="BuffInfoType">    The information. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void GetBuff(Int32 buffIndex, Int32 eIndex, [In, Out]byte[] pData, [MarshalAs(UnmanagedType.Bool)]bool set, BuffInfoType pInfo);

        /// <summary>   Gets a movement. </summary>
        ///
        
        ///
        /// <param name="mEnum" type="MovementEnum">    The enum. </param>
        ///
        /// <returns>   The movement. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern float GetMovement(MovementEnum mEnum);

        /// <summary>   Sets a movement. </summary>
        ///
        
        ///
        /// <param name="mEnum" type="MovementEnum">    The enum. </param>
        /// <param name="value" type="float">           The value. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetMovement(MovementEnum mEnum, float value);

        /// <summary>   Gets move status. </summary>
        ///
        
        ///
        /// <returns>   The move status. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern WalkingStatus GetMoveStatus();

        /// <summary>   Sets move status. </summary>
        ///
        
        ///
        /// <param name="status" type="WalkingStatus">  The status. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetMoveStatus(WalkingStatus status);

        /// <summary>   Gets entity identifier. </summary>
        ///
        
        ///
        /// <param name="eType" type="EntityType">  The type. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        ///
        /// <returns>   The entity identifier. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEntityID(EntityType eType, Int32 index);

        /// <summary>   Gets target entity identifier. </summary>
        ///
        
        ///
        /// <returns>   The target entity identifier. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetTargetEntityID();

        /// <summary>   Gets zone name. </summary>
        ///
        
        ///
        /// <returns>   The zone name. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetZoneName();

        /// <summary>   Gets buffer name. </summary>
        ///
        
        ///
        /// <param name="id" type="UInt16"> The identifier. </param>
        ///
        /// <returns>   The buffer name. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetBuffName(UInt16 id);

        /// <summary>   Toggle collision. </summary>
        ///
        
        ///
        /// <param name="on" type="bool">   true to on. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ToggleCollision([MarshalAs(UnmanagedType.Bool)]bool on);

        /// <summary>   Sends a command. </summary>
        ///
        
        ///
        /// <param name="pCommand" type="IntPtr">   The command. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void SendCommand(IntPtr pCommand);

        /// <summary>   Scans the names. </summary>
        ///
        
        ///
        /// <param name="pNames" type="string[]">   The names. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ScanNames([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)]string[] pNames);

        /// <summary>   Gets zone identifier. </summary>
        ///
        
        ///
        /// <returns>   The zone identifier. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetZoneId();

        /// <summary>   Toggle lock axis. </summary>
        ///
        
        ///
        /// <param name="axis" type="Axis"> The axis. </param>
        /// <param name="on" type="bool">   true to on. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ToggleLockAxis(Axis axis, [MarshalAs(UnmanagedType.Bool)]bool on);

        /// <summary>   Gets an entity. </summary>
        ///
        
        ///
        /// <param name="eType" type="EntityType">  The type. </param>
        /// <param name="index" type="Int32">       Zero-based index of the. </param>
        ///
        /// <returns>   The entity. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetEntity(EntityType eType, Int32 index);

        /// <summary>   Registers the command event described by p. </summary>
        ///
        
        ///
        /// <param name="p" type="IntPtr">  The IntPtr to process. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void RegisterCommandEvent(IntPtr p);

        /// <summary>   Un register command event. </summary>
        ///
        
        ///
        /// <param name="p" type="IntPtr">  The IntPtr to process. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void UnRegisterCommandEvent(IntPtr p);

        /// <summary>   Registers the chat event described by p. </summary>
        ///
        
        ///
        /// <param name="p" type="IntPtr">  The IntPtr to process. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void RegisterChatEvent(IntPtr p);

        /// <summary>   Un register chat event. </summary>
        ///
        
        ///
        /// <param name="p" type="IntPtr">  The IntPtr to process. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void UnRegisterChatEvent(IntPtr p);

        /// <summary>   Executes the hot bar on a different thread, and waits for the result. </summary>
        ///
        
        ///
        /// <param name="bar" type="int">   The bar. </param>
        /// <param name="slot" type="int">  The slot. </param>
        ///
        /// <returns>   A byte. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern byte InvokeHotBar(int bar, int slot);

        /// <summary>   Registers the hp event described by p. </summary>
        ///
        
        ///
        /// <param name="p" type="IntPtr">  The IntPtr to process. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void RegisterHPEvent(IntPtr p);

        /// <summary>   Un register hp event. </summary>
        ///
        
        ///
        /// <param name="p" type="IntPtr">  The IntPtr to process. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void UnRegisterHPEvent(IntPtr p);

        /// <summary>   Gets the camera. </summary>
        ///
        
        ///
        /// <returns>   The camera. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetCam();

        /// <summary>   My gather invoke. </summary>
        ///
        
        ///
        /// <param name="itemId" type="uint">   Identifier for the item. </param>
        ///
        /// <returns>   An int. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int MyGatherInvoke(uint itemId);

        /// <summary>   Gets target structure. </summary>
        ///
        
        ///
        /// <returns>   The target structure. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetTargetStruct();

        /// <summary>   Gets movement pointer. </summary>
        ///
        
        ///
        /// <returns>   The movement pointer. </returns>
        
        [DllImport("TachyonEmitter.dll", EntryPoint = "GetMovmentPtr", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetMovementPtr();

        /// <summary>   Hides the buffer. </summary>
        ///
        
        ///
        /// <param name="hide" type="bool"> true to hide, false to show. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void HideBuff([MarshalAs(UnmanagedType.Bool)]bool hide);

        /// <summary>   Gets index of closest node. </summary>
        ///
        
        ///
        /// <param name="nodeType" type="GatheringNode">    Type of the node. </param>
        ///
        /// <returns>   The index of closest node. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetIndexOfClosestNode(GatheringNode nodeType);

        /// <summary>   Model rotation. </summary>
        ///
        
        ///
        /// <param name="newPoint" type="ref Player2DPos">  [in,out] The new point. </param>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelRotation(ref Player2DPos newPoint);

        /// <summary>   Gets 2 d position. </summary>
        ///
        
        ///
        /// <returns>   The 2 d position. </returns>
        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructMarshaler))]
        public static extern Player2DPos Get2DPos();

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetWeatherPtr();

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetZoneIDFromName(string name);

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetZoneNameFromID(int ID);

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetCraftSubWindowPtr();

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetNaviMapPtr();

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetSynthWindow2Ptr();

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetCurrentSynthPtr();

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int StartSynthesis(byte index);

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ChangeLevelRange(int job, int index);

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int OpenMenu(MenuType mType);

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsMenuOpen(MenuType mType);

        
        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void WaitForAnimationLock(int timeout);

        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetItemSignature(Int64 key);

        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetInventoryObject(int blockindex, int itemindex);
    }

    /// <summary>   A structure marshaler. </summary>
    ///
    

    public class StructMarshaler : ICustomMarshaler
    {
        /// <summary>   The marshaler. </summary>
        private static StructMarshaler _marshaler;

        /// <summary>   Gets an instance. </summary>
        ///
        
        ///
        /// <param name="pstrCookie" type="String"> The pstr cookie. </param>
        ///
        /// <returns>   The instance. </returns>

        public static ICustomMarshaler GetInstance(String pstrCookie)
        {
            return _marshaler ?? (_marshaler = new StructMarshaler());
        }

        /// <summary>   Converts the unmanaged data to managed data. </summary>
        ///
        
        ///
        /// <param name="pNativeData">  A pointer to the unmanaged data to be wrapped. </param>
        ///
        /// <returns>   An object that represents the managed view of the COM data. </returns>

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return Marshal.PtrToStructure(pNativeData, typeof(Player2DPos));
        }

        /// <summary>   Returns the size of the native data to be marshaled. </summary>
        ///
        
        ///
        /// <returns>   The size, in bytes, of the native data. </returns>

        public int GetNativeDataSize()
        {
            return Marshal.SizeOf(typeof(Player2DPos));
        }

        /// <summary>   Converts the managed data to unmanaged data. </summary>
        ///
        
        ///
        /// <param name="ManagedObj">   The managed object to be converted. </param>
        ///
        /// <returns>   A pointer to the COM view of the managed object. </returns>

        public IntPtr MarshalManagedToNative(object ManagedObj){return default(IntPtr);}

        /// <summary>
        ///     Performs necessary cleanup of the unmanaged data when it is no longer needed.
        /// </summary>
        ///
        
        ///
        /// <param name="pNativeData">  A pointer to the unmanaged data to be destroyed. </param>

        public void CleanUpNativeData(IntPtr pNativeData){}

        /// <summary>
        ///     Performs necessary cleanup of the managed data when it is no longer needed.
        /// </summary>
        ///
        
        ///
        /// <param name="ManagedObj">   The managed object to be destroyed. </param>

        public void CleanUpManagedData(object ManagedObj){}
    }

    /// <summary>   Values that represent MovementEnum. </summary>
    ///
    /// <remarks>   Bunny 2, 3/14/2014. </remarks>

    public enum MovementEnum
    {
        /// <summary>   An enum constant representing the walking status option. </summary>
        ///
        /// <value> The. </value>

        EWalkingStatus,

        /// <summary>   An enum constant representing the current speed option. </summary>
        ///
        /// <value> The. </value>

        CurrentSpeed,

        /// <summary>   An enum constant representing the forward speed option. </summary>
        ///
        /// <value> The. </value>

        ForwardSpeed,

        /// <summary>   An enum constant representing the left right speed option. </summary>
        ///
        /// <value> The. </value>

        LeftRightSpeed,
        /// <summary>   An enum constant representing the backward speed option. </summary>
        BackwardSpeed
    };

    /// <summary>   Values that represent BuffInfoType. </summary>
    ///
    /// <remarks>   Bunny 2, 3/14/2014. </remarks>

    public enum BuffInfoType
    {
        /// <summary>   An enum constant representing the identifier option. </summary>
        ///
        /// <value> The. </value>

        ID,

        /// <summary>   An enum constant representing the parameters option. </summary>
        ///
        /// <value> The. </value>

        Params,

        /// <summary>   An enum constant representing the timer option. </summary>
        ///
        /// <value> The. </value>

        Timer,
        /// <summary>   An enum constant representing the extra information option. </summary>
        ExtraInfo
    };

}
