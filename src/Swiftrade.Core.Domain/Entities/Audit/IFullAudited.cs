using Swiftrade.Core.Domain.Entities.Common;

namespace Swiftrade.Core.Domain.Entities.Audit
{
    public interface IFullAudited : IHasCreationTime, IHasCreator, IHasModificationTime, IHasModifier, IHasDeletionTime, IHasDeleter, ISoftDelete, IHasTenant
    {
    }
}
