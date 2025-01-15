using System;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleCommand command)
        {
            var sale = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSale), new { id = sale }, sale);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSale(Guid id)
        {
            // Implement retrieval logic
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSale(Guid id, [FromBody] CreateSaleCommand command)
        {
            // Implement update logic
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> CancelSale(Guid id)
        {
            // Implement cancellation logic
            return Ok();
        }
    }
}
