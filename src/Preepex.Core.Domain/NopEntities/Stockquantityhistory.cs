﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Stockquantityhistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityAdjustment { get; set; }
        public int StockQuantity { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int? CombinationId { get; set; }
        public int? WarehouseId { get; set; }

        public virtual Product Product { get; set; }
    }
}