using Ambev.DeveloperEvaluation.Application.Orders.Commands.CreateOrder;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Orders.Profiles
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile()
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<Order, CreateOrderResult>();
        }
    }
}
