using System.Text.Json.Serialization;

namespace CustomerOrder.Core.Domain
{
    public class Customer
    {
        [JsonIgnore]
        public string email { get; set; }
        [JsonIgnore]
        public string customerId { get; set; }
        [JsonIgnore]
        public bool website { get; set; }        
        public string firstName { get; set; }        
        public string lastName { get; set; }
        [JsonIgnore]
        public string lastLoggedIn { get; set; }
        [JsonIgnore]
        public string houseNumber { get; set; }
        [JsonIgnore]
        public string street { get; set; }
        [JsonIgnore]
        public string town { get; set; }
        [JsonIgnore]
        public string postcode { get; set; }
        [JsonIgnore]
        public string preferredLanguage { get; set; }
    }
}
