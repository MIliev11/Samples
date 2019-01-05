﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PluginSampleApp.Pages;
using Xamarin.Forms;

namespace PluginSampleApp
{
    public class App : Application
    {
        private readonly NavigationPage _navigationPage;

        public App()
        {
            var listview = new ListView {RowHeight = 60};

            var listviewStackLayout = new StackLayout {Padding = 10};

            listviewStackLayout.Children.Add(listview);

            _navigationPage = new NavigationPage(new ContentPage
            {
                Content = listviewStackLayout
            });

            listview.ItemsSource = new List<string>
            {
                PageTitle.SVG,
                PageTitle.ExtendedMap,
                PageTitle.ExtendedCellListview,
                PageTitle.ExtendedCellTableView,
                PageTitle.RoundedBoxView,
            };

            listview.ItemSelected += (sender, args) => MenuItemSelected(sender, args);

            // The root page of your application
            MainPage = _navigationPage;
        }


        private async Task MenuItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem == null)
                return;

            switch (args.SelectedItem.ToString())
            {
                case PageTitle.SVG:
                {
                    await _navigationPage.Navigation.PushAsync(new SVGPage());
                    break;
                }
                case PageTitle.ExtendedMap:
                {
                    await _navigationPage.Navigation.PushAsync(new ExtendedMapPage());
                    break;
                }
                case PageTitle.ExtendedCellListview:
                {
                    await _navigationPage.Navigation.PushAsync(new ExtendedTextCellListview());
                    break;
                }
                case PageTitle.ExtendedCellTableView:
                {
                    await _navigationPage.Navigation.PushAsync(new ExtendedTextCellTableView());
                    break;
                }
                case PageTitle.RoundedBoxView:
                {
                    await _navigationPage.Navigation.PushAsync(new RoundedBoxViewPage());
                    break;
                }
            }


            ((ListView) (sender)).SelectedItem = null;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}