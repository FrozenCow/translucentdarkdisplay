using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Growl.Displays.Wpf;
using MessageBox=System.Windows.Forms.MessageBox;

namespace Growl.Displays.TranslucentDark
{
    public class TranslucentDarkDisplay : WpfPopupDisplay
    {
        #region Display Style Information

        public override string Name
        {
            get { return "TranslucentDark"; }
        }

        public override string Description
        {
            get { return "Displays notifications in one translucent dark container."; }
        }

        public override string Version
        {
            get { return "1.5.0.0"; }
        }

        public override string Author
        {
            get { return "FrozenCow"; }
        }

        public override string Website
        {
            get { return "http://www.softwarebakery.com/frozencow/translucentdark.html"; }
        }

        #endregion

        public IList<GrowlNotification> PendingNotifications { get; private set; }
        private Timer _pendingTimer;

        public TranslucentDarkDisplay()
        {
            SettingsPanel = new TranslucentDarkSettingsPanel();
            PendingNotifications = new List<GrowlNotification>();
        }

        protected override void OpenNotification(GrowlNotification notification)
        {
            var settings = new TranslucentDarkSettings(SettingsCollection);
            if (settings.PauseOnFullscreen && FullscreenDetector.IsFullscreen())
            {
                QueueNotification(notification);
            }
            else
            {
                base.OpenNotification(notification);
            }
        }

        private void QueueNotification(GrowlNotification notification)
        {
            lock (PendingNotifications)
            {
                notification.Status = GrowlNotificationStatus.Pending;
                PendingNotifications.Add(notification);
                if (_pendingTimer == null)
                    _pendingTimer = new Timer(PendingTimerCallback, null, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
            }
        }

        private void PendingTimerCallback(object state)
        {
            var settings = new TranslucentDarkSettings(SettingsCollection);
            if (settings.PauseOnFullscreen && FullscreenDetector.IsFullscreen())
                return;
            IList<GrowlNotification> pendingNotifications;
            lock (PendingNotifications)
            {
                _pendingTimer.Dispose();
                _pendingTimer = null;

                pendingNotifications = new List<GrowlNotification>(PendingNotifications);
                PendingNotifications.Clear();
            }

            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                                                                                             {
                                                                                                 foreach (GrowlNotification notification in pendingNotifications)
                                                                                                     OpenNotification(notification);
                                                                                             }));
        }

        protected override GrowlPopup CreatePopup()
        {
            var popup = new TranslucentDarkPopup();
            var settings = new TranslucentDarkSettings(SettingsCollection);
            popup.NotificationWidth = settings.FixedWidth;
            popup.IconSize = settings.IconSize;
            popup.TextColor = WfColorToWpfColor(settings.TextColor);
            popup.ContainerColor = WfColorToWpfColor(settings.ContainerColor);
            popup.ShowIcon = settings.ShowIcon;
            popup.ShowTitle = settings.ShowTitle;
            popup.ShowDescription = settings.ShowDescription;

            popup.TitleFontFamily = GetFontFamily(settings.TitleFontFamily);
            popup.TitleFontSize = settings.TitleFontSize;
            popup.DescriptionFontFamily = GetFontFamily(settings.DescriptionFontFamily);
            popup.DescriptionFontSize = settings.DescriptionFontSize;

            PopupDocker.SetDockHorizontal(popup, settings.HorizontalPlacement);
            PopupDocker.SetDockVertical(popup, settings.VerticalPlacement);
            PopupDocker.SetDockedScreen(popup, settings.Screen);

            popup.Initialize();
            return popup;
        }

        private static FontFamily GetFontFamily(string name)
        {
            if (name == null)
                return null;
            try
            {
                return new FontFamily(name);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private static Color WfColorToWpfColor(System.Drawing.Color c)
        {
            return Color.FromArgb(c.A, c.R, c.G, c.B);
        }
    }
}