namespace Swiftrade.Core.Domain.Entities.Audit
{
    public interface IHasCreator
    {
        string CreatorId { get; set; }
    }
}
