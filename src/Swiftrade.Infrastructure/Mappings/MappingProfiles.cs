using AutoMapper;
using Swiftrade.Core.Application.Dtos;
using Swiftrade.Core.Application.Models;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Entities.ApplicationEntities;
using Swiftrade.Core.Domain.Entities.OrderAggregate;
using Swiftrade.Infrastructure.Mappings.Resolvers;

namespace Swiftrade.Infrastructure.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Domain.Entities.ApplicationEntities.Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<Core.Domain.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Core.Domain.Entities.Identity.Address>();
            CreateMap<OrigOrder, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
            CreateMap<ProductCreateDto, Core.Domain.Entities.ApplicationEntities.Product>();
            CreateMap<Photo, PhotoToReturnDto>()
                .ForMember(d => d.PictureUrl,
                    o => o.MapFrom<PhotoUrlResolver>());
            
            //CreateMap<Category, CategoryModel>();

            CreateMap<ProductTagModel, ProductTag>().ReverseMap();
            CreateMap<VendorDto, Vendor>().ReverseMap();
            CreateMap<UrlRecord, UrlrecordDto>().ReverseMap();


            CreateMap<TopMenuModel, TopMenuDto>();
            CreateMap<CategoryModel, HomeCategoriesDto>();

        }
    }
}