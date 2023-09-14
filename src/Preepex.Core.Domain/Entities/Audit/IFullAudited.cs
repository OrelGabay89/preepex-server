using Preepex.Core.Domain.Entities.Common;

namespace Preepex.Core.Domain.Entities.Audit
{
    public interface IFullAudited : IHasCreationTime, IHasCreator, IHasModificationTime, IHasModifier, IHasDeletionTime, IHasDeleter, ISoftDelete, IHasTenant
    {
    }
}
