using Preepex.Core.Application.Models;
using System.Collections.Generic;

namespace Preepex.Core.Application.Dtos
{
    public class ProductSearchResponseDto
    {
        public ProductSearchResponseDto()
        {
            DefaultPictureModel = new PictureModel();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string SeName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public List<string> Collection { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public bool Sale { get; set; }
        public double Discount { get; set; }
        public int Stock { get; set; }
        public bool New { get; set; }
        public int Quantity { get; set; }
        public List<string> Tags { get; set; }
        public string Sku { get; set; }
        public List<ImageDto> Images { get; set; }
        public PictureModel DefaultPictureModel { get; set; }

    }
}
