﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Customerattributevalue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerAttributeId { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }

        public virtual Customerattribute CustomerAttribute { get; set; }
    }
}