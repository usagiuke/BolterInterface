// file:	ScriptEngine.cs
//
// summary:	Implements the script engine class

using System;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Microsoft.CSharp;

namespace BolterInterface
{
    /// <summary>   A script engine. </summary>
    ///
    /// <remarks>   Revy, 8/11/2014. </remarks>

    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class ScriptEngine
    {
        /// <summary>   The compiler. </summary>
        private readonly CSharpCodeProvider _compiler;
        /// <summary>   Full pathname of the script file. </summary>
        private readonly string _scriptPath;
        /// <summary>   The referenced assemblies. </summary>
        private readonly List<string> _referencedAssemblies;
        /// <summary>   The loaded script. </summary>
        private readonly CSScript _loadedScript;
        /// <summary>   The event binder. </summary>
        private object eventBinder;
        /// <summary>   The second event binder. </summary>
        private object eventBinder2;
        /// <summary>   The entry object. </summary>
        private object entryObject;

        /// <summary>   Gets options for controlling the compiler. </summary>
        ///
        /// <value> Options that control the compiler. </value>

        private CompilerParameters CompilerParams
        {
            get
            {
                var comPara = new CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true,
                    IncludeDebugInformation = false
                };
                comPara.ReferencedAssemblies.Add(GetType().Assembly.Location);
                return comPara;
            }
        }

        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>

        public ScriptEngine()
        {
            _compiler = new CSharpCodeProvider();
            _loadedScript = new CSScript();
            _scriptPath = AppDomain.CurrentDomain.BaseDirectory + "\\Scripts\\" + AppDomain.CurrentDomain.FriendlyName + ".cs";
            _referencedAssemblies = (List<string>)AppDomain.CurrentDomain.GetData("RefAss");
            AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        /// <summary>   Event handler. Called by CurrentDomain for unhandled exception events. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <param name="sender" type="object">                 Source of the event. </param>
        /// <param name="e" type="UnhandledExceptionEventArgs">
        ///     Unhandled exception event information.
        /// </param>

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            
        }

        /// <summary>   Event handler. Called by CurrentDomain for domain unload events. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <param name="sender" type="object"> Source of the event. </param>
        /// <param name="e" type="EventArgs">   Event information. </param>

        void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            UnloadScript();
        }

        /// <summary>   Loads the script. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>

        public void LoadScript()
        {
            var compilerParams = CompilerParams;
            foreach (var mod in _referencedAssemblies)
                compilerParams.ReferencedAssemblies.Add(mod);

            var loadedScript = _compiler.CompileAssemblyFromFile(compilerParams,
                new[] { _scriptPath });

            var entryClass = GetEntryClass(loadedScript);
            if (entryClass == default(Type))
            {
                return;
            }

            var entryConstructor = GetEntryConstructor(entryClass);
            if (entryConstructor == default(ConstructorInfo))
            {
                return;
            }

            entryObject = entryConstructor.Invoke(null);
            _loadedScript.Code = loadedScript;
            _loadedScript.Name = _scriptPath;
            RegisterEvents(entryClass, entryObject);

        }

        /// <summary>   Gets entry class. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <param name="results" type="CompilerResults">   The results. </param>
        ///
        /// <returns>   The entry class. </returns>

        private Type GetEntryClass(CompilerResults results)
        {
            return results.CompiledAssembly.GetTypes()
                .FirstOrDefault(
                    t =>
                        t.CustomAttributes != null && t.CustomAttributes.Any() &&
                        t.CustomAttributes.First().AttributeType == typeof(ScriptEntryClass));
        }

        /// <summary>   Gets entry constructor. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <param name="entryClass" type="Type">   The entry class. </param>
        ///
        /// <returns>   The entry constructor. </returns>

        private ConstructorInfo GetEntryConstructor(Type entryClass)
        {
            return entryClass.GetConstructors()
                .FirstOrDefault(
                    c =>
                        c.CustomAttributes != null && c.CustomAttributes.Any() &&
                        c.CustomAttributes.First().AttributeType == typeof(ScriptEntryPoint));
        }

        /// <summary>   Registers the events. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>
        ///
        /// <param name="entryClass" type="Type">       The entry class. </param>
        /// <param name="entryObject" type="object">    The entry object. </param>

        private void RegisterEvents(Type entryClass, object entryObject)
        {
            var chatEvents = entryClass.GetMethods().FirstOrDefault(m =>
                m.CustomAttributes != null && m.CustomAttributes.Any() &&
                m.CustomAttributes.First().AttributeType == typeof(OnNewChatLineEvent));

            if (chatEvents != default(MethodInfo))
            {
                _loadedScript.RegChatEvents = Bolter.GlobalInterface.GetChatEventHandlerObject();
                var scriptChatDelegate = chatEvents.CreateDelegate(typeof(Func<StringBuilder, int>), entryObject);
                var dPtr = InterDomainOps.GetFunctionPointerForGenericDelegate((Func<StringBuilder, int>)scriptChatDelegate, out eventBinder);

                typeof(IChatEventHandler).GetProperty("OnChatLine")
                    .SetValue(_loadedScript.RegChatEvents, dPtr);

            }

            var commandEvents = entryClass.GetMethods().FirstOrDefault(m =>
                m.CustomAttributes != null && m.CustomAttributes.Any() &&
                m.CustomAttributes.First().AttributeType == typeof(OnCommandEvent));

            if (commandEvents != default(MethodInfo))
            {
                _loadedScript.RegCommandEvents = Bolter.GlobalInterface.GetCommandEventHandlerObject();
                var scriptCommandDelegate = commandEvents.CreateDelegate(typeof(Func<StringBuilder, int>),
                    entryObject);
                var dPtr = InterDomainOps.GetFunctionPointerForGenericDelegate((Func<StringBuilder, int>)scriptCommandDelegate, out eventBinder2);
                typeof(ICommandEventHandler).GetProperty("OnCommand")
                    .SetValue(_loadedScript.RegCommandEvents, dPtr);
            }
        }

        /// <summary>   Unload script. </summary>
        ///
        /// <remarks>   Revy, 8/11/2014. </remarks>

        public void UnloadScript()
        {
            if (_loadedScript.RegChatEvents != null)
            {
                typeof(IChatEventHandler).GetProperty("OnChatLine")
                    .SetValue(_loadedScript.RegChatEvents, IntPtr.Zero);
                eventBinder = null;
                _loadedScript.RegChatEvents = null;
            }
            if (_loadedScript.RegCommandEvents != null)
            {
                typeof(ICommandEventHandler).GetProperty("OnCommand")
                    .SetValue(_loadedScript.RegCommandEvents, IntPtr.Zero);
                eventBinder2 = null;
                _loadedScript.RegCommandEvents = null;
            }
            entryObject = null;
            _loadedScript.Code = null;
        }
    }

    /// <summary>   A create struct script. </summary>
    ///
    /// <remarks>   Revy, 8/11/2014. </remarks>

    public class CSScript
    {
        /// <summary>   The code. </summary>
        public CompilerResults Code;
        /// <summary>   The name. </summary>
        public string Name;
        /// <summary>   The register chat events. </summary>
        public IChatEventHandler RegChatEvents;
        /// <summary>   The register command events. </summary>
        public ICommandEventHandler RegCommandEvents;
    }

}
