using System;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BolterInterface;
using Microsoft.CSharp;

namespace BolterLib
{
    public class ScriptEngine : IScriptEngine
    {
        private readonly CSharpCodeProvider _compiler;
        public readonly Dictionary<CSScript, object> LoadedScripts;
        private const string XmlExt = ".xml";
        private const string CsExt = ".cs";
        private readonly string _scriptPath;
        private ICommandEventHandler _commandEventHandler;

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
                comPara.ReferencedAssemblies.Add(typeof (IScriptEngine).Assembly.Location);
                return comPara;
            }
        }

        public ScriptEngine()
        {
            _compiler = new CSharpCodeProvider();
            LoadedScripts = new Dictionary<CSScript, object>();
            _scriptPath = Path.GetDirectoryName(InterProcessCom.ConfigPath) + "\\Plugins\\SharpScripts\\";
            _commandEventHandler = new CommandEventHandler {OnCommand = OnCommand};
        }

        public void LoadScript(string scriptName)
        {
            var compilerParams = CompilerParams;
            var referencedAssemblies = XmlSerializationHelper.Deserialize<Imports>(_scriptPath + scriptName + XmlExt);
            foreach (var mod in referencedAssemblies.Modules)
                compilerParams.ReferencedAssemblies.Add(mod.Name);

            var loadedScript = _compiler.CompileAssemblyFromFile(compilerParams,
                new[] {_scriptPath + scriptName + CsExt});

            var entryClass = GetEntryClass(loadedScript);
            if (entryClass == default (Type))
            {
                InterProcessCom.MessageBox(new IntPtr(0), "ScriptEntryClass not set!", "Error", 0);
                return;
            }

            var entryConstructor = GetEntryConstructor(entryClass);
            if (entryConstructor == default(ConstructorInfo))
            {
                InterProcessCom.MessageBox(new IntPtr(0), "ScriptEntryPoint not set!", "Error", 0);
                return;
            }

            var entryObject = entryConstructor.Invoke(null);
            var scriptRef = new CSScript(loadedScript, scriptName);
            LoadedScripts.Add(scriptRef, entryObject);
            RegisterEvents(entryClass, entryObject, scriptRef);

            Chat.SendCommand(string.Format("/echo {0} script loaded.", scriptName));
        }

        private Type GetEntryClass(CompilerResults results)
        {
            return results.CompiledAssembly.GetTypes()
                .FirstOrDefault(
                    t =>
                        t.CustomAttributes != null && t.CustomAttributes.Any() &&
                        t.CustomAttributes.First().AttributeType == typeof (ScriptEntryClass));
        }

        private ConstructorInfo GetEntryConstructor(Type entryClass)
        {
            return entryClass.GetConstructors()
                .FirstOrDefault(
                    c =>
                        c.CustomAttributes != null && c.CustomAttributes.Any() &&
                        c.CustomAttributes.First().AttributeType == typeof (ScriptEntryPoint));
        }

        private void RegisterEvents(Type entryClass, object entryObject, CSScript scriptRef)
        {
            var chatEvents = entryClass.GetMethods().FirstOrDefault(m =>
                m.CustomAttributes != null && m.CustomAttributes.Any() &&
                m.CustomAttributes.First().AttributeType == typeof (OnNewChatLineEvent));

            if (chatEvents != default (MethodInfo))
            {
                scriptRef.RegChatEvents = new ChatEventHandler();
                var scriptChatDelegate = chatEvents.CreateDelegate(typeof (ChatEventHandler.ChatEvent), entryObject);
                typeof (ChatEventHandler).GetProperty("OnChatLine")
                    .SetValue(scriptRef.RegChatEvents, scriptChatDelegate);

            }

            var commandEvents = entryClass.GetMethods().FirstOrDefault(m =>
                m.CustomAttributes != null && m.CustomAttributes.Any() &&
                m.CustomAttributes.First().AttributeType == typeof (OnCommandEvent));

            if (commandEvents != default(MethodInfo))
            {
                scriptRef.RegCommandEvents = new CommandEventHandler();
                var scriptCommandDelegate = commandEvents.CreateDelegate(typeof (CommandEventHandler.CommandEvent),
                    entryObject);
                typeof (CommandEventHandler).GetProperty("OnCommand")
                    .SetValue(scriptRef.RegCommandEvents, scriptCommandDelegate);
            }
        }

        public void UnloadScript(string name)
        {
            var scriptToUnload = LoadedScripts.FirstOrDefault(sc => sc.Key.Name == name);
            if (scriptToUnload.Equals(default(KeyValuePair<CSScript, object>)))
                return;
            if (scriptToUnload.Key.RegChatEvents != null)
                scriptToUnload.Key.RegChatEvents.OnChatLine = null;
            if (scriptToUnload.Key.RegCommandEvents != null)
                scriptToUnload.Key.RegCommandEvents.OnCommand = null;
            scriptToUnload.Key.Code = null;
            LoadedScripts.Remove(scriptToUnload.Key);
            GC.Collect();
            Chat.SendCommand(string.Format("/echo {0} script unloaded.", name));
        }

        public int OnCommand(StringBuilder pCommand)
        {
            if (pCommand.ToString().StartsWith("/SS", true, CultureInfo.InvariantCulture))
            {
                var args = pCommand.ToString().Split(' ');
                if (args.Length > 2)
                {
                    switch (args[1])
                    {
                        case "load":
                            LoadScript(args[2]);
                            return 1;
                        case "unload":
                            UnloadScript(args[2]);
                            return 1;
                        default:
                            Chat.SendCommand("/echo Bad Command");
                            return 1;
                    }
                }
            }
            return 0;
        }
    }

    public class CSScript
    {
        public CSScript(CompilerResults code, string name)
        {
            Code = code;
            Name = name;
        }
        public CompilerResults Code;
        public string Name;
        public ChatEventHandler RegChatEvents;
        public CommandEventHandler RegCommandEvents;
    }
}
