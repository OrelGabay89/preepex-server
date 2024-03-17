using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Domain.Entities;
using Swiftrade.Core.Domain.Entities.ApplicationEntities;
using Swiftrade.Core.Domain.Entities.Messages;
using Swiftrade.Core.Domain.Entities.OrderAggregate;
using Swiftrade.Infrastructure.Extensions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Product = Swiftrade.Core.Domain.Entities.ApplicationEntities.Product;

namespace Swiftrade.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public string UserId { get; set; }
        public int? TenantId { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<OldProductType> ProductTypes { get; set; }
        public DbSet<OrigOrder> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<EmailAccount> EmailAccount { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.EnableSoftDelete();
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.ProcessModification(UserId);
            ChangeTracker.ProcessDeletion(UserId);
            ChangeTracker.ProcessCreation(UserId, TenantId);

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();
            ChangeTracker.ProcessModification(UserId);
            ChangeTracker.ProcessDeletion(UserId);
            ChangeTracker.ProcessCreation(UserId, TenantId);

            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}