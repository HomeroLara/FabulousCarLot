using System.Collections.Generic;
using Xunit;
using System.Threading.Tasks;
using FabulousCarLot.Models;
using FabulousCarLot.Mobile.ViewModels;
using FabulousCarLot.Mobile.Services;
using FabulousCarLot.DAL;
using Moq;

namespace FabulousCarLot.UnitTests.ViewModelUnitTests
{
    public class VehicleDetailsViewModelUnitTest
    {
        #region PRIVATE MEMBERS
        private IDataFeed dataFeed;
        #endregion

        #region CONSTRUCORS
        public VehicleDetailsViewModelUnitTest()
        {
            dataFeed = new DataFeed();
        }
        #endregion


        #region FACTS
        [Fact(DisplayName ="Verify vehicle details exist")]
        public async Task VerifyVehicleDetailsUnitTest()
        {
            //arrange
            var vehicles = await dataFeed.FakeDatabaseQueryForVehicles();
            var selectedVehicle = vehicles[0];

            var vehicleServiceMock = new Mock<IVehicleService>();
            vehicleServiceMock
                .Setup(v => v.GetVehicleById(0))
                .Returns(Task.FromResult(selectedVehicle));

            var vehicleDetailViewModel = new VehicleDetailViewModel(vehicleServiceMock.Object);

            //act
            await vehicleDetailViewModel.InitializeData(selectedVehicle.VehicleId);

            //assert
            Assert.NotNull(vehicleDetailViewModel.SelectedVehicle);
            Assert.Equal(selectedVehicle.UniqueId, vehicleDetailViewModel.SelectedVehicle.UniqueId);
            Assert.Equal(selectedVehicle.Price, vehicleDetailViewModel.SelectedVehicle.Price);
            Assert.Equal(selectedVehicle.VIN, vehicleDetailViewModel.SelectedVehicle.VIN);
        }
        #endregion
    }
}
