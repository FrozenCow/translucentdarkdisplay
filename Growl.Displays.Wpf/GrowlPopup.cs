using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Provides the generic functionality of a popup that displays <code>GrowlNotification</code>s.
    /// </summary>
    public class GrowlPopup : Popup
    {
        #region Properties

        #region Notifications

        public ObservableCollection<GrowlNotification> Notifications
        {
            get { return (ObservableCollection<GrowlNotification>)GetValue(NotificationsProperty); }
            set { SetValue(NotificationsProperty, value); }
        }

        public static readonly DependencyProperty NotificationsProperty = DependencyProperty.Register("Notifications", typeof(ObservableCollection<GrowlNotification>), typeof(GrowlPopup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        #endregion

        #endregion

        #region Constructors

        public GrowlPopup()
        {
            Notifications = new ObservableCollection<GrowlNotification>();
            StaysOpen = true;
            AllowsTransparency = true;
        }

        #endregion

        #region Animation Methods

        #region Timeout Animation

        protected virtual void BeginTimeoutAnimation(GrowlNotification notification)
        {
            EndTimeoutAnimation(notification);
        }

        protected virtual void EndTimeoutAnimation(GrowlNotification notification)
        {
            RemoveNotification(notification);
            OnNotificationTimedout(new GrowlNotificationEventArgs(notification));
        }

        #endregion

        #region Close Animation

        protected virtual void BeginCloseAnimation(GrowlNotification notification)
        {
            EndCloseAnimation(notification);
        }

        protected virtual void EndCloseAnimation(GrowlNotification notification)
        {
            RemoveNotification(notification);
            OnNotificationClosed(new GrowlNotificationEventArgs(notification));
        }

        #endregion

        #region Click Animation

        protected virtual void BeginClickAnimation(GrowlNotification notification)
        {
            EndClickAnimation(notification);
        }

        protected virtual void EndClickAnimation(GrowlNotification notification)
        {
            RemoveNotification(notification);
            OnNotificationClicked(new GrowlNotificationEventArgs(notification));
        }

        #endregion

        #region Open Animation

        protected virtual void BeginOpenAnimation(GrowlNotification notification)
        {
            EndOpenAnimation(notification);
        }

        protected virtual void EndOpenAnimation(GrowlNotification notification)
        {
            OnNotificationOpened(new GrowlNotificationEventArgs(notification));
        }

        #endregion

        #endregion

        #region Public Methods

        public void OpenNotification(GrowlNotification notification)
        {
            Notifications.Add(notification);
            IsOpen = true;
            BeginOpenAnimation(notification);
        }

        public void RemoveNotification(GrowlNotification notification)
        {
            Notifications.Remove(notification);
            if (Notifications.Count == 0)
                IsOpen = false;
        }

        public void TimeoutNotification(GrowlNotification notification)
        {
            if (!Notifications.Contains(notification))
                return;

            BeginTimeoutAnimation(notification);
        }

        public void ClickNotification(GrowlNotification notification)
        {
            if (!Notifications.Contains(notification))
                return;
            BeginClickAnimation(notification);
        }

        public void CloseNotification(GrowlNotification notification)
        {
            if (!Notifications.Contains(notification))
                return;
            BeginCloseAnimation(notification);
        }

        #endregion

        #region Events

        #region NotificationOpened Event
        protected virtual void OnNotificationOpened(GrowlNotificationEventArgs e)
        {
            if (NotificationOpened == null)
                return;
            NotificationOpened(this, e);
        }
        public event EventHandler<GrowlNotificationEventArgs> NotificationOpened;
        #endregion

        #region NotificationClicked Event

        protected virtual void OnNotificationClicked(GrowlNotificationEventArgs e)
        {
            if (NotificationClicked == null)
                return;
            NotificationClicked(this, e);
        }

        public event EventHandler<GrowlNotificationEventArgs> NotificationClicked;

        #endregion

        #region NotificationClosed Event

        protected virtual void OnNotificationClosed(GrowlNotificationEventArgs e)
        {
            if (NotificationClosed == null)
                return;
            NotificationClosed(this, e);
        }

        public event EventHandler<GrowlNotificationEventArgs> NotificationClosed;

        #endregion

        #region NotificationTimedout Event

        protected virtual void OnNotificationTimedout(GrowlNotificationEventArgs e)
        {
            if (NotificationTimedout == null)
                return;
            NotificationTimedout(this, e);
        }

        public event EventHandler<GrowlNotificationEventArgs> NotificationTimedout;

        #endregion

        #endregion
    }
}