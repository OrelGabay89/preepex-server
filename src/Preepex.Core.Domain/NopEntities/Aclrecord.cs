﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Preepex.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Aclrecord : BaseEntity<int>
    {
        public string EntityName { get; set; }
        public int CustomerRoleId { get; set; }
        public int EntityId { get; set; }

        public virtual Customerrole CustomerRole { get; set; }
    }
}