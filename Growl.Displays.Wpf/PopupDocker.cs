using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using HorizontalAlignment=System.Windows.HorizontalAlignment;

namespace Growl.Displays.Wpf
{
    /// <summary>
    /// Provides dependency-properties to be used on <code>Popup</code> instances that need to be docked inside the working area of a screen.
    /// </summary>
    public static class PopupDocker
    {
        #region DockedScreen Property

        public static readonly DependencyProperty DockedScreenProperty = DependencyProperty.RegisterAttached("DockedScreen", typeof(int), typeof(WindowDocker), new PropertyMetadata(-1, DockedScreenChanged));

        public static int GetDockedScreen(DependencyObject obj)
        {
            return (int)obj.GetValue(DockedScreenProperty);
        }

        public static void SetDockedScreen(DependencyObject obj, int value)
        {
            obj.SetValue(DockedScreenProperty, value);
        }

        #endregion

        #region DockHorizontal Property

        public static readonly DependencyProperty DockHorizontalProperty = DependencyProperty.RegisterAttached("DockHorizontal", typeof(HorizontalAlignment), typeof(WindowDocker), new PropertyMetadata(HorizontalAlignment.Stretch, DockHorizontalChanged));

        public static HorizontalAlignment GetDockHorizontal(DependencyObject obj)
        {
            return (HorizontalAlignment)obj.GetValue(DockHorizontalProperty);
        }

        public static void SetDockHorizontal(DependencyObject obj, HorizontalAlignment value)
        {
            obj.SetValue(DockHorizontalProperty, value);
        }

        #endregion

        #region DockVertical Property

        public static readonly DependencyProperty DockVerticalProperty = DependencyProperty.RegisterAttached("DockVertical", typeof(VerticalAlignment), typeof(WindowDocker), new PropertyMetadata(VerticalAlignment.Stretch, DockVerticalChanged));

        public static VerticalAlignment GetDockVertical(DependencyObject obj)
        {
            return (VerticalAlignment)obj.GetValue(DockVerticalProperty);
        }

        public static void SetDockVertical(DependencyObject obj, VerticalAlignment value)
        {
            obj.SetValue(DockVerticalProperty, value);
        }

        #endregion

        private static void DockedScreenChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var popup = (Popup)obj;
            var value = (int)e.NewValue;

            SetDocked(popup, value);
        }

        private static void DockHorizontalChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var popup = (Popup)obj;
            if (GetDockedScreen(popup) >= 0)
                RelocatePopup(popup);
        }

        private static void DockVerticalChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var popup = (Popup)obj;
            if (GetDockedScreen(popup) >= 0)
                RelocatePopup(popup);
        }

        private static void SetDocked(Popup popup, int value)
        {
            if (value >= 0)
            {
                popup.CustomPopupPlacementCallback = CreatePlacementCallback(popup);
                popup.Placement = PlacementMode.Custom;
                popup.Loaded += PopupLoaded;
                popup.SizeChanged += PopupSizeChanged;
                RelocatePopup(popup);
            }
            else
            {
                popup.Loaded -= PopupLoaded;
                popup.SizeChanged -= PopupSizeChanged;
                popup.CustomPopupPlacementCallback = null;
            }
        }

        private static void PopupLoaded(object sender, RoutedEventArgs e)
        {
            RelocatePopup((Popup)sender);
        }

        private static void PopupSizeChanged(object sender, SizeChangedEventArgs e)
        {
            RelocatePopup((Popup)sender);
        }

        public static void RelocatePopup(Popup popup)
        {
            popup.ClearValue(Popup.IsOpenProperty);
            popup.IsOpen = true;
        }

        private static CustomPopupPlacementCallback CreatePlacementCallback(Popup popup)
        {
            return delegate(Size popupSize, Size targetSize, Point offset)
                   {
                       int dockedScreenIndex = GetDockedScreen(popup);
                       if (dockedScreenIndex < 0)
                           return new CustomPopupPlacement[0];

                       Screen dockedScreen;
                       if (dockedScreenIndex < Screen.AllScreens.Length)
                           dockedScreen = Screen.AllScreens[dockedScreenIndex];
                       else
                           dockedScreen = Screen.PrimaryScreen;

                       var workingArea = dockedScreen.WorkingArea;

                       var popupWidth = popupSize.Width;
                       var popupHeight = popupSize.Height;

                       var areaLeft = workingArea.Left;
                       var areaTop = workingArea.Top;
                       var areaWidth = workingArea.Width;
                       var areaHeight = workingArea.Height;

                       var popupLeft = 0.0;
                       var popupTop = 0.0;

                       HorizontalAlignment horizontal = GetDockHorizontal(popup);
                       VerticalAlignment vertical = GetDockVertical(popup);

                       switch (horizontal)
                       {
                           case HorizontalAlignment.Left:
                               popupLeft = areaLeft;
                               break;
                           case HorizontalAlignment.Center:
                               popupLeft = areaLeft + (areaWidth / 2 - popupWidth / 2);
                               break;
                           case HorizontalAlignment.Right:
                               popupLeft = areaLeft + areaWidth - popupWidth;
                               break;
                           case HorizontalAlignment.Stretch:
                               popupLeft = areaLeft;
                               popupWidth = areaWidth;
                               break;
                       }

                       switch (vertical)
                       {
                           case VerticalAlignment.Top:
                               popupTop = areaTop;
                               break;
                           case VerticalAlignment.Center:
                               popupTop = areaTop + (areaHeight / 2 - popupHeight / 2);
                               break;
                           case VerticalAlignment.Bottom:
                               popupTop = areaTop + areaHeight - popupHeight;
                               break;
                           case VerticalAlignment.Stretch:
                               popupTop = areaTop;
                               popupHeight = areaHeight;
                               break;
                       }
                       if ((popupTop < areaTop) || (popupTop + popupHeight > areaTop + areaHeight))
                       {
                           popupTop = areaTop;
                           popupHeight = areaHeight;
                       }
                       if ((popupLeft < areaLeft) || (popupLeft + popupWidth > areaLeft + areaWidth))
                       {
                           popupLeft = areaLeft;
                           popupWidth = areaWidth;
                       }
                       var popupLocation = new Point(popupLeft, popupTop);
                       if (horizontal == HorizontalAlignment.Stretch)
                           popup.Width = areaWidth;
                       if (vertical == VerticalAlignment.Stretch)
                           popup.Height = areaHeight;

                       var popupPlacement = new CustomPopupPlacement(popupLocation, PopupPrimaryAxis.Horizontal);
                       return new[]
                                  {
                                      popupPlacement
                                  };
                   };
        }
    }
}