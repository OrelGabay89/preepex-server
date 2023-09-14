﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Preepex.Core.Domain.Entities.Common;
using Preepex.Core.Domain.Interfaces;
using Preepex.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Vendor: BaseEntity<int>, ILocalizedEntity, ISlugSupported, ISoftDeletedEntity
    {
        public Vendor()
        {
            VendorNote = new HashSet<Vendornote>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string PageSizeOptions { get; set; }
        public string Description { get; set; }
        public int PictureId { get; set; }
        public int AddressId { get; set; }
        public string AdminComment { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public string MetaDescription { get; set; }
        public int PageSize { get; set; }
        public bool AllowCustomersToSelectPageSize { get; set; }
        public bool PriceRangeFiltering { get; set; }
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }
        public bool ManuallyPriceRange { get; set; }

        public virtual ICollection<Vendornote> VendorNote { get; set; }
    }
}