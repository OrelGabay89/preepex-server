namespace Swiftrade.Core.Domain.Entities.Common
{
    public interface IHasTenant
    {
        int TenantId { get; set; }
    }
}
