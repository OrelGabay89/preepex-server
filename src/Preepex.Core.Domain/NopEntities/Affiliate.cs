﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Affiliate
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string AdminComment { get; set; }
        public string FriendlyUrlName { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }

        public virtual NopAddress Address { get; set; }
    }
}