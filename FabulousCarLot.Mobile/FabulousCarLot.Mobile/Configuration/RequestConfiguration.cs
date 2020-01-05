using System;
using System.Collections.Generic;
using System.Text;

namespace FabulousCarLot.Mobile.Configuration
{
    public static class RequestConfiguration
    {
        public const string FabulousBaseUrl = "https://fabulouscarlotservices.azurewebsites.net/api/";
        public const string FabulousApiVersion = "v0";
        public const string GetAllVehicles = "vehicles/";
        public const string GetVehicleById = "vehicles/";
        public const string UserAgent = "User-Agent";
        public const string UserAgentValue = "Flurl";
    }
}
