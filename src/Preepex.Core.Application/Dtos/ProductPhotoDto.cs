using Microsoft.AspNetCore.Http;
using Preepex.Core.Application.Attributes;

namespace Preepex.Core.Application.Dtos
{
    public class ProductPhotoDto
    {
        [MaxFileSize(2 * 1024 * 1024)]
        [AllowedExtensions(new[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile Photo { get; set; }
    }
}