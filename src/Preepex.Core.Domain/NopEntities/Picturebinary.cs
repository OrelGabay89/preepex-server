﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Preepex.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Picturebinary : BaseEntity<int>
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public byte[] BinaryData { get; set; }

        public virtual Picture Picture { get; set; }
    }
}