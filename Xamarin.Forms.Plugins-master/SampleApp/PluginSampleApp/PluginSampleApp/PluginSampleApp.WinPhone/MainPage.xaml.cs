﻿using ExtendedCells.Forms.Plugin.WindowsPhone;
using ExtendedMap.Forms.Plugin.WindowsPhone;
using RoundedBoxView.Forms.Plugin.WindowsPhone;
using SVG.Forms.Plugin.WindowsPhone;
using Xamarin;
using Xamarin.Forms.Platform.WinPhone;

namespace PluginSampleApp.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            Xamarin.Forms.Forms.Init();
            FormsMaps.Init();
            SvgImageRenderer.Init();
            ExtendedTextCellRenderer.Init();
            ExtendedMapRenderer.Init();
            RoundedBoxViewRenderer.Init();

            LoadApplication(new PluginSampleApp.App());
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}