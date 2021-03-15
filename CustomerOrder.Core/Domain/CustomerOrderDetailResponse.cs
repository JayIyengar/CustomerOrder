using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Core.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CustomerOrderDetailResponse
    {
        [JsonProperty]
        public Customer customer { get; set; }
        [JsonProperty]
        public CustomerOrder order { get; set; }        
    }
}
