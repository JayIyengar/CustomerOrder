using CustomerOrder.Core.Domain;
using CustomerOrder.Core.Processor;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerOrder.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private ICustomerOrderDetailProvider _customerOrderDetailProvider;
        public OrderDetailController(ICustomerOrderDetailProvider customerOrderDetailProvider)
        {
            _customerOrderDetailProvider = customerOrderDetailProvider;
        }

        [HttpPost]
        [Route("GetOrderDetail")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetOrderDetail(CustomerOrderDetailRequest customerOrderDetailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);                
            }
            var orderDetail = await _customerOrderDetailProvider.GetCustomerOrderDetail(customerOrderDetailRequest);

            if (orderDetail is null)
                return NotFound();

            return Ok(orderDetail);
        }
    }
}
