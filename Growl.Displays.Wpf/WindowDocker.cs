using System;
using System.Windows;
using System.Windows.Forms;
using HorizontalAlignment=System.Windows.HorizontalAlignment;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Provides dependency-properties to be used on <code>Window</code> instances that need to be docked inside the working area of a screen.
    /// </summary>
    public static class WindowDocker
    {
        #region DockedScreen Property

        public static readonly DependencyProperty DockedScreenProperty = DependencyProperty.RegisterAttached("DockedScreen", typeof(int), typeof(WindowDocker), new PropertyMetadata(-1, DockedScreenChanged));

        public static int GetDockedScreen(DependencyObject obj)
        {
            return (int)obj.GetValue(DockedScreenProperty);
        }

        public static void SetDockedScreen(DependencyObject obj, int value)
        {
            obj.SetValue(DockedScreenProperty, value);
        }

        #endregion

        #region DockHorizontal Property

        public static readonly DependencyProperty DockHorizontalProperty = DependencyProperty.RegisterAttached("DockHorizontal", typeof(HorizontalAlignment), typeof(WindowDocker), new PropertyMetadata(HorizontalAlignment.Stretch, DockHorizontalChanged));

        public static HorizontalAlignment GetDockHorizontal(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(DockHorizontalProperty);
        }

        public static void SetDockHorizontal(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(DockHorizontalProperty, value);
        }

        #endregion

        #region DockVertical Property

        public static readonly DependencyProperty DockVerticalProperty = DependencyProperty.RegisterAttached("DockVertical", typeof(VerticalAlignment), typeof(WindowDocker), new PropertyMetadata(VerticalAlignment.Stretch, DockVerticalChanged));

        public static VerticalAlignment GetDockVertical(DependencyObject obj)
        {
            return (VerticalAlignment)obj.GetValue(DockVerticalProperty);
        }

        public static void SetDockVertical(DependencyObject obj, VerticalAlignment value)
        {
            obj.SetValue(DockVerticalProperty, value);
        }

        #endregion

        private static void DockedScreenChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var window = (Window)obj;
            var value = (int)e.NewValue;

            SetDocked(window, value);
        }

        private static void DockHorizontalChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var window = (Window)obj;
            if (GetDockedScreen(window) >= 0)
                RelocateWindow(window);
        }

        private static void DockVerticalChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var window = (Window)obj;
            if (GetDockedScreen(window) >= 0)
                RelocateWindow(window);
        }

        private static void SetDocked(Window window, int value)
        {
            if (value >= 0)
            {
                window.Loaded += PopupLoaded;
                window.LocationChanged += WindowLocationChanged;
                window.SizeChanged += WindowSizeChanged;
                RelocateWindow(window);
            }
            else
            {
                window.Loaded -= PopupLoaded;
                window.LocationChanged -= WindowLocationChanged;
                window.SizeChanged -= WindowSizeChanged;
            }
        }

        private static void PopupLoaded(object sender, RoutedEventArgs e)
        {
            RelocateWindow((Window)sender);
        }

        private static void WindowLocationChanged(object sender, EventArgs e)
        {
            RelocateWindow((Window)sender);
        }

        private static void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            RelocateWindow((Window)sender);
        }

        public static void RelocateWindow(Window window)
        {
            int dockedScreenIndex = GetDockedScreen(window);
            if (dockedScreenIndex < 0)
                return;

            Screen dockedScreen;
            if (dockedScreenIndex < Screen.AllScreens.Length)
                dockedScreen = Screen.AllScreens[dockedScreenIndex];
            else
                dockedScreen = Screen.PrimaryScreen;

            var workingArea = dockedScreen.WorkingArea;

            var windowWidth = window.Width;
            var windowHeight = window.Height;

            var areaLeft = workingArea.Left;
            var areaTop = workingArea.Top;
            var areaWidth = workingArea.Width;
            var areaHeight = workingArea.Height;

            var windowLeft = 0.0;
            var windowTop = 0.0;

            HorizontalAlignment horizontal = GetDockHorizontal(window);
            VerticalAlignment vertical = GetDockVertical(window);

            switch (horizontal)
            {
                case HorizontalAlignment.Left:
                    windowLeft = areaLeft;
                    break;
                case HorizontalAlignment.Center:
                    windowLeft = areaLeft + (areaWidth / 2 - windowWidth / 2);
                    break;
                case HorizontalAlignment.Right:
                    windowLeft = areaLeft + areaWidth - windowWidth;
                    break;
                case HorizontalAlignment.Stretch:
                    windowLeft = areaLeft;
                    windowWidth = areaWidth;
                    break;
            }

            switch (vertical)
            {
                case VerticalAlignment.Top:
                    windowTop = areaTop;
                    break;
                case VerticalAlignment.Center:
                    windowTop = areaTop + (areaHeight / 2 - windowHeight / 2);
                    break;
                case VerticalAlignment.Bottom:
                    windowTop = areaTop + areaHeight - windowHeight;
                    break;
                case VerticalAlignment.Stretch:
                    windowTop = areaTop;
                    windowHeight = areaHeight;
                    break;
            }
            if ((windowTop < areaTop) || (windowTop + windowHeight > areaTop + areaHeight))
            {
                windowTop = areaTop;
                windowHeight = areaHeight;
            }
            if ((windowLeft < areaLeft) || (windowLeft + windowWidth > areaLeft + areaWidth))
            {
                windowLeft = areaLeft;
                windowWidth = areaWidth;
            }
            var popupLocation = new Point(windowLeft, windowTop);
            if (horizontal == HorizontalAlignment.Stretch)
                window.Width = areaWidth;
            if (vertical == VerticalAlignment.Stretch)
                window.Height = areaHeight;
            window.Left = windowLeft;
            window.Height = windowHeight;
        }
    }
}