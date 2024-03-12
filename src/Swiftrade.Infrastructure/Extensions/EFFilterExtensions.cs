using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Domain.Entities.Common;
using System;
using System.Linq;
using System.Reflection;

namespace Swiftrade.Infrastructure.Extensions
{
    public static class EfFilterExtensions
    {
        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { modelBuilder });
        }

        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(EfFilterExtensions)
                   .GetMethods(BindingFlags.Public | BindingFlags.Static)
                   .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : class, ISoftDelete
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
        }

        public static void SetTenantFilter(this ModelBuilder modelBuilder, Type entityType, int? tenantId)
        {
            SetTenantFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { modelBuilder, tenantId });
        }

        static readonly MethodInfo SetTenantFilterMethod = typeof(EfFilterExtensions)
                   .GetMethods(BindingFlags.Public | BindingFlags.Static)
                   .Single(t => t.IsGenericMethod && t.Name == "SetTenantFilter");

        public static void SetTenantFilter<TEntity>(this ModelBuilder modelBuilder, int? tenantId)
            where TEntity : class, IHasTenant
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(b => b.TenantId == tenantId.GetValueOrDefault());
        }

    }
}
