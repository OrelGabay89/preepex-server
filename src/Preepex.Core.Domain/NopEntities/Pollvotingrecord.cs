﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Pollvotingrecord
    {
        public int Id { get; set; }
        public int PollAnswerId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Pollanswer PollAnswer { get; set; }
    }
}