﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Preepex.Core.Domain.Entities.Common;
using Preepex.Core.Domain.Interfaces;
using Preepex.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Currency : BaseEntity<int> , ILocalizedEntity, IStoreMappingSupported
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string DisplayLocale { get; set; }
        public string CustomFormatting { get; set; }
        public decimal Rate { get; set; }
        public bool LimitedToStores { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public int RoundingTypeId { get; set; }
    }
}