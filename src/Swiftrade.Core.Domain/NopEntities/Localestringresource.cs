﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Swiftrade.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Swiftrade.Core.Domain.Entities
{
    public partial class LocaleStringResource : BaseEntity<int>
    {
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
    }
}