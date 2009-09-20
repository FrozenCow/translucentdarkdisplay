﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using Growl.Displays.Wpf;
using System.Windows.Forms;
using Timer = System.Threading.Timer;
using System.Threading;
using System;
using System.Windows.Threading;

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
        private Timer pendingTimer;

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
                lock (PendingNotifications)
                {
                    notification.Status = GrowlNotificationStatus.Pending;
                    PendingNotifications.Add(notification);
                    if (pendingTimer == null)
                        pendingTimer = new Timer(PendingTimerCallback, null, TimeSpan.FromSeconds(10),  TimeSpan.FromSeconds(10));
                }
            }
            else
                base.OpenNotification(notification);
        }

        private void PendingTimerCallback(object state)
        {
            var settings = new TranslucentDarkSettings(SettingsCollection);
            if (settings.PauseOnFullscreen && FullscreenDetector.IsFullscreen())
                return;
            IList<GrowlNotification> pendingNotifications;
            lock (PendingNotifications)
            {
                pendingTimer.Dispose();
                pendingTimer = null;

                pendingNotifications = new List<GrowlNotification>(PendingNotifications);
                PendingNotifications.Clear();
            }

            System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
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
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }

        private static System.Windows.Media.Color WfColorToWpfColor(System.Drawing.Color c)
        {
            return System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
        }
    }
}