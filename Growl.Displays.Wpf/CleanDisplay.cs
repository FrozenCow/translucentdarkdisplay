using System;
using System.Collections.Generic;
using Growl.CoreLibrary;
using Growl.DisplayStyle;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// An abstract display class just like Growl.DisplayStyle.Display, but without the need to override events and without a HandleNotification method. Override ProcessNotification in stead of HandleNotification.
    /// </summary>
    public abstract class CleanDisplay : MarshalByRefObject, IDisplay
    {
        protected CleanDisplay()
        {
            SettingsPanel = new DefaultSettingsPanel();
            SettingsCollection = new Dictionary<string, object>();
        }

        public virtual void Load()
        {
        }

        public virtual void Unload()
        {
        }

        public virtual void Refresh()
        {
        }

        public abstract bool ProcessNotification(Notification notification, string displayName);

        public virtual string[] GetListOfAvailableDisplays()
        {
            return new[] { Name };
        }

        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string Author { get; }
        public abstract string Website { get; }
        public abstract string Version { get; }

        public SettingsPanelBase SettingsPanel { get; set; }
        public string GrowlApplicationPath { get; set; }
        public string DisplayStylePath { get; set; }
        public Dictionary<string, object> SettingsCollection { get; set; }

        public abstract void CloseAllOpenNotifications();
        public abstract void CloseLastNotification();

        #region Events

        #region NotificationClicked Event

        protected virtual void OnNotificationClicked(NotificationCallbackEventArgs e)
        {
            if (NotificationClicked == null)
                return;
            NotificationClicked(e);
        }

        public event NotificationCallbackEventHandler NotificationClicked;

        #endregion

        #region NotificationClosed Event

        protected virtual void OnNotificationClosed(NotificationCallbackEventArgs e)
        {
            if (NotificationClosed == null)
                return;
            NotificationClosed(e);
        }

        public event NotificationCallbackEventHandler NotificationClosed;

        #endregion

        #endregion
    }
}