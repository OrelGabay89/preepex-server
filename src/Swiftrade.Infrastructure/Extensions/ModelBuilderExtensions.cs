using Microsoft.EntityFrameworkCore;
using Swiftrade.Core.Domain.Entities.Common;

namespace Swiftrade.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void EnableSoftDelete(this ModelBuilder modelBuilder)
        {
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(type.ClrType) && (type.BaseType == null || !typeof(ISoftDelete).IsAssignableFrom(type.BaseType.ClrType)))
                {
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
                }
            }
        }
    }
}
