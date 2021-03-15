using CustomerOrder.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Core.Processor
{
    public interface ICustomerOrderDetailProvider
    {
        Task<CustomerOrderDetailResponse> GetCustomerOrderDetail(CustomerOrderDetailRequest request);
    }
}
