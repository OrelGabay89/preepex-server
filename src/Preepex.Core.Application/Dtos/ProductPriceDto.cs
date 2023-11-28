using System;

namespace Preepex.Core.Application.Dtos
{
    public class ProductPriceDto
    {
        public string OldPrice { get; set; }
        public decimal? OldPriceValue { get; set; }
        public string Price { get; set; }
        public decimal? PriceValue { get; set; }
        public string BasePricePAngV { get; set; }
        public decimal? BasePricePAngVValue { get; set; }
        public bool DisableBuyButton { get; set; }
        public bool DisableWishlistButton { get; set; }
        public bool DisableAddToCompareListButton { get; set; }
        public bool AvailableForPreOrder { get; set; }
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
        public bool IsRental { get; set; }
        public bool ForceRedirectionAfterAddingToCart { get; set; }
        public bool DisplayTaxShippingInfo { get; set; }
    }
}
