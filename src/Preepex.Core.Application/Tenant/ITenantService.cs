
namespace Preepex.Core.Application.Tenant
{
    public interface ITenantService
    {
        int? GetBySubdomain(string subdomain);

        //Tenant GetById(long id);
    }
}
