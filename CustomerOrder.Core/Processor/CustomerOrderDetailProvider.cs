using CustomerOrder.Core.DataInterface;
using CustomerOrder.Core.Domain;
using System;
using System.Threading.Tasks;

namespace CustomerOrder.Core.Processor
{
    public class CustomerOrderDetailProvider : ICustomerOrderDetailProvider
    {
        private ICustomerOrderRepository _customerOrderRepository;
        private ICustomerDetailProvider _customerDetailProvider;
        public CustomerOrderDetailProvider(ICustomerOrderRepository customerOrderRepository, ICustomerDetailProvider customerDetailProvider)
        {
            _customerOrderRepository = customerOrderRepository;
            _customerDetailProvider = customerDetailProvider;
        }
        public async Task<CustomerOrderDetailResponse> GetCustomerOrderDetail(CustomerOrderDetailRequest request)
        {
            var customerOrderDetailResonse = new CustomerOrderDetailResponse();
            var customer = _customerDetailProvider.GetCustomer(request.User);

            if (request.CustomerId != customer.customerId)
            {
                return null;
            }

            customerOrderDetailResonse.customer = customer;

            var orderDetail = await Task.Run(() => _customerOrderRepository.GetOrder(request.CustomerId));

            if (orderDetail != null)
            {
                orderDetail.deliveryAddress = customer.houseNumber + "," + customer.street + "," + customer.town + "," + customer.postcode;
                orderDetail.orderDate = DateTime.Parse(orderDetail.orderDate).ToString("dd-MMM-yyyy");
                orderDetail.deliveryExpected = DateTime.Parse(orderDetail.deliveryExpected).ToString("dd-MMM-yyyy");
                customerOrderDetailResonse.order = orderDetail;
            }


            return customerOrderDetailResonse;
        }
    }
}
