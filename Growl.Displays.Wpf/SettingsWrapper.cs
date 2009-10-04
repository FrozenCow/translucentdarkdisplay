using System.Collections.Generic;
using System.ComponentModel;

namespace Growl.Displays.Wpf
{
    public abstract class SettingsWrapper
    {
        private IDictionary<string, object> _settings;

        protected SettingsWrapper(IDictionary<string, object> settings)
        {
            _settings = settings;
        }

        #region Helper Methods

        protected T Get<T>(string key, T defaultValue)
        {
            object valueObj;
            if (!_settings.TryGetValue(key, out valueObj))
                return defaultValue;
            if (!(valueObj is T))
                return defaultValue;
            return (T)valueObj;
        }

        protected void Set(string key, object value)
        {
            OnPropertyChanging(new PropertyChangingEventArgs(key));
            _settings[key] = value;
            OnPropertyChanged(new PropertyChangedEventArgs(key));
        }

        #endregion

        #region Events

        #region PropertyChanging Event

        protected virtual void OnPropertyChanging(PropertyChangingEventArgs e)
        {
            if (PropertyChanging == null)
                return;
            PropertyChanging(this, e);
        }

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion

        #region PropertyChanged Event

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #endregion
    }
}