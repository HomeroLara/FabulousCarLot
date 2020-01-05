using System;
using System.Collections.Generic;
using System.Text;
using FabulousCarLot.Models;

namespace FabulousCarLot.Models
{
    public class VehiclesResponse: BaseResponse
    {
        public List<Vehicle> Vehicles { get; set; }
        public int ResultCount { get; set; }
    }
}
