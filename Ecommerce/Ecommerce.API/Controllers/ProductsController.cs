using Ecommerce.ServiceLayer.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Ecommerce.ServiceLayer.CQRS.Commands;
using static Ecommerce.ServiceLayer.CQRS.Queries;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _mediator.Send(new GetProductListQuery());
        }
        
        [HttpGet("{Id}")]
        public async Task<Product> Get(int Id)
        {
            return await _mediator.Send(new GetProductByIdQuery(Id));
        }
        
        [HttpPost]
        public async Task<Product> Post([FromBody] Product product)
        {
            return await _mediator.Send(new AddProductCommand(product.Name, product.Quantity, product.Price));
        }
    }
}
