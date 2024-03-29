﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Swiftrade.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class StateProvince : BaseEntity<int>
    {
        public StateProvince()
        {
            Address = new HashSet<NopAddress>();
        }

        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int CountryId { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<NopAddress> Address { get; set; }
    }
}