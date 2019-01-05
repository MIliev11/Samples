﻿using System.Collections.Generic;
using SampleApp.Pages;
using Xamarin.Forms;
using MenuItem = SampleApp.Models.MenuItem;

namespace SampleApp
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      var listviewTabbedPage = new TabbedPage();

      listviewTabbedPage.Children.Add(new ExtendedTextCellListview());
      listviewTabbedPage.Children.Add(new StackLayoutCell());

      var masterDetailPage = new MasterDetailPage();

      var menuItemListview = new ListView
      {
        ItemsSource = new List<string> { MenuItem.Listview, MenuItem.TableLayout, MenuItem.Styles }
      };

      menuItemListview.ItemSelected += (sender, args) =>
      {
        switch (args.SelectedItem.ToString())
        {
          case MenuItem.Listview:
            {
              masterDetailPage.Detail = listviewTabbedPage;
              masterDetailPage.IsPresented = false;
              return;
            }
          case MenuItem.TableLayout:
            {
              masterDetailPage.Detail = new ExtendedTextCellTableView();
              masterDetailPage.IsPresented = false;
              return;
            }
          case MenuItem.Styles:
            {
              masterDetailPage.Detail = new Styles();
              masterDetailPage.IsPresented = false;
              return;
            }

          default:
            {
              masterDetailPage.Detail = listviewTabbedPage;
              masterDetailPage.IsPresented = false;
              return;
            }
        }
      };

      masterDetailPage.Master = new ContentPage { Content = menuItemListview, Title = "Menu" };
      masterDetailPage.Detail = listviewTabbedPage;


      MainPage = masterDetailPage;
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
