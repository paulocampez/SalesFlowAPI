namespace Ambev.DeveloperEvaluation.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderResult
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
