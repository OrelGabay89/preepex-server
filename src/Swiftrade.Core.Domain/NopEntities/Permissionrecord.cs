﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Swiftrade.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class Permissionrecord : BaseEntity<int>
    {
        public Permissionrecord()
        {
            CustomerRole = new HashSet<Customerrole>();
        }
        public string Name { get; set; }
        public string SystemName { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Customerrole> CustomerRole { get; set; }
    }
}