﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Swiftrade.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class Storemapping : BaseEntity<int>
    {
        public int StoreId { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }

        public virtual Store Store { get; set; }
    }
}