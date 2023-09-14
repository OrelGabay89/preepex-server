using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Preepex.Core.Domain.Entities.OrderAggregate;
using System;

namespace Preepex.Infrastructure.DbContexts.Config
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