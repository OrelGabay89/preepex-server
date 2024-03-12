using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swiftrade.Core.Domain.Entities.OrderAggregate;
using System;

namespace Swiftrade.Infrastructure.DbContexts.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrigOrder>
    {
        public void Configure(EntityTypeBuilder<OrigOrder> builder)
        {
            builder.OwnsOne(o => o.ShipToAddress, a =>
            {
                a.WithOwner();
            });
            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                );

            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}