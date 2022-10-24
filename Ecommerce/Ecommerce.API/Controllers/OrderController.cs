using Ecommerce.ServiceLayer.BusinessModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.ServiceLayer.CQRS.Commands;
using static Ecommerce.ServiceLayer.CQRS.Queries;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] List<OrderDetails> orderDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Order order = new() ;
                    order.OrderDetails = orderDetails;
                    await _mediator.Send(new AddOrderCommand(order));
                    return Ok();
                }
                else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);
                return BadRequest();

            }
        }
    }
}
