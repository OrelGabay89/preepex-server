namespace Preepex.Core.Domain.Entities.Audit
{
    public interface IHasModifier
    {
        string ModifierId { get; set; }
    }
}
