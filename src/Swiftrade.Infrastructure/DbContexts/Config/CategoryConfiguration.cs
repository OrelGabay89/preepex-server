using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swiftrade.Core.Domain.Entities;
using System;

namespace Swiftrade.Infrastructure.DbContexts.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(400);
            builder.Property(p => p.CategoryTemplateId).IsRequired();
            builder.Property(p => p.MetaKeywords).HasMaxLength(400);
            builder.Property(p => p.MetaTitle).HasMaxLength(400);
            builder.Property(p => p.ParentCategoryId).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.PictureId).IsRequired();
            builder.Property(p => p.PageSize).IsRequired();
            builder.Property(p => p.AllowCustomersToSelectPageSize).IsRequired().HasDefaultValue(true);
            builder.Property(p => p.PageSizeOptions).HasMaxLength(400);
            builder.Property(p => p.ShowOnHomepage).IsRequired();
            builder.Property(p => p.IncludeInTopMenu).IsRequired();
            builder.Property(p => p.SubjectToAcl).IsRequired();
            builder.Property(p => p.LimitedToStores).IsRequired();
            builder.Property(p => p.Published).IsRequired();
            builder.Property(p => p.Deleted).IsRequired();
            builder.Property(p => p.DisplayOrder).IsRequired();
            builder.Property(p => p.CreatedOnUtc).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.UpdatedOnUtc).IsRequired().HasDefaultValue(DateTime.UtcNow);
        }
    }
}
