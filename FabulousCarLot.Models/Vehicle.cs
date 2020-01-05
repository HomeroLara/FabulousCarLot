using System.Collections.Generic;
using Newtonsoft.Json;

namespace FabulousCarLot.Models
{
    public class Vehicle: BaseModel
    {
        #region PUBLIC MEMBERS
        [JsonProperty("VehicleId")]
        public int VehicleId { get; set; }

        [JsonProperty("vin")]
        public string VIN { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("color")]
        public VehicleColor Color { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("mileage")]
        public int Mileage { get; set; }

        [JsonProperty("mediumimageurl")]
        public string ImageUrl { get; set; }

        [JsonProperty("options")]
        public IList<string> Options { get; set; }
        #endregion

        #region CONSTRUCTORS
        public Vehicle()
        {
            Options = new List<string>();
        }
        #endregion

    }
}
