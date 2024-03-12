using System;

namespace Swiftrade.Core.Domain.Entities.Audit
{
    public interface IHasModificationTime
    {
        DateTime? ModificationTime { get; set; }
    }
}
