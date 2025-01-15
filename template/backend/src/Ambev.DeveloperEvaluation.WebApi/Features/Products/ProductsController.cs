using Ambev.DeveloperEvaluation.Application.Products.Commands;
using Ambev.DeveloperEvaluation.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, new { ProductId = result });
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetProductsQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
