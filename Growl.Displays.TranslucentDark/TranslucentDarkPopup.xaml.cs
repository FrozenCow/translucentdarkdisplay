using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Growl.Displays.Wpf;

namespace Growl.Displays.TranslucentDark
{
    public partial class TranslucentDarkPopup
    {
        #region Properties

        public double NotificationWidth
        {
            get { return (double)GetValue(NotificationWidthProperty); }
            set { SetValue(NotificationWidthProperty, value); }
        }

        public static readonly DependencyProperty NotificationWidthProperty = DependencyProperty.Register("NotificationWidth", typeof(double), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(256.0, FrameworkPropertyMetadataOptions.None));

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register("IconSize", typeof(double), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(48.0, FrameworkPropertyMetadataOptions.None));

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly DependencyProperty TextColorProperty = DependencyProperty.Register("TextColor", typeof(Color), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(Colors.White, FrameworkPropertyMetadataOptions.None));

        public Color ContainerColor
        {
            get { return (Color)GetValue(ContainerColorProperty); }
            set { SetValue(ContainerColorProperty, value); }
        }

        public static readonly DependencyProperty ContainerColorProperty = DependencyProperty.Register("ContainerColor", typeof(Color), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(Colors.Black, FrameworkPropertyMetadataOptions.None));

        public bool ShowIcon
        {
            get { return (bool)GetValue(ShowIconProperty); }
            set { SetValue(ShowIconProperty, value); }
        }

        public static readonly DependencyProperty ShowIconProperty = DependencyProperty.Register("ShowIcon", typeof(bool), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None));

        public bool ShowTitle
        {
            get { return (bool)GetValue(ShowTitleProperty); }
            set { SetValue(ShowTitleProperty, value); }
        }

        public static readonly DependencyProperty ShowTitleProperty = DependencyProperty.Register("ShowTitle", typeof(bool), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None));

        public bool ShowDescription
        {
            get { return (bool)GetValue(ShowDescriptionProperty); }
            set { SetValue(ShowDescriptionProperty, value); }
        }

        public static readonly DependencyProperty ShowDescriptionProperty = DependencyProperty.Register("ShowDescription", typeof(bool), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.None));

        public FontFamily TitleFontFamily
        {
            get { return (FontFamily)GetValue(TitleFontFamilyProperty); }
            set { SetValue(TitleFontFamilyProperty, value); }
        }

        public static readonly DependencyProperty TitleFontFamilyProperty = DependencyProperty.Register("TitleFontFamily", typeof(FontFamily), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        public static readonly DependencyProperty TitleFontSizeProperty = DependencyProperty.Register("TitleFontSize", typeof(double), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None));

        public FontFamily DescriptionFontFamily
        {
            get { return (FontFamily)GetValue(DescriptionFontFamilyProperty); }
            set { SetValue(DescriptionFontFamilyProperty, value); }
        }

        public static readonly DependencyProperty DescriptionFontFamilyProperty = DependencyProperty.Register("DescriptionFontFamily", typeof(FontFamily), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None));

        public double DescriptionFontSize
        {
            get { return (double)GetValue(DescriptionFontSizeProperty); }
            set { SetValue(DescriptionFontSizeProperty, value); }
        }

        public static readonly DependencyProperty DescriptionFontSizeProperty = DependencyProperty.Register("DescriptionFontSize", typeof(double), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.None));

        public bool UseFadeAnimation
        {
            get { return (bool)GetValue(UseFadeAnimationProperty); }
            set { SetValue(UseFadeAnimationProperty, value); }
        }

        public static readonly DependencyProperty UseFadeAnimationProperty = DependencyProperty.Register("UseFadeAnimation", typeof(bool), typeof(TranslucentDarkPopup), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.None));

        #endregion

        #region Constructors

        public TranslucentDarkPopup()
        {
            InitializeComponent();
            Initialize();
        }

        #endregion

        public void Initialize()
        {
            HorizontalAlignment horizontal = PopupDocker.GetDockHorizontal(this);
            VerticalAlignment vertical = PopupDocker.GetDockVertical(this);
            border.BorderThickness = new Thickness(
                (horizontal == HorizontalAlignment.Left || horizontal == HorizontalAlignment.Stretch) ? 0.0 : 5.0,
                (vertical == VerticalAlignment.Top || vertical == VerticalAlignment.Stretch) ? 0.0 : 5.0,
                (horizontal == HorizontalAlignment.Right || horizontal == HorizontalAlignment.Stretch) ? 0.0 : 5.0,
                (vertical == VerticalAlignment.Bottom || vertical == VerticalAlignment.Stretch) ? 0.0 : 5.0
                );
            border.CornerRadius = new CornerRadius(
                ((vertical == VerticalAlignment.Bottom || vertical == VerticalAlignment.Center) && (horizontal == HorizontalAlignment.Right || horizontal == HorizontalAlignment.Center)) ? 10.0 : 0.0,
                ((vertical == VerticalAlignment.Bottom || vertical == VerticalAlignment.Center) && (horizontal == HorizontalAlignment.Left || horizontal == HorizontalAlignment.Center)) ? 10.0 : 0.0,
                ((vertical == VerticalAlignment.Top || vertical == VerticalAlignment.Center) && (horizontal == HorizontalAlignment.Left || horizontal == HorizontalAlignment.Center)) ? 10.0 : 0.0,
                ((vertical == VerticalAlignment.Top || vertical == VerticalAlignment.Center) && (horizontal == HorizontalAlignment.Right || horizontal == HorizontalAlignment.Center)) ? 10.0 : 0.0
                );

            var itemsSource = Notifications;
            if (PopupDocker.GetDockVertical(this) == VerticalAlignment.Top)
                itemsSource = new ReversedObservableCollection<GrowlNotification>(Notifications);
            notificationsControl.ItemsSource = itemsSource;
        }

        #region Helper Methods

        protected FrameworkElement GetNotificationElement(GrowlNotification notification)
        {
            // HACK: Update the layout to make sure the containers are generated.
            notificationsControl.UpdateLayout();
            var container = notificationsControl.ItemContainerGenerator.ContainerFromItem(notification) as ContentPresenter;
            return (FrameworkElement)container.ContentTemplate.FindName("border", container);
        }

        #endregion

        #region Animations

        protected override void BeginTimeoutAnimation(GrowlNotification notification)
        {
            Duration timeoutDuration = new Duration(TimeSpan.FromSeconds(0.5));
            if (UseFadeAnimation && (from n in Notifications where n.Status <= GrowlNotificationStatus.Opened select n).Count() <= 1)
            {
                var animation = new DoubleAnimation(0, timeoutDuration);
                animation.Completed += delegate { EndTimeoutAnimation(notification); };
                border.BeginAnimation(OpacityProperty, animation);
            }
            else
            {
                var notificationBorder = GetNotificationElement(notification);
                var notificationTransformation = notificationBorder.RenderTransform;
                AnimationTimeline animation;
                HorizontalAlignment horizontal = PopupDocker.GetDockHorizontal(this);
                if (horizontal == HorizontalAlignment.Left)
                    animation = new DoubleAnimation(0.0, -notificationBorder.ActualWidth, timeoutDuration);
                else
                    animation = new DoubleAnimation(0.0, notificationBorder.ActualWidth, timeoutDuration);
                animation.Completed += delegate { EndTimeoutAnimation(notification); };
                notificationTransformation.BeginAnimation(TranslateTransform.XProperty, animation);
            }
        }

        protected override void BeginOpenAnimation(GrowlNotification notification)
        {
            var openDuration = new Duration(TimeSpan.FromSeconds(0.5));
            if (UseFadeAnimation && Notifications.Count <= 1)
            {
                var animation = new DoubleAnimation(0, 1, openDuration);
                animation.Completed += delegate { EndOpenAnimation(notification); };
                border.BeginAnimation(OpacityProperty, animation);
            }
            else
            {
                var container = GetNotificationElement(notification);
                VerticalAlignment vertical = PopupDocker.GetDockVertical(this);
                if (vertical == VerticalAlignment.Bottom ||
                    vertical == VerticalAlignment.Top)
                {
                    var animation = new DoubleAnimation((vertical == VerticalAlignment.Top ? -1.0 : 1.0) * container.DesiredSize.Height + borderTranslation.Y, 0, new Duration(TimeSpan.FromSeconds(0.5)));
                    animation.Completed += delegate { EndOpenAnimation(notification); };
                    borderTranslation.BeginAnimation(TranslateTransform.YProperty, animation);
                }
            }
        }

        #endregion

        #region Event Handlers

        private void notificationsItems_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;
            if (element == null)
                return;
            var notification = element.DataContext as GrowlNotification;
            if (notification == null)
                return;
            CloseNotification(notification);
        }

        private void notificationsItems_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var element = e.OriginalSource as FrameworkElement;
            if (element == null)
                return;
            var notification = element.DataContext as GrowlNotification;
            if (notification == null)
                return;
            ClickNotification(notification);
        }

        #endregion
    }
}