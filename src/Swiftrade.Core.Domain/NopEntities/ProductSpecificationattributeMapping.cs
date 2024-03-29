﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Swiftrade.Core.Domain.Entities.Common;
using Swiftrade.Core.Domain.Localization;
using Swiftrade.Core.Domain.NopEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class ProductSpecificationattributeMapping : BaseEntity<int>, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the attribute type ID
        /// </summary>
        public int AttributeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the specification attribute identifier
        /// </summary>
        public int SpecificationAttributeOptionId { get; set; }

        /// <summary>
        /// Gets or sets the custom value
        /// </summary>
        public string CustomValue { get; set; }

        /// <summary>
        /// Gets or sets whether the attribute can be filtered by
        /// </summary>
        public bool AllowFiltering { get; set; }

        /// <summary>
        /// Gets or sets whether the attribute will be shown on the product page
        /// </summary>
        public bool ShowOnProductPage { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets the attribute control type
        /// </summary>
        //public SpecificationAttributeType AttributeType
        //{
        //    get => (SpecificationAttributeType)AttributeTypeId;
        //    set => AttributeTypeId = (int)value;
        //}

        public virtual Product Product { get; set; }
        public virtual Specificationattributeoption SpecificationAttributeOption { get; set; }
    }
}
