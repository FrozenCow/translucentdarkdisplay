using System;
using System.Collections.Generic;
using System.ComponentModel;
using Growl.DisplayStyle;

namespace Growl.Displays.Wpf
{
    public class WpfSettingsPanelBase : SettingsPanelBase
    {
        private SettingsWrapper _settingsWrapper;

        protected SettingsWrapper SettingsWrapper
        {
            get
            {
                if (_settingsWrapper == null)
                    _settingsWrapper = CreateSettings(GetSettings());
                return _settingsWrapper;
            }
        }

        protected virtual SettingsWrapper CreateSettings(IDictionary<string, object> settings)
        {
            throw new NotImplementedException("The method CreateSettings should be overridden and an display-specific settings instance should be created.");
        }

        public virtual void Load()
        {
        }

        private void SettingsPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveSetting(e.PropertyName, GetSettings()[e.PropertyName]);
        }

        protected override void OnSettingsPanelSelected(EventArgs args)
        {
            _settingsWrapper.PropertyChanged += SettingsPropertyChanged;
            base.OnSettingsPanelSelected(args);
        }

        protected override void OnSettingsPanelDeselected(EventArgs args)
        {
            _settingsWrapper.PropertyChanged -= SettingsPropertyChanged;
            base.OnSettingsPanelDeselected(args);
        }
    }
}