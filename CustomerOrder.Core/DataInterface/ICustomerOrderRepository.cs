namespace CustomerOrder.Core.DataInterface
{
    public interface ICustomerOrderRepository
    {
        Domain.CustomerOrder GetOrder(string customerId);
    }
}
