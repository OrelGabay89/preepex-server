using System;

namespace Preepex.Core.Domain.Entities.Audit
{
    public interface IHasModificationTime
    {
        DateTime? ModificationTime { get; set; }
    }
}
