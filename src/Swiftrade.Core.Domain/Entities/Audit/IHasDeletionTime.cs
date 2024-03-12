using System;

namespace Swiftrade.Core.Domain.Entities.Audit
{
    public interface IHasDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}
