using AutoMapper;
using Microsoft.Extensions.Configuration;
using Preepex.Core.Application.Dtos;
using Preepex.Core.Domain.Entities.ApplicationEntities;

namespace Preepex.Infrastructure.Mappings.Resolvers
{
    public class PhotoUrlResolver : IValueResolver<Photo, PhotoToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public PhotoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Photo source, PhotoToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}