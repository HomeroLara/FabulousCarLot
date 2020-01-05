using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FabulousCarLot.Models;

namespace FabulousCarLot.DAL.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicleById(int vehicleId);
        Task<List<Vehicle>> SearchInventory(Vehicle vehicle);
    }
}
