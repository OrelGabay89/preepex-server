using Swiftrade.Core.Domain.Enumerations;
using System.Collections.Generic;

namespace Swiftrade.Core.Application.Dtos
{
    public class ProductOverviewDto
    {
        public ProductOverviewDto()
        {
            ProductPrice = new ProductPriceDto();
            PictureModels = new List<PictureDto>();
            ProductSpecificationModel = new ProductSpecificationDto();
            ReviewOverviewModel = new ProductReviewOverviewDto();
            PictureModel = new PictureDto();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string SeName { get; set; }
        public string Sku { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public bool MarkAsNew { get; set; }
        public ProductPriceDto ProductPrice { get; set; }
        public IList<PictureDto> PictureModels { get; set; }
        public PictureDto PictureModel { get; set; }
        public ProductSpecificationDto ProductSpecificationModel { get; set; }
        public ProductReviewOverviewDto ReviewOverviewModel { get; set; }

    }
}
