using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.ModifySale;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModifySale
{
    public class ModifySaleProfile : Profile
    {
        public ModifySaleProfile()
        {
            CreateMap<ModifySaleCommand, Sale>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Items.Sum(i => (i.UnitPrice - i.Discount) * i.Quantity)))
                .ForMember(dest => dest.Items, opt => opt.Ignore());

            CreateMap<ModifySaleCommand.ModifySaleItem, SaleItem>();
        }
    }
}
