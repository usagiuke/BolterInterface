using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace BolterInterface
{
    public interface IWindow
    {
        void Show();
    }

    public class PluginWithWPF<T> where T : IWindow, new()
    {
        protected T PluginWindow;
        protected Thread MainThread;

        public PluginWithWPF()
        {
            PluginWindow = default(T);
            var waitOn = new EventWaitHandle(false, EventResetMode.AutoReset);

            MainThread = new Thread(() =>
            {
                PluginWindow = new T();
                PluginWindow.Show();
                var dispatcherRun = PluginWindow.GetType().GetProperty("Dispatcher").PropertyType.GetMethod("Run", BindingFlags.Public | BindingFlags.Static);
                waitOn.Set();
                dispatcherRun.Invoke(null, null);
            });
            MainThread.SetApartmentState(ApartmentState.STA);
            MainThread.IsBackground = true;
            MainThread.Start();

            waitOn.WaitOne();
        }

    }
}
