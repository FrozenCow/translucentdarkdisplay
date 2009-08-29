using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Growl.CoreLibrary;
using Growl.DisplayStyle;
using System.Diagnostics;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Provides the generic functionality for Growl Displays based upon Wpf.
    /// </summary>
    public abstract class WpfDisplay : CleanDisplay
    {
        private readonly MultiTimeout _timeouts = new MultiTimeout();

        #region Growl handling

        public override bool ProcessNotification(Notification notification, string displayName)
        {
            WpfApplicationManager.StartWpf();

            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action<Notification>(delegate(Notification n)
                                                                           {
                                                                               var growlNotification = CreateGrowlNotification(n);
                                                                               OpenNotification(growlNotification);
                                                                           }), notification);
            return false;
        }

        public override void CloseLastNotification()
        {
            if (Application.Current == null)
                return;
            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate
                                                             {
                                                                 GrowlNotification lastNotification = GetLastNotification();
                                                                 if (lastNotification != null)
                                                                     CloseNotification(lastNotification);
                                                             }));
        }

        public override void CloseAllOpenNotifications()
        {
            if (Application.Current == null)
                return;
            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(CloseNotifications));
        }

        #endregion

        #region Helper methods

        protected virtual GrowlNotification CreateGrowlNotification(Notification notification)
        {
            var growlNotification = new GrowlNotification
                                        {
                                            OriginalNotification = notification,
                                            Title = notification.Title,
                                            Description = notification.Description,
                                            IsSticky = notification.Sticky,
                                            TimeoutDuration = notification.Sticky
                                                                  ? TimeSpan.Zero
                                                                  : notification.Duration == 0
                                                                        ? (TimeSpan)GrowlNotification.TimeoutDurationProperty.DefaultMetadata.DefaultValue
                                                                        : TimeSpan.FromSeconds(notification.Duration)
                                        };

            // Fill the custom attributes.
            if (notification.CustomTextAttributes != null)
            {
                foreach (KeyValuePair<string, string> pair in notification.CustomTextAttributes)
                    growlNotification.CustomTextAttributes.Add(pair);
            }

            // Creating image-source from the supplied url or binary data.
            BitmapImage image = null;
            Uri imageUri;
            if (notification.Image.IsUrl && Uri.TryCreate(notification.Image.Url, UriKind.Absolute, out imageUri))
            {
                image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(notification.Image.Url);
                image.CacheOption = BitmapCacheOption.OnLoad;
                try
                {
                    image.EndInit();
                }
                // This is very hacky, but the MSDN documentation does not state all of the possible exceptions.
                catch
                {
                    image = null;
                }
            }
            else if (notification.Image.IsRawData)
            {
                using (var stream = new MemoryStream(notification.Image.Data, 0, notification.Image.Data.Length))
                {
                    image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.CreateOptions = BitmapCreateOptions.None;
                    image.StreamSource = stream;
                    try
                    {
                        image.EndInit();
                    }
                    // Again very hacky. Again for the same reason.
                    catch
                    {
                        image = null;
                    }
                }
            }
            growlNotification.Image = image;

            return growlNotification;
        }

        protected virtual GrowlNotification GetLastNotification()
        {
            return null;
        }

        #endregion

        #region Timeout methods

        protected void StartNotificationTimeout(GrowlNotification notification, TimeSpan duration)
        {
            // Don't look! This code is ugly!
            _timeouts.AddTimeout(
                duration,
                delegate { Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action<GrowlNotification>(TimeoutNotification), notification); },
                notification);
        }

        protected void CancelNotificationTimeout(GrowlNotification notification)
        {
            _timeouts.RemoveTimeout(notification);
        }

        #endregion

        #region Notification methods

        protected virtual void OpenNotification(GrowlNotification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            notification.Status = GrowlNotificationStatus.Opening;
            if (notification.TimeoutDuration != TimeSpan.Zero)
                StartNotificationTimeout(notification, notification.TimeoutDuration);
            OnNotificationOpened(notification);
        }

        protected virtual void ClickNotification(GrowlNotification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            notification.Status = GrowlNotificationStatus.Clicking;
            CancelNotificationTimeout(notification);
            OnNotificationClicked(notification);
        }

        protected virtual void TimeoutNotification(GrowlNotification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            notification.Status = GrowlNotificationStatus.Timingout;
            CancelNotificationTimeout(notification);
            OnNotificationTimedout(notification);
        }

        protected virtual void CloseNotification(GrowlNotification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            notification.Status = GrowlNotificationStatus.Closing;
            CancelNotificationTimeout(notification);
            OnNotificationClosed(notification);
        }

        protected virtual void CloseNotifications()
        {
        }

        #endregion

        #region Notification event methods

        protected virtual void OnNotificationOpened(GrowlNotification notification)
        {
            notification.Status = GrowlNotificationStatus.Opened;
        }

        protected virtual void OnNotificationClicked(GrowlNotification notification)
        {
            notification.Status = GrowlNotificationStatus.Clicked;
            OnNotificationClicked(new NotificationCallbackEventArgs(notification.OriginalNotification.UUID, CallbackResult.CLICK));
        }

        protected virtual void OnNotificationTimedout(GrowlNotification notification)
        {
            notification.Status = GrowlNotificationStatus.Timedout;
            OnNotificationClosed(new NotificationCallbackEventArgs(notification.OriginalNotification.UUID, CallbackResult.TIMEDOUT));
        }

        protected virtual void OnNotificationClosed(GrowlNotification notification)
        {
            notification.Status = GrowlNotificationStatus.Closed;
            OnNotificationClosed(new NotificationCallbackEventArgs(notification.OriginalNotification.UUID, CallbackResult.CLOSE));
        }

        #endregion
    }
}