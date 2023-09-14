using Preepex.Core.Domain.Entities.Common;
using Preepex.Core.Domain.Entities.Identity;
using System;

namespace Preepex.Core.Domain.Entities.Audit
{
    public class FullAudited<TPrimaryKey> : BaseEntity<TPrimaryKey>, IFullAudited, ISoftDelete
    {
        public DateTime CreationTime { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public DateTime? ModificationTime { get; set; }

        public string ModifierId { get; set; }

        public virtual ApplicationUser Modifier { get; set; }

        public DateTime? DeletionTime { get; set; }

        public string DeleterId { get; set; }

        public virtual ApplicationUser Deleter { get; set; }

        public bool IsDeleted { get; set; }

        public int TenantId { get; set; }
    }
}
