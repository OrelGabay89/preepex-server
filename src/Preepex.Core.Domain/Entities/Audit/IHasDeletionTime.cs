using System;

namespace Preepex.Core.Domain.Entities.Audit
{
    public interface IHasDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}
