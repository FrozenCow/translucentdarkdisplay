using System;

namespace Growl.Displays.Wpf
{
    public class GrowlNotificationEventArgs : EventArgs
    {
        private readonly GrowlNotification _notification;

        public GrowlNotification Notification
        {
            get { return _notification; }
        }

        public GrowlNotificationEventArgs(GrowlNotification notification)
        {
            _notification = notification;
        }
    }
}