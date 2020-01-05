using System;
using System.Collections.Generic;
using Xunit;
using System.Threading.Tasks;
using FabulousCarLot.Models;
using FabulousCarLot.DAL;
using Moq;
using Bogus;
using FabulousCarLot.DAL.Interfaces;

namespace FabulousCarLot.UnitTests.RepositoryUnitTests
{
    public class VehicleRepositoryUnitTests
    {
        #region CONSTRUCORS
        public VehicleRepositoryUnitTests()
        {
        }
        #endregion

        #region FACTS
        [Fact(DisplayName = "Get All Vehicles")]
        public async Task GetAllVehicleUnitTest()
        {
            //arrange
            var vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository
                .Setup(v => v.GetVehicles())
                .Returns(async () => await GetVehicles());

            //act
            var vehicles = await vehicleRepository.Object.GetVehicles();

            //assert
            Assert.NotNull(vehicles);
            Assert.True(vehicles.Count > 0);
        }

        [Fact(DisplayName = "Get Vehicle By Id")]
        public async Task GetVehicleByIdUnitTest()
        {
            //arrange
            var vehicles = await GetVehicles();
            var selectedVehicle = vehicles[vehicles.Count - 1];
            var vehicleRepository = new Mock<IVehicleRepository>();
            vehicleRepository
                .Setup(v => v.GetVehicleById(selectedVehicle.VehicleId))
                .Returns(Task.FromResult(selectedVehicle));

            //act
            var vehicle = await vehicleRepository.Object.GetVehicleById(selectedVehicle.VehicleId);

            //assert
            Assert.NotNull(selectedVehicle);
            Assert.NotNull(vehicles);
            Assert.True(vehicles.Count > 0);
            Assert.Equal(selectedVehicle.UniqueId, vehicle.UniqueId);
            Assert.Equal(selectedVehicle.Price, vehicle.Price);
            Assert.Equal(selectedVehicle.VIN, vehicle.VIN);
        }
        #endregion

        #region PRIVATE MEMBERS
        public async Task<List<Vehicle>> GetVehicles()
        {
            var vehicles = await Task.Run(() =>
            {
                var options = new List<string>() {
                        "Four Wheel Drive",
                        "Heated Seats",
                        "Low Miles",
                        "Navigation",
                        "Power Windows",
                        "Sun Roof" };

                var vehicleTypes = new List<string>() {
                        "Chevy",
                        "Ford",
                        "Honda",
                        "Toyota" };

                var faker = new Faker<Vehicle>()
                    .RuleFor(v => v.VehicleId, f => f.IndexFaker)
                    .RuleFor(v => v.CreateDateTime, f => f.Date.Recent(1))
                    .RuleFor(v => v.UpdateDateTime, f => f.Date.Recent(1))
                    .RuleFor(v => v.IsActive, f => f.PickRandom(new bool[] { true, true, true, false, false }))
                    .RuleFor(v => v.VIN, f => Guid.NewGuid().ToString())
                    .RuleFor(v => v.Color, f => f.PickRandom<VehicleColor>())
                    .RuleFor(v => v.Make, f => f.PickRandom(vehicleTypes))
                    .RuleFor(v => v.Options, f => new List<string> { f.PickRandom(options), f.PickRandom(options), f.PickRandom(options) })
                    .RuleFor(v => v.Description, f => f.Lorem.Sentence(15))
                    .RuleFor(v => v.Price, f => f.Commerce.Price(1000, 1000000, 2, "$"))
                    .RuleFor(v => v.Mileage, f => f.Random.Int(1, 100000))
                    .RuleFor(v => v.Year, f => f.Date.Recent(100).Year)
                    .RuleFor(v => v.ImageUrl, f => f.Image.PicsumUrl(200, 200, true, false));

                return faker.Generate(15);
            });

            return vehicles;
        }
        #endregion
    }
}
