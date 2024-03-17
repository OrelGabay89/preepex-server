﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class Giftcard
    {
        public Giftcard()
        {
            GiftCardUsageHistory = new HashSet<Giftcardusagehistory>();
        }

        public int Id { get; set; }
        public int? PurchasedWithOrderItemId { get; set; }
        public int GiftCardTypeId { get; set; }
        public decimal Amount { get; set; }
        public bool IsGiftCardActivated { get; set; }
        public string GiftCardCouponCode { get; set; }
        public string RecipientName { get; set; }
        public string RecipientEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Message { get; set; }
        public bool IsRecipientNotified { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual Orderitem PurchasedWithOrderItem { get; set; }
        public virtual ICollection<Giftcardusagehistory> GiftCardUsageHistory { get; set; }
    }
}