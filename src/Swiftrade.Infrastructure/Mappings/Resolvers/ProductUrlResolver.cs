using AutoMapper;
using Microsoft.Extensions.Configuration;
using Swiftrade.Core.Application.Dtos;
using Swiftrade.Core.Domain.Entities.ApplicationEntities;
using System.Linq;

namespace Swiftrade.Infrastructure.Mappings.Resolvers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            var photo = source.Photos.FirstOrDefault(x => x.IsMain);

            if (photo != null)
            {
                return _config["ApiUrl"] + photo.PictureUrl;
            }

            return _config["ApiUrl"] + "images/products/placeholder.png";
        }
    }
}