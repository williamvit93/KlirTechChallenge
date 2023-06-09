using AutoMapper;
using Klir.TechChallenge.AppService.ViewModels;
using Klir.TechChallenge.Domain.Models;

namespace Klir.TechChallenge.AppService.Config
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            Configure();
        }
        public void Configure()
        {
            //Domain to ViewModel
            CreateMap<Product, ProductViewModel>();
            CreateMap<Promotion, PromotionViewModel>()
                .ForMember(promotionViewModel
                => promotionViewModel.PromotionDescription, opt
                    => opt.MapFrom(promotion
                        => promotion.GetPromotionDescription()));

            CreateMap<PromotionType, PromotionTypeViewModel>();
            CreateMap<ProductPromotion, ProductPromotionViewModel>();

            //ViewModel to Domain
            CreateMap<ProductViewModel, Product>();
            CreateMap<PromotionViewModel, Promotion>();
            CreateMap<PromotionTypeViewModel, PromotionType>();
            CreateMap<ProductPromotionViewModel, ProductPromotion>();


        }
    }
}