using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using BolterLib;

namespace BolterShim
{
    public class DomainActivation
    {
        public HostAdapter MyHostAdapter;
        public IntPtr InterfacePtr;
        private readonly Dictionary<string, AppDomain> _loadedDomains; 
        public DomainActivation()
        {
            MyHostAdapter = new HostAdapter();
            InterfacePtr = HostAdapter.HostInterfaceExchangePtr;
            _loadedDomains = new Dictionary<string, AppDomain>();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject);
        }

        public void ActivateScript(string scriptName)
        {
            var dset = new AppDomainSetup { ApplicationBase = AppDomain.CurrentDomain.BaseDirectory, PrivateBinPath = AppDomain.CurrentDomain.BaseDirectory };
            var newDomain = AppDomain.CreateDomain(scriptName, AppDomain.CurrentDomain.Evidence,
                dset);
            newDomain.SetData("pGetInterface", InterfacePtr.ToInt32());
            var imports =
                File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\Scripts\\" + scriptName + ".cs")
                    .SkipWhile(l => !l.Contains("* Imports"))
                    .TakeWhile(l2 => !l2.Contains("*/"))
                    .Where(imp => !imp.Contains("* Imports"))
                    .Select(import => Regex.Replace(import,@"[\n\r( \* )]",string.Empty))
                    .ToList();
            
            newDomain.SetData("RefAss", imports);

            newDomain.DoCallBack(() =>
            {
                var newAssembly = Assembly.UnsafeLoadFrom(AppDomain.CurrentDomain.BaseDirectory + "\\BolterInterface.dll");
                newAssembly.GetType("BolterInterface.InterDomainOps")
                    .GetConstructors()
                    .First(c => c.IsPublic)
                    .Invoke(null);
            });
            _loadedDomains.Add(scriptName, newDomain);
        }

        public void DeactivateScript(string scriptName)
        {
            AppDomain.Unload(_loadedDomains[scriptName]);
            _loadedDomains.Remove(scriptName);
        }
    }
}
