﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Preepex.Core.Domain.Entities
{
    public partial class ForumsTopic
    {
        public ForumsTopic()
        {
            ForumsPost = new HashSet<ForumsPost>();
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public int CustomerId { get; set; }
        public int ForumId { get; set; }
        public int TopicTypeId { get; set; }
        public int NumPosts { get; set; }
        public int Views { get; set; }
        public int LastPostId { get; set; }
        public int LastPostCustomerId { get; set; }
        public DateTime? LastPostTime { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ForumsForum Forum { get; set; }
        public virtual ICollection<ForumsPost> ForumsPost { get; set; }
    }
}