namespace Swiftrade.Infrastructure.Services.DbInitializer
{
    public interface IDbInitializerService
    {
        void Migrate();
        void Seed();
    }
}
