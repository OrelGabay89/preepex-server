﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Preepex.Infrastructure.DbContexts;

#nullable disable

namespace Preepex.Infrastructure.Migrations.Application
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Customers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("AdminComment")
                        .HasColumnType("longtext");

                    b.Property<int>("AffiliateId")
                        .HasColumnType("int");

                    b.Property<int?>("BillingAddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CannotLoginUntilDateUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatorId")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid>("CustomerGuid")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DeleterId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("EmailToRevalidate")
                        .HasColumnType("longtext");

                    b.Property<int>("FailedLoginAttempts")
                        .HasColumnType("int");

                    b.Property<bool>("HasShoppingCartItems")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsSystemAccount")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsTaxExempt")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastActivityDateUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastIpAddress")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastLoginDateUtc")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ModifierId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RegisteredInStoreId")
                        .HasColumnType("int");

                    b.Property<bool>("RequireReLogin")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ShippingAddressId")
                        .HasColumnType("int");

                    b.Property<string>("SystemName")
                        .HasColumnType("longtext");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("DeleterId");

                    b.HasIndex("ModifierId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Identity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .HasColumnType("longtext");

                    b.Property<string>("Zipcode")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Messages.EmailAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EnableSsl")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Host")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<bool>("UseDefaultCredentials")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("EmailAccount");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.OrderAggregate.DeliveryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMethods");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.OrderAggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BuyerEmail")
                        .HasColumnType("longtext");

                    b.Property<int?>("DeliveryMethodId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsMain")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductBrandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductBrandId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.ProductBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ProductBrands");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HostName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Customer", b =>
                {
                    b.HasOne("Preepex.Core.Domain.Entities.Identity.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("Preepex.Core.Domain.Entities.Identity.ApplicationUser", "Deleter")
                        .WithMany()
                        .HasForeignKey("DeleterId");

                    b.HasOne("Preepex.Core.Domain.Entities.Identity.ApplicationUser", "Modifier")
                        .WithMany()
                        .HasForeignKey("ModifierId");

                    b.Navigation("Creator");

                    b.Navigation("Deleter");

                    b.Navigation("Modifier");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Identity.Address", b =>
                {
                    b.HasOne("Preepex.Core.Domain.Entities.Identity.ApplicationUser", "AppUser")
                        .WithOne("Address")
                        .HasForeignKey("Preepex.Core.Domain.Entities.Identity.Address", "AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.OrderAggregate.Order", b =>
                {
                    b.HasOne("Preepex.Core.Domain.Entities.OrderAggregate.DeliveryMethod", "DeliveryMethod")
                        .WithMany()
                        .HasForeignKey("DeliveryMethodId");

                    b.OwnsOne("Preepex.Core.Domain.Entities.OrderAggregate.Address", "ShipToAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("longtext");

                            b1.Property<string>("FirstName")
                                .HasColumnType("longtext");

                            b1.Property<string>("LastName")
                                .HasColumnType("longtext");

                            b1.Property<string>("State")
                                .HasColumnType("longtext");

                            b1.Property<string>("Street")
                                .HasColumnType("longtext");

                            b1.Property<string>("Zipcode")
                                .HasColumnType("longtext");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("DeliveryMethod");

                    b.Navigation("ShipToAddress");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("Preepex.Core.Domain.Entities.OrderAggregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Preepex.Core.Domain.Entities.OrderAggregate.ProductItemOrdered", "ItemOrdered", b1 =>
                        {
                            b1.Property<int>("OrderItemId")
                                .HasColumnType("int");

                            b1.Property<string>("PictureUrl")
                                .HasColumnType("longtext");

                            b1.Property<int>("ProductItemId")
                                .HasColumnType("int");

                            b1.Property<string>("ProductName")
                                .HasColumnType("longtext");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItems");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("ItemOrdered");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Photo", b =>
                {
                    b.HasOne("Preepex.Core.Domain.Entities.Product", "Product")
                        .WithMany("Photos")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Product", b =>
                {
                    b.HasOne("Preepex.Core.Domain.Entities.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Preepex.Core.Domain.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductBrand");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.OrderAggregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Preepex.Core.Domain.Entities.Product", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
