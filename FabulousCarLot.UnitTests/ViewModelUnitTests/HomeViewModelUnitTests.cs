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
    public class HomeViewModelUnitTests
    {
        #region PRIVATE MEMBERS
        private IDataFeed dataFeed;
        #endregion

        #region CONSTRUCORS
        public HomeViewModelUnitTests()
        {
            dataFeed = new DataFeed();
        }
        #endregion

        #region FACTS
        [Fact(DisplayName = "Verify data was retrieved on view model initialization")]
        public async void VehicleDataInitializationTest()
        {
            //arrange
            var vehicles = await dataFeed.FakeDatabaseQueryForVehicles();

            var vehicleServiceMock = new Mock<IVehicleService>();
            vehicleServiceMock
                .Setup(v => v.GetAllVehicles())
                .Returns(Task.FromResult(vehicles));

            var homeViewModel = new HomeViewModel(vehicleServiceMock.Object);

            //act
            await homeViewModel.InitializeData();

            //assert
            Assert.NotNull(homeViewModel.Vehicles);
            Assert.True(homeViewModel.Vehicles.Count > 0);
        }

        [Fact(DisplayName = "Verify data was retrieved on refresh")]
        public async void VehicleDataRefreshedTest()
        {
            //arrange
            var vehicles = await dataFeed.FakeDatabaseQueryForVehicles();

            var vehicleServiceMock = new Mock<IVehicleService>();
            vehicleServiceMock
                .Setup(v => v.GetAllVehicles())
                .Returns(Task.FromResult(vehicles));

            var homeViewModel = new HomeViewModel(vehicleServiceMock.Object);

            //act
            await homeViewModel.RefreshCommand.ExecuteAsync();

            //assert
            Assert.NotNull(homeViewModel.Vehicles);
            Assert.True(homeViewModel.Vehicles.Count > 0);
        }
        #endregion
    }
}
