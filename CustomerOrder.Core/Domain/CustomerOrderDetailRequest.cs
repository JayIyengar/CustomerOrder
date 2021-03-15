using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrder.Core.Domain
{
    public class CustomerOrderDetailRequest
    {
        public string User { get; set; }
        public string CustomerId { get; set; }
    }
}
