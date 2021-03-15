using CustomerOrder.Core.DataInterface;
using CustomerOrder.Core.Settings;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CustomerOrder.DataAccess
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        public string DbConnectionString { get; private set; }
        public CustomerOrderRepository(ISettings settings)
        {
            DbConnectionString = settings.DbConnectionString;
        }
        public Core.Domain.CustomerOrder GetOrder(string customerId)
        {
            using (IDbConnection db = new SqlConnection(DbConnectionString))
            {
                var sql = "select o.ORDERID orderNumber," +
                " o.ORDERDATE orderDate," +
                " '' as deliveryAddress," +
                " o.DELIVERYEXPECTED deliveryExpected," +
                " case when o.CONTAINSGIFT = 0 THEN p.PRODUCTNAME" +
                " else 'Gift'" +
                " end product," +
                " ot.QUANTITY quantity," +
                " ot.PRICE priceEach," +
                " p.PRODUCTID as productId" + 
                " from ORDERS o" +
                " join OrderItems ot" +
                " on o.ORDERID = ot.ORDERID" +
                " join PRODUCTS p" +
                " on p.PRODUCTID = ot.PRODUCTID" +
                " where o.CUSTOMERID = '" + customerId + "'" +
                " and o.ORDERID = (select MAX(ORDERID) from ORDERS o1 where o.CUSTOMERID = o1.CUSTOMERID)";

                var custorderDictionary = new Dictionary<string, Core.Domain.CustomerOrder>();

                var customerOrder = db.Query<Core.Domain.CustomerOrder, Core.Domain.OrderItem, Core.Domain.CustomerOrder>(sql, (custOrder, orderItem) =>
                {
                    Core.Domain.CustomerOrder customerOrderEntry;
                    if (!custorderDictionary.TryGetValue(custOrder.orderNumber, out customerOrderEntry))
                    {
                        customerOrderEntry = custOrder;
                        customerOrderEntry.orderItems = new List<Core.Domain.OrderItem>();

                        custorderDictionary.Add(custOrder.orderNumber, customerOrderEntry);
                    }

                    customerOrderEntry.orderItems.Add(orderItem);
                    return customerOrderEntry;                    
                }, splitOn: "product").Distinct().ToList().FirstOrDefault();

                return customerOrder;
            }
        }
    }
}
