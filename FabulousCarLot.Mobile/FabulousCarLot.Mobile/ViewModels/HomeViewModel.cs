using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabulousCarLot.Models;
using FabulousCarLot.Mobile.Services;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;

namespace FabulousCarLot.Mobile.ViewModels
{
    public class HomeViewModel: BaseViewModel
    {
        #region PRIVATE MEMBERS
        private IVehicleService vehicleService;
        private List<Vehicle> vehicles;
        private Vehicle selectedVehicle;
        private bool _isBusy;
        #endregion

        #region PUBLIC MEMBERS
        public List<Vehicle> Vehicles
        {
            get => vehicles;
            set
            {
                vehicles = value;
                OnPropertyChanged();
            }
        }

        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set
            {
                selectedVehicle = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region COMMANDS
        public AsyncCommand RefreshCommand => new AsyncCommand(RefreshVehicles, (_) => !IsBusy);
        #endregion

        #region CONTRUCTORS MEMBERS
        public HomeViewModel(IVehicleService service)
        {
            vehicleService = service;
        }
        #endregion

        #region METHODS
        public async Task InitializeData()
        {
            IsBusy = true;
            try
            {
                Vehicles = await vehicleService.GetAllVehicles();
            }
            catch(Exception ex)
            {
                //TODO: log error
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task RefreshVehicles()
        {
            IsRefreshing = true;
            try
            {
                Vehicles = await vehicleService.GetAllVehicles();
            }
            catch (Exception ex)
            {
                //TODO: log error
            }
            finally
            {
                IsRefreshing = false;
            }
        }
        #endregion
    }
}
