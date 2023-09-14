﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Shoppingcartitem
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int ShoppingCartTypeId { get; set; }
        public string AttributesXml { get; set; }
        public decimal CustomerEnteredPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime? RentalStartDateUtc { get; set; }
        public DateTime? RentalEndDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}