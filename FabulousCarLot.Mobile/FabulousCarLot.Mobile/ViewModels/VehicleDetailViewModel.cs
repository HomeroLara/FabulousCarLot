using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabulousCarLot.Models;
using FabulousCarLot.Mobile.Services;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;
using System.Linq;

namespace FabulousCarLot.Mobile.ViewModels
{
    public class VehicleDetailViewModel: BaseViewModel
    {
        #region PRIVATE MEMBERS
        private IVehicleService vehicleService;
        private int vehicleId;
        private Vehicle selectedVehicle;
        private string vehicleOptions;
        #endregion

        #region PUBLIC MEMBERS
        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set
            {
                selectedVehicle = value;
                OnPropertyChanged();
            }
        }

        public string VehicleOptions
        {
            get => vehicleOptions;
            set
            {
                vehicleOptions = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public VehicleDetailViewModel(IVehicleService service)
        {
            vehicleService = service;
        }
        #endregion

        #region METHODS
        public async Task InitializeData(object data)
        {
            IsBusy = true;
            try
            {
                if (data is int id)
                {
                    vehicleId = id;
                    SelectedVehicle = await vehicleService.GetVehicleById(vehicleId);
                    SelectedVehicle?
                        .Options?
                        .ToList<string>()
                        .ForEach(o => VehicleOptions += $"{o}, ");

                }
            }
            catch (Exception ex)
            {
                //TODO: log error
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
