using Ambev.DeveloperEvaluation.Application.Orders.Commands.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Orders.CreateOrder;
using Ambev.DeveloperEvaluation.Application.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, new { OrderId = result });
        }

        [HttpPut("{orderId:guid}/status")]
        public async Task<IActionResult> UpdateOrderStatus(Guid orderId, [FromBody] UpdateOrderStatusCommand command, CancellationToken cancellationToken)
        {
            command.OrderId = orderId;
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrdersQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
