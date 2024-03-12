using Swiftrade.Core.Domain.Entities.Audit;
using Swiftrade.Core.Domain.Entities.Common;
using System;

namespace Swiftrade.Core.Domain.Entities.ApplicationEntities
{
    public class Tenant : BaseEntity<int>, ISoftDelete, IHasCreationTime
    {
        public string Name { get; set; }

        public string HostName { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }
    }
}
