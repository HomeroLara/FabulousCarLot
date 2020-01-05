using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FabulousCarLot.Models;

namespace FabulousCarLot.DAL
{
    public interface IDataFeed
    {
        Task<List<Vehicle>> FakeDatabaseQueryForVehicles();
    }
}
