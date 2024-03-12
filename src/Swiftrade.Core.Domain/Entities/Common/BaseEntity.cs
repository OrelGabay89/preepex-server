namespace Swiftrade.Core.Domain.Entities.Common
{
    public class BaseEntity<TPrimaryKey> : IBaseEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}