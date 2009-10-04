using System;
using System.Collections.Generic;
using System.Linq;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Provides the generic functionality for Growl Displays based upon Wpf using the <code>Popup</code> class.
    /// </summary>
    public abstract class WpfPopupDisplay : WpfDisplay
    {
        #region Properties

        public GrowlPopup NotificationsPopup { get; set; }

        #endregion

        protected abstract GrowlPopup CreatePopup();

        protected virtual void EnsurePopup()
        {
            if (NotificationsPopup != null)
                return;
            NotificationsPopup = CreatePopup();
            if (NotificationsPopup == null)
                throw new Exception("The GrowlPopup was not created! Make sure CreatePopup always returns an instance.");
            NotificationsPopup.NotificationOpened += NotificationsPopupNotificationOpened;
            NotificationsPopup.NotificationClicked += NotificationsPopupNotificationClicked;
            NotificationsPopup.NotificationClosed += NotificationsPopupNotificationClosed;
            NotificationsPopup.NotificationTimedout += NotificationsPopupNotificationTimedout;
            NotificationsPopup.Closed += NotificationsPopupClosed;
        }

        #region NotificationsPopup Event Handlers

        private void NotificationsPopupNotificationOpened(object sender, GrowlNotificationEventArgs e)
        {
            OnNotificationOpened(e.Notification);
        }

        private void NotificationsPopupNotificationTimedout(object sender, GrowlNotificationEventArgs e)
        {
            OnNotificationTimedout(e.Notification);
        }

        private void NotificationsPopupNotificationClicked(object sender, GrowlNotificationEventArgs e)
        {
            OnNotificationClicked(e.Notification);
        }

        private void NotificationsPopupNotificationClosed(object sender, GrowlNotificationEventArgs e)
        {
            OnNotificationClosed(e.Notification);
        }

        private void NotificationsPopupClosed(object sender, EventArgs e)
        {
            var senderPopup = (GrowlPopup)sender;
            if (senderPopup == NotificationsPopup)
                NotificationsPopup = null;
        }

        #endregion

        #region WpfDisplay Members

        protected override void OpenNotification(GrowlNotification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            EnsurePopup();
            notification.Status = GrowlNotificationStatus.Opening;
            if (notification.TimeoutDuration != TimeSpan.Zero)
                StartNotificationTimeout(notification, notification.TimeoutDuration);
            NotificationsPopup.OpenNotification(notification);
        }

        protected override void TimeoutNotification(GrowlNotification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            if (NotificationsPopup == null)
                return;
            CancelNotificationTimeout(notification);
            notification.Status = GrowlNotificationStatus.Timingout;
            NotificationsPopup.TimeoutNotification(notification);
        }

        protected override void CloseNotification(GrowlNotification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            if (NotificationsPopup == null)
                return;
            CancelNotificationTimeout(notification);
            notification.Status = GrowlNotificationStatus.Closing;
            NotificationsPopup.CloseNotification(notification);
        }

        protected override void ClickNotification(GrowlNotification notification)
        {
            if (notification == null)
                throw new ArgumentNullException("notification");
            if (NotificationsPopup == null)
                return;
            CancelNotificationTimeout(notification);
            notification.Status = GrowlNotificationStatus.Clicking;
            NotificationsPopup.ClickNotification(notification);
        }

        protected override void CloseNotifications()
        {
            if (NotificationsPopup == null)
                return;
            var notifications = new List<GrowlNotification>(NotificationsPopup.Notifications
                                                                .Where(CanCloseNotification));
            foreach (GrowlNotification notification in notifications)
                CloseNotification(notification);
            base.CloseNotifications();
        }

        protected override GrowlNotification GetLastNotification()
        {
            if (NotificationsPopup == null)
                return null;
            return NotificationsPopup.Notifications.FirstOrDefault(CanCloseNotification);
        }

        #endregion

        #region Helper methods

        protected virtual bool CanCloseNotification(GrowlNotification notification)
        {
            return notification.Status != GrowlNotificationStatus.Closing ||
                   notification.Status != GrowlNotificationStatus.Closed;
        }

        #endregion
    }

    public abstract class WpfPopupDisplay<T> : WpfPopupDisplay
        where T : GrowlPopup, new()
    {
        protected override GrowlPopup CreatePopup()
        {
            return new T();
        }
    }
}