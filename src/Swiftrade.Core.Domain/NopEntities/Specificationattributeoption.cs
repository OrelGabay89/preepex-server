﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Swiftrade.Core.Domain.Entities.Common;
using Swiftrade.Core.Domain.Localization;
using System;
using System.Collections.Generic;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class Specificationattributeoption : BaseEntity<int>, ILocalizedEntity
    {
        public Specificationattributeoption()
        {
            ProductSpecificationAttributeMapping = new HashSet<ProductSpecificationattributeMapping>();
        }

        public string Name { get; set; }
        public string ColorSquaresRgb { get; set; }
        public int SpecificationAttributeId { get; set; }
        public int DisplayOrder { get; set; }

        public virtual Specificationattribute SpecificationAttribute { get; set; }
        public virtual ICollection<ProductSpecificationattributeMapping> ProductSpecificationAttributeMapping { get; set; }
    }
}