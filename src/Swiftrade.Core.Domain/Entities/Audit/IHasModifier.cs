namespace Swiftrade.Core.Domain.Entities.Audit
{
    public interface IHasModifier
    {
        string ModifierId { get; set; }
    }
}
