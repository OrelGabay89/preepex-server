﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Preepex.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class LocaleStringResource : BaseEntity<int>
    {
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
    }
}