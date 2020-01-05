using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabulousCarLot.DAL.Interfaces;
using FabulousCarLot.Models;
using System.Linq;

namespace FabulousCarLot.DAL.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        #region PRIVATE MEMBERS
        private IDataFeed dataFeed;
        #endregion
        #region CONSTRUCTORS
        public VehicleRepository(IDataFeed feed)
        {
            dataFeed = feed;
        }
        #endregion

        #region IMPLEMENTATION 
        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            var vehicles = await dataFeed.FakeDatabaseQueryForVehicles();
            var vehicle = vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
            return vehicle;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            var vehicles = await dataFeed.FakeDatabaseQueryForVehicles();
            return vehicles;
        }

        public Task<List<Vehicle>> SearchInventory(Vehicle vehicle)
        {
            //TODO: need to implement a predicate builder
            throw new NotImplementedException();
        }
        #endregion
    }
}
