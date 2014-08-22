// file:	InterProcessCom.cs
//
// summary:	Implements the inter process com class

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading;

#pragma warning disable 0618

namespace BolterInterface
{
    /// <summary>   An inter process com. </summary>
    ///
    /// <remarks>   Bunny 2, 3/14/2014. </remarks>

    public class InterProcessCom //: MarshalByRefObject
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

        [DllImport("Link.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_INT)]
        public static extern int[] _MapTo();

        [DllImport("Link.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern _Assembly _LoadP([MarshalAs(UnmanagedType.Interface)]_AppDomain appDomain, [MarshalAs(UnmanagedType.Interface)]_AssemblyName assName);

        public delegate void GlobalCleanUpCrew();
        public static GlobalCleanUpCrew DCleanUpCrew;
        /// <summary>   Full pathname of the configuration file. </summary>
        public static string ConfigPath;

        /// <summary>   The handle. </summary>
        private static object pHandle;

        /// <summary>   The handle. </summary>
        public static EventWaitHandle eHandle;

        /// <summary>
        /// Function that starts Bolter. Takes various information that the unmanaged side needs to pass
        /// to the managed side.
        /// </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="configPath">   Full pathname of the configuration file. </param>
        /// <param name="fPtrs">        The ptrs. </param>
        ///
        /// <returns>   An int. </returns>
        public int PassInfo()
        {
            using (var logfile = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "P_log.txt"))
            {

                logfile.WriteLine("Get plugin path.");
                var configPath = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName +
                                 ".dll";
                var fullassname = AssemblyName.GetAssemblyName(configPath);

                Console.WriteLine(configPath);
                EventWaitHandle result;
                logfile.WriteLine("Open wait handle.");
                EventWaitHandle.TryOpenExisting(@"Global\FinishedLoading",
                    EventWaitHandleRights.Synchronize | EventWaitHandleRights.Modify, out result);
                if (result != null)
                {
                    logfile.WriteLine("Handle Opened.");
                    eHandle = result;
                }
                else
                    logfile.WriteLine("Handle not found.");

                logfile.WriteLine("Set event handler data.");
                AppDomain.CurrentDomain.SetData("RegComEvents", new List<IntPtr>());
                AppDomain.CurrentDomain.SetData("RegChatEvents", new List<IntPtr>());
                AppDomain.CurrentDomain.SetData("RegHPEvents", new List<IntPtr>());

                logfile.WriteLine("Subscribe to AppDomain.UnhandledException");
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                logfile.WriteLine("Subscribe to AppDomain.DomainUnload");
                AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;

                logfile.WriteLine("Get resources path.");
                ConfigPath = Path.GetDirectoryName(Path.GetDirectoryName(configPath)) + "\\Resources";

                //logfile.WriteLine("Get function pointers.");
                //var fPtrs = _MapTo();
                //var count = 0;

                //logfile.WriteLine("Assign function pointers.");
                //foreach (var f in typeof (Funcs).GetFields().Where(f => f.Name != "GetEntity"))
                //{
                //    f.SetValue(null, Marshal.GetDelegateForFunctionPointer((IntPtr) fPtrs[count], f.FieldType));
                //    count++;
                //}
                logfile.WriteLine("Instantiate PluginMain:");
                Assembly pAssembly;
                try
                {
                    pAssembly = Assembly.UnsafeLoadFrom(configPath);
                }
                catch (Exception ex)
                {
                    MessageBox(IntPtr.Zero, ex.Message, "", 0);
                    return 0;
                }
                if (pAssembly.Equals(default(Assembly)))
                {
                    MessageBox(IntPtr.Zero, "Error loading Assembly.", "", 0);
                    return 0;
                }
                logfile.WriteLine("Get PluginMain Type.");
                var pMain = pAssembly.GetTypes().FirstOrDefault(t => t.Name == "PluginMain");
                if (pMain == default(Type))
                {
                    MessageBox(IntPtr.Zero, "Error finding Type.", "", 0);
                    return 0;
                }
                logfile.WriteLine("Get PluginMain Constructor.");
                var pConstuct = pMain.GetConstructors().FirstOrDefault(c => c.IsPublic);
                if (pConstuct == default(MethodInfo))
                {
                    MessageBox(IntPtr.Zero, "Error finding Constructor.", "", 0);
                    return 0;
                }
                logfile.WriteLine("Invoke Constructor.");
                pHandle = pConstuct.Invoke(null);
                logfile.WriteLine("Invoke Start().");
                var cleanUpPtr = (int)pHandle.GetType().GetMethod("Start").Invoke(pHandle, null);
                PCMobStruct.patchOffset = Funcs.GetPatchOffset();
                return cleanUpPtr;
            }
        }

        /// <summary>   Event handler. Called by CurrentDomain for domain unload events. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>

        static void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            var RegComEvents = (List<IntPtr>)AppDomain.CurrentDomain.GetData("RegComEvents");
            var RegChatEvents = (List<IntPtr>)AppDomain.CurrentDomain.GetData("RegChatEvents");
            var RegHPEvents = (List<IntPtr>)AppDomain.CurrentDomain.GetData("RegHPEvents");
            foreach (var regComEvent in RegComEvents)
                Funcs.UnRegisterCommandEvent(regComEvent);
            foreach (var regChatEvent in RegChatEvents)
                Funcs.UnRegisterChatEvent(regChatEvent);
            foreach (var regHPEvent in RegHPEvents)
                Funcs.UnRegisterHPEvent(regHPEvent);
            Console.WriteLine("{0} Unloaded", ((AppDomain)sender).FriendlyName);
        }

        /// <summary>   Raises a Finished signal. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>

        public static void SignalFinished()
        {
            if (eHandle == default(EventWaitHandle))
                return;
            eHandle.Set();
            eHandle.Close();

        }

        /// <summary>   Plugin self unload. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <returns>   An int. </returns>

        public static void PluginSelfUnload()
        {
            Funcs.UnloadIt(AppDomain.CurrentDomain.FriendlyName);
        }

        /// <summary>   Event handler. Called by CurrentDomain for unhandled exception events. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Unhandled exception event information. </param>

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            using (var logfile = File.AppendText("P_log.txt"))
                logfile.WriteLine(e.ExceptionObject.ToString());
        }
    }
}