using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FabulousCarLot.Mobile.ViewModels;
using FabulousCarLot.Mobile.Services;

namespace FabulousCarLot.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleDetailView : ContentPage
    {
        private int vehicleId;
        private VehicleDetailViewModel vehicleDetailViewModel;
        public VehicleDetailView(int id)
        {
            vehicleId = id;
            vehicleDetailViewModel = new VehicleDetailViewModel(new VehicleService());
            this.BindingContext = vehicleDetailViewModel;

            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            await vehicleDetailViewModel.InitializeData(vehicleId);
        }
    }
}