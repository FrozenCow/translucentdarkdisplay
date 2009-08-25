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

        public bool ShowText
        {
            get { return Get("ShowText", true); }
            set { Set("ShowText", value); }
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

        public TranslucentDarkSettings(IDictionary<string, object> settings)
            : base(settings)
        {
        }
    }
}