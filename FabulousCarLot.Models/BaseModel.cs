using System;
using Newtonsoft.Json;

namespace FabulousCarLot.Models
{
    public class BaseModel
    {
        #region PUBLIC MEMBERS
        [JsonProperty("uniqueId")]
        public Guid UniqueId { get; set; }
        
        [JsonProperty("isactive")]
        public bool IsActive { get; set; }

        [JsonProperty("createdatetime")]
        public DateTime CreateDateTime { get; set; }

        [JsonProperty("updatedatetime")]
        public DateTime UpdateDateTime { get; set; }
        #endregion

        #region CONSTRUCTORS
        public BaseModel() {
            UniqueId = Guid.NewGuid();
            CreateDateTime = DateTime.UtcNow;
            UpdateDateTime = DateTime.UtcNow;
        }
        #endregion
    }
}
