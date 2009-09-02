using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Growl.Displays.Wpf
{
    public static class FullscreenDetector
    {
        private const int GWL_EXSTYLE = (-20);
        private const uint WS_EX_TOPMOST = 0x00000008;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        // This static method is required because Win32 does not support
        // GetWindowLongPtr directly
        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return GetWindowLongPtr32(hWnd, nIndex);
        }

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
            if (windowPlacement.showCmd == ShowCmd.Maximized ||
                (windowPlacement.rcNormalPosition.X == Screen.PrimaryScreen.Bounds.X &&
                windowPlacement.rcNormalPosition.Y == Screen.PrimaryScreen.Bounds.Y &&
                windowPlacement.rcNormalPosition.Width == Screen.PrimaryScreen.Bounds.Width &&
                windowPlacement.rcNormalPosition.Height == Screen.PrimaryScreen.Bounds.Height))
            {
                if ((GetWindowLongPtr(foregroundWindow, GWL_EXSTYLE).ToInt64() & WS_EX_TOPMOST) == WS_EX_TOPMOST)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
