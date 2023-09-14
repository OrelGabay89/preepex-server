﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Preepex.Core.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            DiscountusageHistory = new HashSet<Discountusagehistory>();
            GiftCardUsageHistory = new HashSet<Giftcardusagehistory>();
            OrderItem = new HashSet<Orderitem>();
            OrderNote = new HashSet<OrderNote>();
            RecurringPayment = new HashSet<RecurringPayment>();
            Shipment = new HashSet<Shipment>();
        }

        public int Id { get; set; }
        public string CustomOrderNumber { get; set; }
        public int BillingAddressId { get; set; }
        public int CustomerId { get; set; }
        public int? PickupAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public Guid OrderGuid { get; set; }
        public int StoreId { get; set; }
        public bool PickupInStore { get; set; }
        public int OrderStatusId { get; set; }
        public int ShippingStatusId { get; set; }
        public int PaymentStatusId { get; set; }
        public string PaymentMethodSystemName { get; set; }
        public string CustomerCurrencyCode { get; set; }
        public decimal CurrencyRate { get; set; }
        public int CustomerTaxDisplayTypeId { get; set; }
        public string VatNumber { get; set; }
        public decimal OrderSubtotalInclTax { get; set; }
        public decimal OrderSubtotalExclTax { get; set; }
        public decimal OrderSubTotalDiscountInclTax { get; set; }
        public decimal OrderSubTotalDiscountExclTax { get; set; }
        public decimal OrderShippingInclTax { get; set; }
        public decimal OrderShippingExclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeInclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeExclTax { get; set; }
        public string TaxRates { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal RefundedAmount { get; set; }
        public int? RewardPointsHistoryEntryId { get; set; }
        public string CheckoutAttributeDescription { get; set; }
        public string CheckoutAttributesXml { get; set; }
        public int CustomerLanguageId { get; set; }
        public int AffiliateId { get; set; }
        public string CustomerIp { get; set; }
        public bool AllowStoringCreditCardNumber { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string MaskedCreditCardNumber { get; set; }
        public string CardCvv2 { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public string AuthorizationTransactionId { get; set; }
        public string AuthorizationTransactionCode { get; set; }
        public string AuthorizationTransactionResult { get; set; }
        public string CaptureTransactionId { get; set; }
        public string CaptureTransactionResult { get; set; }
        public string SubscriptionTransactionId { get; set; }
        public DateTime? PaidDateUtc { get; set; }
        public string ShippingMethod { get; set; }
        public string ShippingRateComputationMethodSystemName { get; set; }
        public string CustomValuesXml { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int? RedeemedRewardPointsEntryId { get; set; }

        [NotMapped]
        public virtual NopAddress BillingAddress { get; set; }
        public virtual Customer Customer { get; set; }

        [NotMapped]
        public virtual NopAddress PickupAddress { get; set; }
        public virtual Rewardpointshistory RewardPointsHistoryEntry { get; set; }

        [NotMapped]
        public virtual NopAddress ShippingAddress { get; set; }
        public virtual ICollection<Discountusagehistory> DiscountusageHistory { get; set; }
        public virtual ICollection<Giftcardusagehistory> GiftCardUsageHistory { get; set; }
        public virtual ICollection<Orderitem> OrderItem { get; set; }
        public virtual ICollection<OrderNote> OrderNote { get; set; }
        public virtual ICollection<RecurringPayment> RecurringPayment { get; set; }
        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}