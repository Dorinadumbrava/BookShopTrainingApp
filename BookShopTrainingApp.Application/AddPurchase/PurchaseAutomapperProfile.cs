using AutoMapper;
using BookShopTrainingApp.Domain;

namespace BookShopTrainingApp.Application.AddPurchase
{
    public class PurchaseAutomapperProfile : Profile
    {
        public PurchaseAutomapperProfile()
        {
            CreateMap<Purchase, PurchaseDto>()
               .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.BookId))
               .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
               .ForMember(dest => dest.PurchasedOn, opt => opt.MapFrom(src => src.PurcahseTime))
               .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount.Rate));

            CreateMap<Price, PriceDto>()
                .ForMember(dest => dest.Ammount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));
        }
    }
}