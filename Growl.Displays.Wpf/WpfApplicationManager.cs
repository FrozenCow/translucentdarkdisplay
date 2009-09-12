using System;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Provides the ability to start and manage an WPF application in an Windows Forms environment.
    /// </summary>
    public static class WpfApplicationManager
    {
        private static readonly object _applicationLock = new object();

        private static Application Application
        {
            get { return Application.Current; }
        }

        /// <summary>
        /// Starts WPF if it isn't already started.
        /// </summary>
        public static void StartWpf()
        {
            lock (_applicationLock)
            {
                if (Application != null)
                    return;

                // HACK: Unload does NOT get called when Growl is exiting. Application.ApplicationExit DOES get called.
                System.Windows.Forms.Application.ApplicationExit += OnApplicationExit;

                var wpfThread = new Thread(RunWpf);
                wpfThread.SetApartmentState(ApartmentState.STA);

                wpfThread.Start();
                Monitor.Wait(_applicationLock);
            }
        }

        private static void RunWpf()
        {
            Monitor.Enter(_applicationLock);
            var application = new Application();
            application.Startup += delegate
                                   {
                                       Monitor.PulseAll(_applicationLock);
                                       Monitor.Exit(_applicationLock);
                                   };
            try
            {
                application.Run();
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException is TargetInvocationException)
                    throw e.InnerException.InnerException;
                throw;
            }
        }

        private static void ShutdownWpf()
        {
            lock (_applicationLock)
            {
                System.Windows.Forms.Application.ApplicationExit -= OnApplicationExit;
                if (Application != null)
                {
                    DispatchAction(delegate
                                   {
                                       if (Application != null)
                                           Application.Shutdown();
                                   });
                }
            }
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            ShutdownWpf();
        }

        private static void DispatchAction(Action action)
        {
            if (!Application.Dispatcher.CheckAccess())
                Application.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, action);
            else
                action();
        }
    }
}