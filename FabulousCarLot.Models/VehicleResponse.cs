using System;
using System.Collections.Generic;
using System.Text;
using FabulousCarLot.Models;

namespace FabulousCarLot.Models
{
    public class VehicleResponse: BaseResponse
    {
        public Vehicle Vehicle { get; set; }
    }
}
