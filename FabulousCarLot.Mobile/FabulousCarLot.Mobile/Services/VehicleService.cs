using FabulousCarLot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FabulousCarLot.Mobile.Configuration;
using Flurl;
using Flurl.Http;

namespace FabulousCarLot.Mobile.Services
{
    public class VehicleService : IVehicleService
    {
        public async Task<List<Vehicle>> GetAllVehicles()
        {
            var response = await RequestConfiguration.FabulousBaseUrl
               .AppendPathSegment(RequestConfiguration.FabulousApiVersion)
               .AppendPathSegment(RequestConfiguration.GetAllVehicles)
               .GetJsonAsync<VehiclesResponse>();

            return response.Vehicles;
        }

        public async Task<Vehicle> GetVehicleById(int vehicleId)
        {
            var response = await RequestConfiguration.FabulousBaseUrl
              .AppendPathSegment(RequestConfiguration.FabulousApiVersion)
              .AppendPathSegment($"{RequestConfiguration.GetVehicleById}{vehicleId}")
              .GetJsonAsync<VehicleResponse>();

            return response.Vehicle;
        }
    }
}
