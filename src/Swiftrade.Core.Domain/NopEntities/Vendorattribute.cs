﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class Vendorattribute
    {
        public Vendorattribute()
        {
            VendorAttributeValue = new HashSet<VendorAttributeValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int DisplayOrder { get; set; }
        public int AttributeControlTypeId { get; set; }

        public virtual ICollection<VendorAttributeValue> VendorAttributeValue { get; set; }
    }
}