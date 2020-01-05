using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FabulousCarLot.Mobile.ViewModels;
using FabulousCarLot.Models;
using FabulousCarLot.Mobile.Services;

namespace FabulousCarLot.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        private HomeViewModel viewModel;
        public HomeView()
        {
            viewModel = new HomeViewModel(new VehicleService());
            this.BindingContext = viewModel;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await viewModel?.InitializeData();
        }

        private async void listViewVehicles_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem is Vehicle vehicle)
            {
                await Navigation.PushAsync(new VehicleDetailView(vehicle.VehicleId));
            }
        }
    }
}