using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Provides IsPinned dependency-property to be used on <code>Window</code> instances that need to be pinned to the desktop.
    /// </summary>
    public static class WindowPinner
    {
        public static readonly DependencyProperty IsPinnedProperty = DependencyProperty.RegisterAttached("IsPinned", typeof(bool), typeof(WindowPinner), new PropertyMetadata(false, IsPinnedChanged));

        public static bool GetIsPinned(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPinnedProperty);
        }

        public static void SetIsPinned(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPinnedProperty, value);
        }

        private static void IsPinnedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var window = (Window)obj;
            var value = (bool)e.NewValue;

            SetPinned(window, value);
        }

        private static void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var window = (Window)sender;
            window.Loaded -= WindowLoaded;
            var valueObject = window.GetValue(IsPinnedProperty);
            if (valueObject is bool)
            {
                SetPinned(window, (bool)valueObject);
            }
        }

        private static void SetPinned(Window window, bool value)
        {
            var interopHelper = new WindowInteropHelper(window);
            var handle = interopHelper.Handle;
            if (handle == IntPtr.Zero)
            {
                window.SetValue(IsPinnedProperty, value);
                window.Loaded += WindowLoaded;
                return;
            }
            if (value)
                PinToDesktop(handle);
            else
                UnpinFromDesktop(handle);
        }

        #region Pin to Desktop

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private static void PinToDesktop(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("The specified handle can not be zero.");
            IntPtr hProgMan = FindWindow("Progman", null);
            if (IsWindow(hProgMan))
            {
                int result = SetParent(handle, hProgMan);
                if (result != 65556)
                    throw new Exception("Failed");
            }
        }

        private static void UnpinFromDesktop(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("The specified handle can not be zero.");
            SetParent(handle, IntPtr.Zero);
        }

        #endregion
    }
}