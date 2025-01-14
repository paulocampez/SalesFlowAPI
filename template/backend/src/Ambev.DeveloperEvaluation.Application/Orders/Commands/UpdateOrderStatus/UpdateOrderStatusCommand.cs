using MediatR;
using System;


public class UpdateOrderStatusCommand : IRequest<Unit>
{
    public Guid OrderId { get; set; }
    public string Status { get; set; } = string.Empty;

}
