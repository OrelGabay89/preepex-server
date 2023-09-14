using System;

namespace Preepex.Core.Domain.Entities.Audit
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}
