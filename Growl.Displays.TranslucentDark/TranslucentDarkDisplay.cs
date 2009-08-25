using System.ComponentModel;
using System.Windows.Media;
using Growl.Displays.Wpf;
using System.Windows.Forms;

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

        public TranslucentDarkDisplay()
        {
            SettingsPanel = new TranslucentDarkSettingsPanel();
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
            popup.ShowText = settings.ShowText;

            PopupDocker.SetDockHorizontal(popup, settings.HorizontalPlacement);
            PopupDocker.SetDockVertical(popup, settings.VerticalPlacement);
            PopupDocker.SetDockedScreen(popup, settings.Screen);

            popup.Initialize();
            return popup;
        }

        private static System.Windows.Media.Color WfColorToWpfColor(System.Drawing.Color c)
        {
            return System.Windows.Media.Color.FromArgb(c.A, c.R, c.G, c.B);
        }
    }
}