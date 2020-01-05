using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FabulousCarLot.Models;

namespace FabulousCarLot.Mobile.Services
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleById(int vehicleId);
    }
}
