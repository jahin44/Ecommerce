using Ecommerce.ServiceLayer.Model;
using Ecommerce.ServiceLayer.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Ecommerce.ServiceLayer.CQRS.Commands;
using static Ecommerce.ServiceLayer.CQRS.Queries;

namespace Ecommerce.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
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
            return await _mediator.Send(new AddProductCommand(product));
        }
        
        [HttpPut]
        public async Task<Product> Update([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return await _mediator.Send(new UpdateProductCommand(product));
                }
            }catch (Exception ex)
            {
               _logger.LogError(ex, "Update Failed");
                
            }
            return product ;

        } 
        
        [HttpDelete("{Id}")]
        public async Task Delete( int Id)
        {
            try
            {
                if (Id!= 0)
                {
                   await _mediator.Send(new DeleteProductCommand(Id));
                }
            }catch (Exception ex)
            {
               _logger.LogError(ex, "Update Failed");
                
            }
        }
    }
}
