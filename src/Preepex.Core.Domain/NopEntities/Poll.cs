﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class Poll
    {
        public Poll()
        {
            Pollanswer = new HashSet<Pollanswer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public string SystemKeyword { get; set; }
        public bool Published { get; set; }
        public bool ShowOnHomepage { get; set; }
        public bool AllowGuestsToVote { get; set; }
        public int DisplayOrder { get; set; }
        public bool LimitedToStores { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }

        public virtual Language Language { get; set; }
        public virtual ICollection<Pollanswer> Pollanswer { get; set; }
    }
}