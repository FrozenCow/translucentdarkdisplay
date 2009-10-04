using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Growl.Displays.Wpf
{
    public static class FullscreenDetector
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        private enum ShowCmd
        {
            Normal = 1,
            Minimized = 2,
            Maximized = 3
        }

        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public ShowCmd showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        public static bool IsFullscreen()
        {
            IntPtr foregroundWindow = GetForegroundWindow();
            WINDOWPLACEMENT windowPlacement = default(WINDOWPLACEMENT);
            if (!GetWindowPlacement(foregroundWindow, ref windowPlacement))
                return false;
            return (windowPlacement.rcNormalPosition.X == Screen.PrimaryScreen.Bounds.X &&
                    windowPlacement.rcNormalPosition.Y == Screen.PrimaryScreen.Bounds.Y &&
                    windowPlacement.rcNormalPosition.Width == Screen.PrimaryScreen.Bounds.Width &&
                    windowPlacement.rcNormalPosition.Height == Screen.PrimaryScreen.Bounds.Height);
        }
    }
}
