using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using Growl.Displays.Wpf;

namespace Growl.Displays.TranslucentDark
{
    public class TranslucentDarkSettings : SettingsWrapper
    {
        public Color TextColor
        {
            get { return Get("TextColor", Color.White); }
            set { Set("TextColor", Color.FromArgb(value.A, value.R, value.G, value.B)); }
        }

        public Color ContainerColor
        {
            get { return Get("ContainerColor", Color.FromArgb(153, Color.Black)); }
            set { Set("ContainerColor", Color.FromArgb(value.A, value.R, value.G, value.B)); }
        }

        public HorizontalAlignment HorizontalPlacement
        {
            get { return Get("HorizontalPlacement", HorizontalAlignment.Right); }
            set { Set("HorizontalPlacement", value); }
        }

        public VerticalAlignment VerticalPlacement
        {
            get { return Get("VerticalPlacement", VerticalAlignment.Bottom); }
            set { Set("VerticalPlacement", value); }
        }

        public double FixedWidth
        {
            get { return Get("FixedWidth", 256.0); }
            set { Set("FixedWidth", value); }
        }

        public double IconSize
        {
            get { return Get("IconSize", 48.0); }
            set { Set("IconSize", value); }
        }

        public bool ShowTitle
        {
            get { return Get("ShowTitle", true); }
            set { Set("ShowTitle", value); }
        }

        public bool ShowDescription
        {
            get { return Get("ShowDescription", true); }
            set { Set("ShowDescription", value); }
        }

        public bool ShowIcon
        {
            get { return Get("ShowIcon", true); }
            set { Set("ShowIcon", value); }
        }

        public int Screen
        {
            get { return Get("Screen", 0); }
            set { Set("Screen", value); }
        }

        public bool PauseOnFullscreen
        {
            get { return Get("PauseOnFullscreen", false); }
            set { Set("PauseOnFullscreen", value); }
        }

        public bool UseFadeAnimation
        {
            get { return Get("UseFadeAnimation", false); }
            set { Set("UseFadeAnimation", value); }
        }

        public string TitleFontFamily
        {
            get { return Get<string>("TitleFontFamily", null); }
            set { Set("TitleFontFamily", value); }
        }

        public double TitleFontSize
        {
            get { return Get("TitleFontSize", double.NaN); }
            set { Set("TitleFontSize", value); }
        }

        public string DescriptionFontFamily
        {
            get { return Get<string>("DescriptionFontFamily", null); }
            set { Set("DescriptionFontFamily", value); }
        }

        public double DescriptionFontSize
        {
            get { return Get("DescriptionFontSize", double.NaN); }
            set { Set("DescriptionFontSize", value); }
        }

        public TranslucentDarkSettings(IDictionary<string, object> settings)
            : base(settings)
        {
        }
    }
}