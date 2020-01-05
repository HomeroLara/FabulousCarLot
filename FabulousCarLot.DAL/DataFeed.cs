using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabulousCarLot.Models;
using Bogus;

namespace FabulousCarLot.DAL
{
    public class DataFeed: IDataFeed
    {
        #region PRIVATE MEMBERS
        private static List<Vehicle> vehicles;
        #endregion

        #region CONSTRUCTORS
        public DataFeed()
        {
            var t = "";
        }
        #endregion

        #region PUBLIC METHODS
        public async Task<List<Vehicle>> FakeDatabaseQueryForVehicles()
        {
            if (vehicles is null)
            {
                vehicles = await Task.Run(() =>
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
            }

            return vehicles;
        }
        #endregion
    }
}
