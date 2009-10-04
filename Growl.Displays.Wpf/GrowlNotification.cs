using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Growl.DisplayStyle;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Holds the information of the notification that was send by Growl.
    /// </summary>
    public class GrowlNotification : DependencyObject
    {
        public Notification OriginalNotification
        {
            get { return (Notification)GetValue(OriginalNotificationProperty); }
            set { SetValue(OriginalNotificationProperty, value); }
        }

        public static readonly DependencyProperty OriginalNotificationProperty = DependencyProperty.Register("OriginalNotification", typeof(Notification), typeof(GrowlNotification), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(GrowlNotification), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(GrowlNotification), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        public bool IsSticky
        {
            get { return (bool)GetValue(IsStickyProperty); }
            set { SetValue(IsStickyProperty, value); }
        }

        public static readonly DependencyProperty IsStickyProperty = DependencyProperty.Register("IsSticky", typeof(bool), typeof(GrowlNotification), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None));

        public TimeSpan TimeoutDuration
        {
            get { return (TimeSpan)GetValue(TimeoutDurationProperty); }
            set { SetValue(TimeoutDurationProperty, value); }
        }

        public static readonly DependencyProperty TimeoutDurationProperty = DependencyProperty.Register("TimeoutDuration", typeof(TimeSpan), typeof(GrowlNotification), new FrameworkPropertyMetadata(TimeSpan.FromSeconds(3), FrameworkPropertyMetadataOptions.None));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(GrowlNotification), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        public IDictionary<string, string> CustomTextAttributes
        {
            get { return (IDictionary<string, string>)GetValue(CustomTextAttributesProperty); }
            private set { SetValue(CustomTextAttributesProperty, value); }
        }

        public static readonly DependencyProperty CustomTextAttributesProperty = DependencyProperty.Register("CustomTextAttributes", typeof(IDictionary<string, string>), typeof(GrowlNotification), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        public GrowlNotificationStatus Status { get; set; }

        public GrowlNotification()
        {
            CustomTextAttributes = new Dictionary<string, string>();
        }
    }
}