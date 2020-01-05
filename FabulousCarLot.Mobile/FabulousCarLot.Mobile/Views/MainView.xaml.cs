using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FabulousCarLot.Mobile.Models;

namespace FabulousCarLot.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainView : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuViews = new Dictionary<int, NavigationPage>();
        public MainView()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuViews.Add((int)MenuItemType.Home, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuViews.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuViews.Add(id, new NavigationPage(new HomeView()));
                        break;
                    case (int)MenuItemType.About:
                        MenuViews.Add(id, new NavigationPage(new AboutView()));
                        break;
                }
            }

            var newPage = MenuViews[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}