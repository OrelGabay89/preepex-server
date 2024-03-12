namespace Swiftrade.Core.Domain.Entities.Audit
{
    public interface IHasDeleter
    {
        string DeleterId { get; set; }
    }
}
