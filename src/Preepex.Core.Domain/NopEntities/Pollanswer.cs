﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Pollanswer
    {
        public Pollanswer()
        {
            Pollvotingrecord = new HashSet<Pollvotingrecord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PollId { get; set; }
        public int NumberOfVotes { get; set; }
        public int DisplayOrder { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual ICollection<Pollvotingrecord> Pollvotingrecord { get; set; }
    }
}