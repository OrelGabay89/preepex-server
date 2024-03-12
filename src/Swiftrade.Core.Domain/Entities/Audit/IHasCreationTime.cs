using System;

namespace Swiftrade.Core.Domain.Entities.Audit
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}
