namespace Preepex.Core.Domain.Entities.Common
{
    public class Type<TPrimaryKey> : BaseEntity<TPrimaryKey>, IType
    {
        public string Name { get; set; }
    }
}
