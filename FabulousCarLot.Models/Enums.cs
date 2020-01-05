using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FabulousCarLot.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VehicleColor
    {
        Red,
        White,
        Black,
        Gray,
        Blue
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum VehicleMake
    {
        Chevy,
        Ford,
        Honda,
        Toyota,
        Tank
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum VehicleOptions
    {
        SunRoof,
        FourWheelDrive,
        LowMiles,
        PowerWindows,
        Navigation,
        HeatedSeats
    }
}
