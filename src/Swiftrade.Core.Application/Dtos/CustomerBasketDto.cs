using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swiftrade.Core.Application.Dtos
{ 
    public class CustomerBasketDto
    {
        [Required]
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("items")]
        public List<BasketItemDto> Items { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
        public string CurrencyCode { get; set; }

    }
}