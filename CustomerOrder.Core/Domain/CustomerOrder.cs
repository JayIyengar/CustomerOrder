using Newtonsoft.Json;
using System.Collections.Generic;

namespace CustomerOrder.Core.Domain
{
    public class CustomerOrder
    {
        public string orderNumber { get; set; }
        public string orderDate { get; set; }
        public string deliveryAddress { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public string deliveryExpected { get; set; }

    }
    
    public class OrderItem
    {   
        public string product { get; set; }
        public int quantity { get; set; }
        public decimal priceEach { get; set; }
    }
}
