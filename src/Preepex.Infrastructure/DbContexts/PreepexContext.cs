using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Preepex.Core.Domain.NopEntities;

namespace Preepex.Core.Domain.Entities
{
    public partial class PreepexContext : DbContext
    {
        public PreepexContext()
        {
        }

        public PreepexContext(DbContextOptions<PreepexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aclrecord> Aclrecords { get; set; }
        public virtual DbSet<Activitylog> Activitylogs { get; set; }
        public virtual DbSet<Activitylogtype> Activitylogtypes { get; set; }
        public virtual DbSet<NopAddress> Addresses { get; set; }
        public virtual DbSet<Addressattribute> Addressattributes { get; set; }
        public virtual DbSet<Addressattributevalue> Addressattributevalues { get; set; }
        public virtual DbSet<Affiliate> Affiliates { get; set; }
        public virtual DbSet<Backinstocksubscription> Backinstocksubscriptions { get; set; }
        public virtual DbSet<BlogComment> Blogcomments { get; set; }
        public virtual DbSet<Blogpost> Blogposts { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Categorytemplate> Categorytemplates { get; set; }
        public virtual DbSet<Checkoutattribute> Checkoutattributes { get; set; }
        public virtual DbSet<Checkoutattributevalue> Checkoutattributevalues { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Crosssellproduct> Crosssellproducts { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customerattribute> Customerattributes { get; set; }
        public virtual DbSet<Customerattributevalue> Customerattributevalues { get; set; }
        public virtual DbSet<Customerpassword> Customerpasswords { get; set; }
        public virtual DbSet<Customerrole> Customerroles { get; set; }
        public virtual DbSet<Deliverydate> Deliverydates { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Discountrequirement> Discountrequirements { get; set; }
        public virtual DbSet<Discountusagehistory> Discountusagehistories { get; set; }
        public virtual DbSet<Download> Downloads { get; set; }
        public virtual DbSet<Emailaccount> Emailaccounts { get; set; }
        public virtual DbSet<Externalauthenticationrecord> Externalauthenticationrecords { get; set; }
        public virtual DbSet<ForumsForum> ForumsForums { get; set; }
        public virtual DbSet<ForumsGroup> ForumsGroups { get; set; }
        public virtual DbSet<ForumsPost> ForumsPosts { get; set; }
        public virtual DbSet<ForumsPostvote> ForumsPostvotes { get; set; }
        public virtual DbSet<ForumsPrivatemessage> ForumsPrivatemessages { get; set; }
        public virtual DbSet<ForumsSubscription> ForumsSubscriptions { get; set; }
        public virtual DbSet<ForumsTopic> ForumsTopics { get; set; }
        public virtual DbSet<Gdprconsent> Gdprconsents { get; set; }
        public virtual DbSet<Gdprlog> Gdprlogs { get; set; }
        public virtual DbSet<GenericAttribute> Genericattributes { get; set; }
        public virtual DbSet<Giftcard> Giftcards { get; set; }
        public virtual DbSet<Giftcardusagehistory> Giftcardusagehistories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LocaleStringResource> Localestringresources { get; set; }
        public virtual DbSet<Localizedproperty> Localizedproperties { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Manufacturertemplate> Manufacturertemplates { get; set; }
        public virtual DbSet<Measuredimension> Measuredimensions { get; set; }
        public virtual DbSet<Measureweight> Measureweights { get; set; }
        public virtual DbSet<Messagetemplate> Messagetemplates { get; set; }
        public virtual DbSet<Migrationversioninfo> Migrationversioninfos { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> Newscomments { get; set; }
        public virtual DbSet<NewsLetterSubscription> Newslettersubscriptions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderitem> Orderitems { get; set; }
        public virtual DbSet<OrderNote> Ordernotes { get; set; }
        public virtual DbSet<Permissionrecord> Permissionrecords { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Picturebinary> Picturebinaries { get; set; }
        public virtual DbSet<Poll> Polls { get; set; }
        public virtual DbSet<Pollanswer> Pollanswers { get; set; }
        public virtual DbSet<Pollvotingrecord> Pollvotingrecords { get; set; }
        public virtual DbSet<Predefinedproductattributevalue> Predefinedproductattributevalues { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategoryMappings { get; set; }
        public virtual DbSet<ProductManufacturerMapping> ProductManufacturerMappings { get; set; }
        public virtual DbSet<ProductPictureMapping> ProductPictureMappings { get; set; }
        public virtual DbSet<ProductProductattributeMapping> ProductProductattributeMappings { get; set; }
        public virtual DbSet<ProductProducttagMapping> ProductProducttagMappings { get; set; }
        public virtual DbSet<ProductSpecificationattributeMapping> ProductSpecificationattributeMappings { get; set; }
        public virtual DbSet<Productattribute> Productattributes { get; set; }
        public virtual DbSet<ProductAttributeCombination> Productattributecombinations { get; set; }
        public virtual DbSet<Productattributevalue> Productattributevalues { get; set; }
        public virtual DbSet<Productavailabilityrange> Productavailabilityranges { get; set; }
        public virtual DbSet<Productreview> Productreviews { get; set; }
        public virtual DbSet<ProductreviewReviewtypeMapping> ProductreviewReviewtypeMappings { get; set; }
        public virtual DbSet<Productreviewhelpfulness> Productreviewhelpfulnesses { get; set; }
        public virtual DbSet<ProductTag> Producttags { get; set; }
        public virtual DbSet<Producttemplate> Producttemplates { get; set; }
        public virtual DbSet<Productwarehouseinventory> Productwarehouseinventories { get; set; }
        public virtual DbSet<Queuedemail> Queuedemails { get; set; }
        public virtual DbSet<RecurringPayment> Recurringpayments { get; set; }
        public virtual DbSet<Recurringpaymenthistory> Recurringpaymenthistories { get; set; }
        public virtual DbSet<Relatedproduct> Relatedproducts { get; set; }
        public virtual DbSet<ReturnRequest> Returnrequests { get; set; }
        public virtual DbSet<Returnrequestaction> Returnrequestactions { get; set; }
        public virtual DbSet<Returnrequestreason> Returnrequestreasons { get; set; }
        public virtual DbSet<Reviewtype> Reviewtypes { get; set; }
        public virtual DbSet<Rewardpointshistory> Rewardpointshistories { get; set; }
        public virtual DbSet<Scheduletask> Scheduletasks { get; set; }
        public virtual DbSet<Searchterm> Searchterms { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }
        public virtual DbSet<Shipmentitem> Shipmentitems { get; set; }
        public virtual DbSet<Shippingmethod> Shippingmethods { get; set; }
        public virtual DbSet<Shoppingcartitem> Shoppingcartitems { get; set; }
        public virtual DbSet<Specificationattribute> Specificationattributes { get; set; }
        public virtual DbSet<Specificationattributegroup> Specificationattributegroups { get; set; }
        public virtual DbSet<Specificationattributeoption> Specificationattributeoptions { get; set; }
        public virtual DbSet<StateProvince> Stateprovinces { get; set; }
        public virtual DbSet<Stockquantityhistory> Stockquantityhistories { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Storemapping> Storemappings { get; set; }
        public virtual DbSet<Taxcategory> Taxcategories { get; set; }
        public virtual DbSet<Tierprice> Tierprices { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Topictemplate> Topictemplates { get; set; }
        public virtual DbSet<UrlRecord> Urlrecords { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Vendorattribute> Vendorattributes { get; set; }
        public virtual DbSet<VendorAttributeValue> Vendorattributevalues { get; set; }
        public virtual DbSet<Vendornote> Vendornotes { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Aclrecord>(entity =>
            {
                entity.ToTable("aclrecord");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerRoleId, "IX_02F617482C79A6C2BE7A0C8A6455B2E8E14780EC");

                entity.HasIndex(e => new { e.EntityId, e.EntityName }, "IX_AclRecord_EntityId_EntityName");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CustomerRoleId).HasColumnType("int(11)");

                entity.Property(e => e.EntityId).HasColumnType("int(11)");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.CustomerRole)
                    .WithMany(p => p.AclRecord)
                    .HasForeignKey(d => d.CustomerRoleId)
                    .HasConstraintName("FK_18CE6CF7C1E595B8B220F8AF48B3962462E2EBE4");
            });

            modelBuilder.Entity<Activitylog>(entity =>
            {
                entity.ToTable("activitylog");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_0F273FFBCE7BB550E87EADE8C0D4FE78CEA4F21A");

                entity.HasIndex(e => e.CreatedOnUtc, "IX_ActivityLog_CreatedOnUtc");

                entity.HasIndex(e => e.ActivityLogTypeId, "IX_FA05048FC292BA387AD9F54569223A2361D29543");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ActivityLogTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.EntityId).HasColumnType("int(11)");

                entity.Property(e => e.EntityName)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.ActivityLogType)
                    .WithMany(p => p.ActivityLog)
                    .HasForeignKey(d => d.ActivityLogTypeId)
                    .HasConstraintName("FK_8551690BAD0612277F033FE5E6CDBE7AF8081FEF");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Activitylog)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_2DD54D1D705AD51551F0186C93A2A42C1F28D2D4");
            });

            modelBuilder.Entity<Activitylogtype>(entity =>
            {
                entity.ToTable("activitylogtype");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SystemKeyword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<NopAddress>(entity =>
            {
                entity.ToTable("address");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CountryId, "IX_0318CCE12D3601D14FD4102212A47D530180466D");

                entity.HasIndex(e => e.StateProvinceId, "IX_4A044E7C99A04BAA49E77199A91412218B24A8C4");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Address1)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Address2)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.City)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Company)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CountryId).HasColumnType("int(11)");

                entity.Property(e => e.County)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomAttributes)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FaxNumber)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FirstName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LastName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PhoneNumber)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StateProvinceId).HasColumnType("int(11)");

                entity.Property(e => e.ZipPostalCode)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_74D54DABCE4697ED8454CF2984F1C8F3460EE9BF");

                entity.HasOne(d => d.StateProvince)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StateProvinceId)
                    .HasConstraintName("FK_BF8E79E1F90FEA20DEEFE50550E5CB9052C5D951");

                entity.HasMany(d => d.Customer)
                    .WithMany(p => p.Address)
                    .UsingEntity<Dictionary<string, object>>(
                        "Customeraddress",
                        l => l.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").HasConstraintName("FK_0F795F0113618C1C09AB3006FE2F60B1A6944715"),
                        r => r.HasOne<NopAddress>().WithMany().HasForeignKey("AddressId").HasConstraintName("FK_064BBFC7F1E99C0ED3D657525AE15DA159D70620"),
                        j =>
                        {
                            j.HasKey("AddressId", "CustomerId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("customeraddresses").HasCharSet("latin1").UseCollation("latin1_swedish_ci");

                            j.HasIndex(new[] { "AddressId" }, "IX_64250EDA44F67EFAD151EB1EFE0D2EA08456B864");

                            j.HasIndex(new[] { "CustomerId" }, "IX_9AC0D6FE14A030F18305F46F428ACB6898B4187F");

                            j.IndexerProperty<int>("AddressId").HasColumnType("int(11)").HasColumnName("Address_Id");

                            j.IndexerProperty<int>("CustomerId").HasColumnType("int(11)").HasColumnName("Customer_Id");
                        });
            });

            modelBuilder.Entity<Addressattribute>(entity =>
            {
                entity.ToTable("addressattribute");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributeControlTypeId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Addressattributevalue>(entity =>
            {
                entity.ToTable("addressattributevalue");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AddressAttributeId, "IX_B8DBEDC16E08BA4792A1836F0CFBAE45476188BC");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AddressAttributeId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.AddressAttribute)
                    .WithMany(p => p.Addressattributevalue)
                    .HasForeignKey(d => d.AddressAttributeId)
                    .HasConstraintName("FK_5DFD07C8B3933393557F2405C5D030F722C1A875");
            });

            modelBuilder.Entity<Affiliate>(entity =>
            {
                entity.ToTable("affiliate");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.AddressId, "IX_53E30AC40CBC90074D6593764F2E48388B497292");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AddressId).HasColumnType("int(11)");

                entity.Property(e => e.AdminComment)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FriendlyUrlName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Affiliate)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_C51A67BAE50631F2EB05D8C998FE9011BF3C61D1");
            });

            modelBuilder.Entity<Backinstocksubscription>(entity =>
            {
                entity.ToTable("backinstocksubscription");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId, "IX_8894A8AA1D20379488AAF6BD14062F7BFB17E220");

                entity.HasIndex(e => e.CustomerId, "IX_CA2CD976F0AAC58A1BC6565C5FA026CCC23AF1A7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BackinStockSubScription)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_F8D6542EEF866E6F82330F20D425F73C0028C795");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Backinstocksubscription)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_3E102F467AD07EB3F3CF488469F7331357BC9427");
            });

            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.ToTable("blogcomment");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_610623902D397FF33F3287BF1345D7512C66145D");

                entity.HasIndex(e => e.BlogPostId, "IX_7EA6B2B4EAF446CC41EE99A3824A85C8190B57D0");

                entity.HasIndex(e => e.StoreId, "IX_9B64658D6D24EDEAB7F497D63D82313E0CCB64F5");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.BlogPostId).HasColumnType("int(11)");

                entity.Property(e => e.CommentText)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.HasOne(d => d.BlogPost)
                    .WithMany(p => p.BlogComment)
                    .HasForeignKey(d => d.BlogPostId)
                    .HasConstraintName("FK_333E84178EA6FDC1566C9E6608062ACFC2D190D6");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BlogComment)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_BB933E46C0D270FC1CDCFE5DE7017062B9FBA6D8");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.BlogComment)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_045A4462BB2CA5D4CEB9E9E4DC132EB6425CD61E");
            });

            modelBuilder.Entity<Blogpost>(entity =>
            {
                entity.ToTable("blogpost");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.LanguageId, "IX_EFC2F432AA3D91D9D6E18EDFF06769FF1B7D5CD8");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.BodyOverview)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.LanguageId).HasColumnType("int(11)");

                entity.Property(e => e.MetaDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Tags)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.BlogPost)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_4F3EC139C71EE09A13DC8A6D5E45C2DE2D45083B");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("campaign");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerRoleId).HasColumnType("int(11)");

                entity.Property(e => e.DontSendBeforeDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Deleted, "IX_Category_Deleted_Extended");

                entity.HasIndex(e => e.DisplayOrder, "IX_Category_DisplayOrder");

                entity.HasIndex(e => e.LimitedToStores, "IX_Category_LimitedToStores");

                entity.HasIndex(e => e.ParentCategoryId, "IX_Category_ParentCategoryId");
                
                entity.HasIndex(e => e.SubjectToAcl, "IX_Category_SubjectToAcl");

                entity.HasIndex(e => new { e.Published, e.Deleted, e.ShowOnHomepage, e.DisplayOrder, e.Id }, "IX_Category_Published_Deleted_ShowOnHomepage_DisplayOrder_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CategoryTemplateId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.MetaDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PageSize).HasColumnType("int(11)");

                entity.Property(e => e.PageSizeOptions)
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ParentCategoryId).HasColumnType("int(11)");

                entity.Property(e => e.PictureId).HasColumnType("int(11)");

                entity.Property(e => e.PriceFrom).HasPrecision(18, 4);

                entity.Property(e => e.PriceTo).HasPrecision(18, 4);

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<Categorytemplate>(entity =>
            {
                entity.ToTable("categorytemplate");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ViewPath)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Checkoutattribute>(entity =>
            {
                entity.ToTable("checkoutattribute");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributeControlTypeId).HasColumnType("int(11)");

                entity.Property(e => e.ConditionAttributeXml)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DefaultValue)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TaxCategoryId).HasColumnType("int(11)");

                entity.Property(e => e.TextPrompt)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ValidationFileAllowedExtensions)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ValidationFileMaximumSize).HasColumnType("int(11)");

                entity.Property(e => e.ValidationMaxLength).HasColumnType("int(11)");

                entity.Property(e => e.ValidationMinLength).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Checkoutattributevalue>(entity =>
            {
                entity.ToTable("checkoutattributevalue");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CheckoutAttributeId, "IX_36B591D67F6ADB5848B096AF344F381721D1781C");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CheckoutAttributeId).HasColumnType("int(11)");

                entity.Property(e => e.ColorSquaresRgb)
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PriceAdjustment).HasPrecision(18, 4);

                entity.Property(e => e.WeightAdjustment).HasPrecision(18, 4);

                entity.HasOne(d => d.CheckoutAttribute)
                    .WithMany(p => p.CheckoutAttributeValue)
                    .HasForeignKey(d => d.CheckoutAttributeId)
                    .HasConstraintName("FK_39ED1A2F060FE6EA243A9F346D19141E78557CEF");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.DisplayOrder, "IX_Country_DisplayOrder");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NumericIsoCode).HasColumnType("int(11)");

                entity.Property(e => e.ThreeLetterIsoCode)
                    .HasMaxLength(3)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TwoLetterIsoCode)
                    .HasMaxLength(2)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Crosssellproduct>(entity =>
            {
                entity.ToTable("crosssellproduct");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ProductId1).HasColumnType("int(11)");

                entity.Property(e => e.ProductId2).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("currency");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.DisplayOrder, "IX_Currency_DisplayOrder");

                entity.HasIndex(e => e.Published, "IX_Currency_Published");

                entity.HasIndex(e => new { e.DisplayOrder, e.Id }, "IX_Currency_DisplayOrder_Id");

                entity.HasIndex(e => new { e.Published, e.DisplayOrder, e.Id }, "IX_Currency_Published_DisplayOrder_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CustomFormatting)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayLocale)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Rate).HasPrecision(18, 4);

                entity.Property(e => e.RoundingTypeId).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ShippingAddressId, "IX_5FD07AEA757DD98D3E04CA86906517868F44A287");

                entity.HasIndex(e => e.BillingAddressId, "IX_79820CBB6A38BC446E7FC52E7582A458F3A2AC75");

                entity.HasIndex(e => e.CreatedOnUtc, "IX_Customer_CreatedOnUtc");

                entity.HasIndex(e => e.CustomerGuid, "IX_Customer_CustomerGuid");

                entity.HasIndex(e => e.Email, "IX_Customer_Email");

                entity.HasIndex(e => e.SystemName, "IX_Customer_SystemName");

                entity.HasIndex(e => e.Username, "IX_Customer_Username");
                
                entity.HasIndex(e => new { e.Id, e.Active }, "IX_Customer_Id_Active");
                
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AdminComment)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.AffiliateId).HasColumnType("int(11)");

                entity.Property(e => e.BillingAddressId)
                    .HasColumnType("int(11)")
                    .HasColumnName("BillingAddress_Id");

                entity.Property(e => e.CannotLoginUntilDateUtc).HasColumnType("datetime");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.EmailToRevalidate)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FailedLoginAttempts).HasColumnType("int(11)");

                entity.Property(e => e.LastActivityDateUtc).HasColumnType("datetime");

                entity.Property(e => e.LastIpAddress)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LastLoginDateUtc).HasColumnType("datetime");

                entity.Property(e => e.RegisteredInStoreId).HasColumnType("int(11)");

                entity.Property(e => e.ShippingAddressId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ShippingAddress_Id");

                entity.Property(e => e.SystemName)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Username)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.VendorId).HasColumnType("int(11)");

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.CustomerBillingAddress)
                    .HasForeignKey(d => d.BillingAddressId)
                    .HasConstraintName("FK_572D629F64F2591019291A15D1191B6419D3D7B4");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.CustomerShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .HasConstraintName("FK_4F620FCCDCB6197FB2B540B35EEE46515DE307E3");

                entity.HasMany(d => d.CustomerRole)
                    .WithMany(p => p.Customer)
                    .UsingEntity<Dictionary<string, object>>(
                        "CustomerCustomerroleMapping",
                        l => l.HasOne<Customerrole>().WithMany().HasForeignKey("CustomerRoleId").HasConstraintName("FK_7504842FB70DA1F50CB3020CCAA1A16761844930"),
                        r => r.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").HasConstraintName("FK_3AF7ACA7000EF570E199461C6C515E70C39F4552"),
                        j =>
                        {
                            j.HasKey("CustomerId", "CustomerRoleId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("customer_customerrole_mapping").HasCharSet("latin1").UseCollation("latin1_swedish_ci");

                            j.HasIndex(new[] { "CustomerId" }, "IX_09E9645547A7290962418327EE12D590BC1995F5");

                            j.HasIndex(new[] { "CustomerRoleId" }, "IX_E0FD9013E1AA40ED714BD90CE38AA3C1D57484E5");

                            j.IndexerProperty<int>("CustomerId").HasColumnType("int(11)").HasColumnName("Customer_Id");

                            j.IndexerProperty<int>("CustomerRoleId").HasColumnType("int(11)").HasColumnName("CustomerRole_Id");
                        });
            });

            modelBuilder.Entity<Customerattribute>(entity =>
            {
                entity.ToTable("customerattribute");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributeControlTypeId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Customerattributevalue>(entity =>
            {
                entity.ToTable("customerattributevalue");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerAttributeId, "IX_F42BE25FE6DC8F058A887BA1DEFB46198BC8D321");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CustomerAttributeId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.CustomerAttribute)
                    .WithMany(p => p.Customerattributevalue)
                    .HasForeignKey(d => d.CustomerAttributeId)
                    .HasConstraintName("FK_4474216C35CE12F76B30AF73EF8A00B2F3AB3B4B");
            });

            modelBuilder.Entity<Customerpassword>(entity =>
            {
                entity.ToTable("customerpassword");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_154E5C21B851AD9590F318EF6F718DB570DAEFF1");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PasswordFormatId).HasColumnType("int(11)");

                entity.Property(e => e.PasswordSalt)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerPassword)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_3F5D9E19DD3A95CBEB5BF9DAE373649821E78118");
            });

            modelBuilder.Entity<Customerrole>(entity =>
            {
                entity.ToTable("customerrole");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DefaultTaxDisplayTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PurchasedWithProductId).HasColumnType("int(11)");

                entity.Property(e => e.SystemName)
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Deliverydate>(entity =>
            {
                entity.ToTable("deliverydate");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("discount");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AdminComment)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DiscountAmount).HasPrecision(18, 4);

                entity.Property(e => e.DiscountLimitationId).HasColumnType("int(11)");

                entity.Property(e => e.DiscountPercentage).HasPrecision(18, 4);

                entity.Property(e => e.DiscountTypeId).HasColumnType("int(11)");

                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.LimitationTimes).HasColumnType("int(11)");

                entity.Property(e => e.MaximumDiscountAmount).HasPrecision(18, 4);

                entity.Property(e => e.MaximumDiscountedQuantity).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.HasMany(d => d.Category)
                    .WithMany(p => p.Discount)
                    .UsingEntity<Dictionary<string, object>>(
                        "DiscountAppliedtocategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").HasConstraintName("FK_1E8AF1DCDE521B9D937B2D874B129B29FEB8DDAC"),
                        r => r.HasOne<Discount>().WithMany().HasForeignKey("DiscountId").HasConstraintName("FK_B6FF88EE52D1B8CF5AD39B89DD423087F31EF926"),
                        j =>
                        {
                            j.HasKey("DiscountId", "CategoryId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("discount_appliedtocategories").HasCharSet("latin1").UseCollation("latin1_swedish_ci");

                            j.HasIndex(new[] { "DiscountId" }, "IX_3B15D52F81BDC47B279B9DD028BD1445B9A462F7");

                            j.HasIndex(new[] { "CategoryId" }, "IX_49CBAA99A1E2A276261D82400D383E5FE727C172");

                            j.IndexerProperty<int>("DiscountId").HasColumnType("int(11)").HasColumnName("Discount_Id");

                            j.IndexerProperty<int>("CategoryId").HasColumnType("int(11)").HasColumnName("Category_Id");
                        });

                entity.HasMany(d => d.Manufacturer)
                    .WithMany(p => p.Discount)
                    .UsingEntity<Dictionary<string, object>>(
                        "DiscountAppliedtomanufacturer",
                        l => l.HasOne<Manufacturer>().WithMany().HasForeignKey("ManufacturerId").HasConstraintName("FK_564C8660DF6324A92D75E78AF27F35F2B4C5EC55"),
                        r => r.HasOne<Discount>().WithMany().HasForeignKey("DiscountId").HasConstraintName("FK_EFCF44DF95BE2B0F44BEA91EC938BF273306EDB9"),
                        j =>
                        {
                            j.HasKey("DiscountId", "ManufacturerId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("discount_appliedtomanufacturers").HasCharSet("latin1").UseCollation("latin1_swedish_ci");

                            j.HasIndex(new[] { "ManufacturerId" }, "IX_4878483EA6D877C2F4E05C5D2E7DCBCE5F1D7D84");

                            j.HasIndex(new[] { "DiscountId" }, "IX_B27FB643C3BB153FA3E393FE3CE8AB72E6A6B90F");

                            j.IndexerProperty<int>("DiscountId").HasColumnType("int(11)").HasColumnName("Discount_Id");

                            j.IndexerProperty<int>("ManufacturerId").HasColumnType("int(11)").HasColumnName("Manufacturer_Id");
                        });

                entity.HasMany(d => d.Product)
                    .WithMany(p => p.Discount)
                    .UsingEntity<Dictionary<string, object>>(
                        "DiscountAppliedtoproduct",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK_93CBDED2C39FEA8DC8E0DDD9F6CDA0BB3009BBE2"),
                        r => r.HasOne<Discount>().WithMany().HasForeignKey("DiscountId").HasConstraintName("FK_7D5CB645FED1479E6A6CCFEECEC64D3EF834A9A0"),
                        j =>
                        {
                            j.HasKey("DiscountId", "ProductId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("discount_appliedtoproducts").HasCharSet("latin1").UseCollation("latin1_swedish_ci");

                            j.HasIndex(new[] { "DiscountId" }, "IX_33C579DE1781A7E8E15007E3FE54F0FF377BC60C");

                            j.HasIndex(new[] { "ProductId" }, "IX_57E9214528270AE442DF14F651EFC02B2218B19E");

                            j.IndexerProperty<int>("DiscountId").HasColumnType("int(11)").HasColumnName("Discount_Id");

                            j.IndexerProperty<int>("ProductId").HasColumnType("int(11)").HasColumnName("Product_Id");
                        });
            });

            modelBuilder.Entity<Discountrequirement>(entity =>
            {
                entity.ToTable("discountrequirement");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.DiscountId, "IX_B38979C2C3C47F2E4B698BDA6D236ECB9332F896");

                entity.HasIndex(e => e.ParentId, "IX_D506930CC015664811ECD666E873DB3A56442AC7");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DiscountId).HasColumnType("int(11)");

                entity.Property(e => e.DiscountRequirementRuleSystemName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.InteractionTypeId).HasColumnType("int(11)");

                entity.Property(e => e.ParentId).HasColumnType("int(11)");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountRequirement)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_CC430D8FE7C0BA15E476A441BE81D06D70036F64");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_FC331213C8E673A5CE279CCA6FC0EA1A866F84DA");
            });

            modelBuilder.Entity<Discountusagehistory>(entity =>
            {
                entity.ToTable("discountusagehistory");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.DiscountId, "IX_8F03BAA695B2105F0748CD33C1C69257A187A6AC");

                entity.HasIndex(e => e.OrderId, "IX_90D4BA0B388CAF5150F27E1D9F2781A06F77284E");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.DiscountId).HasColumnType("int(11)");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.DiscountUsageHistory)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_4337BE245B284E482FE1618865020385A32DA5DA");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DiscountusageHistory)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_56A8F184BCDD3C62383C40A4DA0A8CC6D7DF410E");
            });

            modelBuilder.Entity<Download>(entity =>
            {
                entity.ToTable("download");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ContentType)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DownloadUrl)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Extension)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Filename)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Emailaccount>(entity =>
            {
                entity.ToTable("emailaccount");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Host)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Port).HasColumnType("int(11)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Externalauthenticationrecord>(entity =>
            {
                entity.ToTable("externalauthenticationrecord");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_6D54D5251B1D23560C6CCB69543958292FE936DC");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ExternalDisplayIdentifier)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ExternalIdentifier)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.OauthAccessToken)
                    .HasColumnName("OAuthAccessToken")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.OauthToken)
                    .HasColumnName("OAuthToken")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ProviderSystemName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ExternalAuthenticationRecord)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_2458463D1AFE870AD994BD021E2945C51043E21A");
            });

            modelBuilder.Entity<ForumsForum>(entity =>
            {
                entity.ToTable("forums_forum");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ForumGroupId, "IX_8DCD3E5EEB323E614072D382CED0FDE15C28A20C");

                entity.HasIndex(e => e.DisplayOrder, "IX_Forums_Forum_DisplayOrder");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ForumGroupId).HasColumnType("int(11)");

                entity.Property(e => e.LastPostCustomerId).HasColumnType("int(11)");

                entity.Property(e => e.LastPostId).HasColumnType("int(11)");

                entity.Property(e => e.LastPostTime).HasColumnType("datetime");

                entity.Property(e => e.LastTopicId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NumPosts).HasColumnType("int(11)");

                entity.Property(e => e.NumTopics).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.ForumGroup)
                    .WithMany(p => p.ForumsForum)
                    .HasForeignKey(d => d.ForumGroupId)
                    .HasConstraintName("FK_5A81CFDC46FB89F476AB1E0DD13C84674C8BC543");
            });

            modelBuilder.Entity<ForumsGroup>(entity =>
            {
                entity.ToTable("forums_group");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.DisplayOrder, "IX_Forums_Group_DisplayOrder");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<ForumsPost>(entity =>
            {
                entity.ToTable("forums_post");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_66346A7D2B56A00742967506FC5896A954702923");

                entity.HasIndex(e => e.TopicId, "IX_BB7E36F50844E72B331791A9096CADB5DBFBA6C3");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(100)
                    .HasColumnName("IPAddress")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TopicId).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.VoteCount).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ForumsPost)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_A7D98402C554C30878C8B0E57C993907C4D67A41");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.ForumsPost)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_0ECAB22A168D661B9BAF8FEE2C7494FA4964DD5B");
            });

            modelBuilder.Entity<ForumsPostvote>(entity =>
            {
                entity.ToTable("forums_postvote");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ForumPostId, "IX_CE01D00491CDDF94D755273812C89769B8A6D72D");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.ForumPostId).HasColumnType("int(11)");

                entity.HasOne(d => d.ForumPost)
                    .WithMany(p => p.ForumsPostvote)
                    .HasForeignKey(d => d.ForumPostId)
                    .HasConstraintName("FK_9E6F504193082B61F109F7677B2872C88DAB25F6");
            });

            //modelBuilder.Entity<ForumsPrivatemessage>(entity =>
            //{
            //    entity.ToTable("forums_privatemessage");

            //    entity.HasCharSet("latin1")
            //        .UseCollation("latin1_swedish_ci");

            //    entity.HasIndex(e => e.ToCustomerId, "IX_BEEA04738B03E1F4C529C32C0403C6C812F20E7C");

            //    entity.HasIndex(e => e.FromCustomerId, "IX_F8737CF614F9242F33B0595B2D1875CFC7FEF892");

            //    entity.Property(e => e.Id).HasColumnType("int(11)");

            //    entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

            //    entity.Property(e => e.FromCustomerId).HasColumnType("int(11)");

            //    entity.Property(e => e.StoreId).HasColumnType("int(11)");

            //    entity.Property(e => e.Subject)
            //        .IsRequired()
            //        .HasMaxLength(450)
            //        .UseCollation("utf8_general_ci")
            //        .HasCharSet("utf8");

            //    entity.Property(e => e.Text)
            //        .IsRequired()
            //        .UseCollation("utf8_general_ci")
            //        .HasCharSet("utf8");

            //    entity.Property(e => e.ToCustomerId).HasColumnType("int(11)");

            //    entity.HasOne(d => d.FromCustomer)
            //        .WithMany(p => p.ForumsPrivateMessageFromCustomer)
            //        .HasForeignKey(d => d.FromCustomerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_9BC8A6F1527853C7164EBA7AAFF224D0AD05BC25");

            //    entity.HasOne(d => d.ToCustomer)
            //        .WithMany(p => p.ForumsPrivateMessageFromCustomer)
            //        .HasForeignKey(d => d.ToCustomerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_6B1164A7D9008C3BDAD676AF9E8F188D5900FADD");
            //});


            modelBuilder.Entity<ForumsSubscription>(entity =>
            {

                entity.ToTable("forums_subscription");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_04445AF7F58A268687EF7EFAF57B1E4692C90756");

                entity.HasIndex(e => e.ForumId, "IX_Forums_Subscription_ForumId");

                entity.HasIndex(e => e.TopicId, "IX_Forums_Subscription_TopicId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.ForumId).HasColumnType("int(11)");

                entity.Property(e => e.TopicId).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ForumsSubscription)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_B6A36BE342942CA0918650A40C2D37BE280AD924");
            });

            modelBuilder.Entity<ForumsTopic>(entity =>
            {
                entity.ToTable("forums_topic");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ForumId, "IX_74331CDF3DC43C580490017D2FF9557D66C6AF3C");

                entity.HasIndex(e => e.CustomerId, "IX_DDBC009BDA798D5E86F200A619BAEFEE2780A562");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.ForumId).HasColumnType("int(11)");

                entity.Property(e => e.LastPostCustomerId).HasColumnType("int(11)");

                entity.Property(e => e.LastPostId).HasColumnType("int(11)");

                entity.Property(e => e.LastPostTime).HasColumnType("datetime");

                entity.Property(e => e.NumPosts).HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(450)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TopicTypeId).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Views).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ForumsTopic)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_6F76917A376ADA1D26A859EB432614D01D09E35E");

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.ForumsTopic)
                    .HasForeignKey(d => d.ForumId)
                    .HasConstraintName("FK_3ED69F7FA84C66C0D0686663F4A248E95B5D0838");
            });

            modelBuilder.Entity<Gdprconsent>(entity =>
            {
                entity.ToTable("gdprconsent");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RequiredMessage)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Gdprlog>(entity =>
            {
                entity.ToTable("gdprlog");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ConsentId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.CustomerInfo)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RequestDetails)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RequestTypeId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<GenericAttribute>(entity =>
            {
                entity.ToTable("genericattribute");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => new { e.EntityId, e.KeyGroup }, "IX_GenericAttribute_EntityId_and_KeyGroup");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOrUpdatedDateUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("CreatedOrUpdatedDateUTC");

                entity.Property(e => e.EntityId).HasColumnType("int(11)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.KeyGroup)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Giftcard>(entity =>
            {
                entity.ToTable("giftcard");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.PurchasedWithOrderItemId, "IX_E753BB83C0D47CD444B41734828D6CE31BDA4547");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasPrecision(18, 4);

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.GiftCardCouponCode)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.GiftCardTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Message)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PurchasedWithOrderItemId).HasColumnType("int(11)");

                entity.Property(e => e.RecipientEmail)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RecipientName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SenderEmail)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SenderName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.PurchasedWithOrderItem)
                    .WithMany(p => p.GiftCard)
                    .HasForeignKey(d => d.PurchasedWithOrderItemId)
                    .HasConstraintName("FK_935F8066DDB55926E9F6AFB38FBBB44A64ECA16A");
            });

            modelBuilder.Entity<Giftcardusagehistory>(entity =>
            {
                entity.ToTable("giftcardusagehistory");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.UsedWithOrderId, "IX_2DDA907C9212253D7148AA484EFC08F8DB11DBB9");

                entity.HasIndex(e => e.GiftCardId, "IX_8D5FE9820B51CCB45277D64FC6E52C55CDEB59CF");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.GiftCardId).HasColumnType("int(11)");

                entity.Property(e => e.UsedValue).HasPrecision(18, 4);

                entity.Property(e => e.UsedWithOrderId).HasColumnType("int(11)");

                entity.HasOne(d => d.GiftCard)
                    .WithMany(p => p.GiftCardUsageHistory)
                    .HasForeignKey(d => d.GiftCardId)
                    .HasConstraintName("FK_ED90642156040A790AA6E46DCE79BF8D427A92D8");

                entity.HasOne(d => d.UsedWithOrder)
                    .WithMany(p => p.GiftCardUsageHistory)
                    .HasForeignKey(d => d.UsedWithOrderId)
                    .HasConstraintName("FK_551F5B6F0B00C29A799CD5800A370F1655ED9003");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.DisplayOrder, "IX_Language_DisplayOrder");

                entity.HasIndex(e => e.Published, "IX_Language_Published");

                entity.HasIndex(e => new { e.Published, e.DisplayOrder, e.Id }, "IX_Language_Published_DisplayOrder_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DefaultCurrencyId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.FlagImageFileName)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LanguageCulture)
                    .IsRequired()
                    .HasMaxLength(20)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.UniqueSeoCode)
                    .HasMaxLength(2)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<LocaleStringResource>(entity =>
            {
                entity.ToTable("localestringresource");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.LanguageId, "IX_C902AB0FC6278AB50D88DBAAAE90B40D17CBE388");

                entity.HasIndex(e => new { e.ResourceName, e.LanguageId }, "IX_LocaleStringResource");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.LanguageId).HasColumnType("int(11)");

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ResourceValue)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LocaleStringResource)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_5F4DC94AD6BF19DAF5DA0D0F355CEC1E52105386");
            });

            modelBuilder.Entity<Localizedproperty>(entity =>
            {
                entity.ToTable("localizedproperty");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.LanguageId, "IX_DBC6F45E7AB497D690C477A31075255AF97FFBBF");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EntityId).HasColumnType("int(11)");

                entity.Property(e => e.LanguageId).HasColumnType("int(11)");

                entity.Property(e => e.LocaleKey)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LocaleKeyGroup)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LocaleValue)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.LocalizedProperty)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_932362CA64AD0D6AD865A5D52A15E822B0AD18FF");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_E09C290A319BBF71BAEA063D33F45A248F16B85E");

                entity.HasIndex(e => e.CreatedOnUtc, "IX_Log_CreatedOnUtc");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.FullMessage)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LogLevelId).HasColumnType("int(11)");

                entity.Property(e => e.PageUrl)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ReferrerUrl)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ShortMessage)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Log)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_998C3D4780A37B0091EE9A5FD9833132BE830632");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.DisplayOrder, "IX_Manufacturer_DisplayOrder");

                entity.HasIndex(e => e.LimitedToStores, "IX_Manufacturer_LimitedToStores");

                entity.HasIndex(e => e.SubjectToAcl, "IX_Manufacturer_SubjectToAcl");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ManufacturerTemplateId).HasColumnType("int(11)");

                entity.Property(e => e.MetaDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PageSize).HasColumnType("int(11)");

                entity.Property(e => e.PageSizeOptions)
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PictureId).HasColumnType("int(11)");

                entity.Property(e => e.PriceFrom).HasPrecision(18, 4);

                entity.Property(e => e.PriceTo).HasPrecision(18, 4);

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");
            });

            modelBuilder.Entity<Manufacturertemplate>(entity =>
            {
                entity.ToTable("manufacturertemplate");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ViewPath)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Measuredimension>(entity =>
            {
                entity.ToTable("measuredimension");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Ratio).HasPrecision(18, 8);

                entity.Property(e => e.SystemKeyword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Measureweight>(entity =>
            {
                entity.ToTable("measureweight");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Ratio).HasPrecision(18, 8);

                entity.Property(e => e.SystemKeyword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Messagetemplate>(entity =>
            {
                entity.ToTable("messagetemplate");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttachedDownloadId).HasColumnType("int(11)");

                entity.Property(e => e.BccEmailAddresses)
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Body)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DelayBeforeSend).HasColumnType("int(11)");

                entity.Property(e => e.DelayPeriodId).HasColumnType("int(11)");

                entity.Property(e => e.EmailAccountId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Subject)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Migrationversioninfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("migrationversioninfo");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Version, "UC_Version")
                    .IsUnique();

                entity.Property(e => e.AppliedOn).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Version).HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.LanguageId, "IX_7F02E3C278A944BE59537727A19FEA3A6855AE27");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Full)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LanguageId).HasColumnType("int(11)");

                entity.Property(e => e.MetaDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Short)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_283F6E44D54B41A8A004E82360272E30DEC0D93F");
            });

            modelBuilder.Entity<NewsComment>(entity =>
            {
                entity.ToTable("newscomment");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.NewsItemId, "IX_4327C9836AB73A3FD882D71C073014C5DF40D484");

                entity.HasIndex(e => e.StoreId, "IX_BDAB1EFC98942D6D41898F6649AC03B2FBDA57E4");

                entity.HasIndex(e => e.CustomerId, "IX_FEA2E6F746138EB2B8393B8661D8A9091FBC9A46");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CommentText)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CommentTitle)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.NewsItemId).HasColumnType("int(11)");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.NewsComment)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_A3BDA22EA8A19B4751F74312AA85045E9875DD39");

                entity.HasOne(d => d.NewsItem)
                    .WithMany(p => p.NewsComment)
                    .HasForeignKey(d => d.NewsItemId)
                    .HasConstraintName("FK_5F6C63D8C97ACC6EBD102F74FBBA03291B4DE766");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.NewsComment)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_A9DBDF3CEE0A841A768F46F42CE0A09EAE3D6968");
            });

            modelBuilder.Entity<NewsLetterSubscription>(entity =>
            {
                entity.ToTable("newslettersubscription");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => new { e.Email, e.StoreId }, "IX_NewsletterSubscription_Email_StoreId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.RewardPointsHistoryEntryId, "FK_E2B3006CB294B6FD2E08E9DB53E7296283CB8A61");

                entity.HasIndex(e => e.PickupAddressId, "IX_0E470D4A2077F13DD52B58146A78BB6D9FF598A3");

                entity.HasIndex(e => e.ShippingAddressId, "IX_30A52D6385B52F71FB5EDB1D893B738E8549DE8B");

                entity.HasIndex(e => e.CustomerId, "IX_D4D583CDFB5B9FA861705763C89DE617044108E3");

                entity.HasIndex(e => e.BillingAddressId, "IX_E7755CC7F881D5026F1484CD9F844657848310FB");

                entity.HasIndex(e => e.CreatedOnUtc, "IX_Order_CreatedOnUtc");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AffiliateId).HasColumnType("int(11)");

                entity.Property(e => e.AuthorizationTransactionCode)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.AuthorizationTransactionId)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.AuthorizationTransactionResult)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.BillingAddressId).HasColumnType("int(11)");

                entity.Property(e => e.CaptureTransactionId)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CaptureTransactionResult)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CardCvv2)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CardExpirationMonth)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CardExpirationYear)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CardName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CardNumber)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CardType)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CheckoutAttributeDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CheckoutAttributesXml)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CurrencyRate).HasPrecision(18, 4);

                entity.Property(e => e.CustomOrderNumber)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CustomValuesXml)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CustomerCurrencyCode)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.CustomerIp)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CustomerLanguageId).HasColumnType("int(11)");

                entity.Property(e => e.CustomerTaxDisplayTypeId).HasColumnType("int(11)");

                entity.Property(e => e.MaskedCreditCardNumber)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.OrderDiscount).HasPrecision(18, 4);

                entity.Property(e => e.OrderShippingExclTax).HasPrecision(18, 4);

                entity.Property(e => e.OrderShippingInclTax).HasPrecision(18, 4);

                entity.Property(e => e.OrderStatusId).HasColumnType("int(11)");

                entity.Property(e => e.OrderSubTotalDiscountExclTax).HasPrecision(18, 4);

                entity.Property(e => e.OrderSubTotalDiscountInclTax).HasPrecision(18, 4);

                entity.Property(e => e.OrderSubtotalExclTax).HasPrecision(18, 4);

                entity.Property(e => e.OrderSubtotalInclTax).HasPrecision(18, 4);

                entity.Property(e => e.OrderTax).HasPrecision(18, 4);

                entity.Property(e => e.OrderTotal).HasPrecision(18, 4);

                entity.Property(e => e.PaidDateUtc).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethodAdditionalFeeExclTax).HasPrecision(18, 4);

                entity.Property(e => e.PaymentMethodAdditionalFeeInclTax).HasPrecision(18, 4);

                entity.Property(e => e.PaymentMethodSystemName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PaymentStatusId).HasColumnType("int(11)");

                entity.Property(e => e.PickupAddressId).HasColumnType("int(11)");

                entity.Property(e => e.RedeemedRewardPointsEntryId).HasColumnType("int(11)");

                entity.Property(e => e.RefundedAmount).HasPrecision(18, 4);

                entity.Property(e => e.RewardPointsHistoryEntryId).HasColumnType("int(11)");

                entity.Property(e => e.ShippingAddressId).HasColumnType("int(11)");

                entity.Property(e => e.ShippingMethod)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ShippingRateComputationMethodSystemName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ShippingStatusId).HasColumnType("int(11)");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.SubscriptionTransactionId)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TaxRates)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.VatNumber)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.OrderBillingAddress)
                    .HasForeignKey(d => d.BillingAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DF57B77161942EFD6C557438EC3BD730AEE345C5");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_B82AF61EE7639593EB7CB9A1319FBE9B4AF6F1FC");

                entity.HasOne(d => d.PickupAddress)
                    .WithMany(p => p.OrderPickupAddress)
                    .HasForeignKey(d => d.PickupAddressId)
                    .HasConstraintName("FK_BCC8B18340C4EB00FC90C8D29C95ACF8931B21FE");

                entity.HasOne(d => d.RewardPointsHistoryEntry)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.RewardPointsHistoryEntryId)
                    .HasConstraintName("FK_E2B3006CB294B6FD2E08E9DB53E7296283CB8A61");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.OrderShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .HasConstraintName("FK_59EADEB3B701B43B0BEDBFEEEDC0597834BE77D5");
            });

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.ToTable("orderitem");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.OrderId, "IX_01DC8234EFFE848F4BACFA16F95AA7A4EF77375D");

                entity.HasIndex(e => e.ProductId, "IX_25727F4EB701F202F56ABC70D9470E7FB2F2D00B");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributeDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.AttributesXml)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DiscountAmountExclTax).HasPrecision(18, 4);

                entity.Property(e => e.DiscountAmountInclTax).HasPrecision(18, 4);

                entity.Property(e => e.DownloadCount).HasColumnType("int(11)");

                entity.Property(e => e.ItemWeight).HasPrecision(18, 4);

                entity.Property(e => e.LicenseDownloadId).HasColumnType("int(11)");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.OriginalProductCost).HasPrecision(18, 4);

                entity.Property(e => e.PriceExclTax).HasPrecision(18, 4);

                entity.Property(e => e.PriceInclTax).HasPrecision(18, 4);

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.RentalEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.RentalStartDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UnitPriceExclTax).HasPrecision(18, 4);

                entity.Property(e => e.UnitPriceInclTax).HasPrecision(18, 4);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_3F98C065AAC22F3BC70A69B862886677F0A7104B");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_AC4D982F947AEF7F6B0F4170F1A85A2E086EAD32");
            });

            modelBuilder.Entity<OrderNote>(entity =>
            {
                entity.ToTable("ordernote");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.OrderId, "IX_467179DFA023725B2181B4EFF2F3C95252D34FB4");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.DownloadId).HasColumnType("int(11)");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderNote)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_748F6F5F04127871B1C2DCBB79259D6B69E20F77");
            });

            modelBuilder.Entity<Permissionrecord>(entity =>
            {
                entity.ToTable("permissionrecord");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasMany(d => d.CustomerRole)
                    .WithMany(p => p.PermissionRecord)
                    .UsingEntity<Dictionary<string, object>>(
                        "PermissionrecordRoleMapping",
                        l => l.HasOne<Customerrole>().WithMany().HasForeignKey("CustomerRoleId").HasConstraintName("FK_C53044341A77570833FA078A242CC1D44427DF98"),
                        r => r.HasOne<Permissionrecord>().WithMany().HasForeignKey("PermissionRecordId").HasConstraintName("FK_0D64D72F00FE64AEE0028D9D79117C3549742A4A"),
                        j =>
                        {
                            j.HasKey("PermissionRecordId", "CustomerRoleId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("permissionrecord_role_mapping").HasCharSet("latin1").UseCollation("latin1_swedish_ci");

                            j.HasIndex(new[] { "PermissionRecordId" }, "IX_998C4F8A5D91E3E4FDC76D88B167DE40A75A3259");

                            j.HasIndex(new[] { "CustomerRoleId" }, "IX_E7B19180C681C3B292B2234BF89F7F3FB62264BF");

                            j.IndexerProperty<int>("PermissionRecordId").HasColumnType("int(11)").HasColumnName("PermissionRecord_Id");

                            j.IndexerProperty<int>("CustomerRoleId").HasColumnType("int(11)").HasColumnName("CustomerRole_Id");
                        });
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("picture");

                entity.HasIndex(e => e.Id, "IX_Picture_Id");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AltAttribute)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(40)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SeoFilename)
                    .HasMaxLength(300)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TitleAttribute)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.VirtualPath)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Picturebinary>(entity =>
            {
                entity.ToTable("picturebinary");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.PictureId, "IX_E19B7EA10CC9EEDC673118A073359DDDD6E23D5E");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PictureId).HasColumnType("int(11)");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.PictureBinary)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("FK_6532A760FDE22EF02E68F5243C97637AD8ECDE49");
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.ToTable("poll");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.LanguageId, "IX_ED22A23331718AB1C4E03DC35EE6CE7A772786E8");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.LanguageId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.Property(e => e.SystemKeyword)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Poll)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_4402D073D3F739D18A5C2BE1F959679011669270");
            });

            modelBuilder.Entity<Pollanswer>(entity =>
            {
                entity.ToTable("pollanswer");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.PollId, "IX_CEB5FCB66C26383053ECFC887B4B724CEC3DA43A");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NumberOfVotes).HasColumnType("int(11)");

                entity.Property(e => e.PollId).HasColumnType("int(11)");

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.Pollanswer)
                    .HasForeignKey(d => d.PollId)
                    .HasConstraintName("FK_68084325B1805F58E241D6E0799C6B6567D1C70F");
            });

            modelBuilder.Entity<Pollvotingrecord>(entity =>
            {
                entity.ToTable("pollvotingrecord");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_0076E1ECE40F941D4C0E2C14BFD3E8385771812D");

                entity.HasIndex(e => e.PollAnswerId, "IX_623CFDF34577171DD8C2C47A6F2A473E1BD97E4F");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.PollAnswerId).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PollvotingRecord)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_77B1EB3129F0FAF02D99199E41A4F8186AF91590");

                entity.HasOne(d => d.PollAnswer)
                    .WithMany(p => p.Pollvotingrecord)
                    .HasForeignKey(d => d.PollAnswerId)
                    .HasConstraintName("FK_188D6A061E1F8C173E252F0D31485D5467297023");
            });

            modelBuilder.Entity<Predefinedproductattributevalue>(entity =>
            {
                entity.ToTable("predefinedproductattributevalue");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductAttributeId, "IX_0B8B35187AF308E8F9D8B2E28B3DA957BE85A5DB");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cost).HasPrecision(18, 4);

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PriceAdjustment).HasPrecision(18, 4);

                entity.Property(e => e.ProductAttributeId).HasColumnType("int(11)");

                entity.Property(e => e.WeightAdjustment).HasPrecision(18, 4);

                entity.HasOne(d => d.ProductAttribute)
                    .WithMany(p => p.PredeFinedProductAttributeValue)
                    .HasForeignKey(d => d.ProductAttributeId)
                    .HasConstraintName("FK_0C60532AE4C442823711F67F98C40D27BCA2F59C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Id, "IX_Products_Id");

                entity.HasIndex(e => e.Name, "IX_Products_Name");

                entity.HasIndex(e => e.Sku, "IX_Product_Sku");

                entity.HasIndex(e => e.ManufacturerPartNumber, "IX_Product_ManufacturerPM");

                entity.HasIndex(e => e.LimitedToStores, "IX_Product_LimitedToStores");

                entity.HasIndex(e => e.ParentGroupedProductId, "IX_Product_ParentGroupedProductId");

                entity.HasIndex(e => e.Published, "IX_Product_Published");

                entity.HasIndex(e => e.ShowOnHomepage, "IX_Product_ShowOnHomepage");

                entity.HasIndex(e => e.SubjectToAcl, "IX_Product_SubjectToAcl");

                entity.HasIndex(e => e.VisibleIndividually, "IX_Product_VisibleIndividually");

                entity.HasIndex(e => e.DisplayOrder, "IX_Products_DisplayOrder");


                entity.HasIndex(e => new { e.Id, e.Deleted }, "IX_Product_Delete_Id");

                entity.HasIndex(e => new { e.Id, e.DisplayOrder }, "IX_Products_Id_DisplayOrder");

                entity.HasIndex(e => new { e.Deleted, e.Published }, "IX_Product_Deleted_and_Published");

                entity.HasIndex(e => new { e.Deleted, e.Published, e.MarkAsNew }, "IX_Products_Published_Deleted_MarkAsNew");

                entity.HasIndex(e => new { e.Id, e.Deleted, e.VisibleIndividually }, "IX_Product_Delete_Id_VisibleIndividually");

                entity.HasIndex(e => new { e.Deleted, e.Published, e.VisibleIndividually }, "IX_Product_Deleted_Published_VisibleIndividually");

                entity.HasIndex(e => new { e.Id, e.Deleted, e.Published, e.MarkAsNew, e.LimitedToStores }, "IX_Products_Published_Deleted_MarkAsNew_LimitedToStores_Id");

                entity.HasIndex(e => new { e.Price, e.AvailableStartDateTimeUtc, e.AvailableEndDateTimeUtc, e.Published, e.Deleted }, "IX_Product_PriceDatesEtc");

                entity.HasIndex(e => new { e.Deleted, e.VendorId, e.ProductTypeId, e.ManageInventoryMethodId, e.MinStockQuantity, e.UseMultipleWarehouses }, "IX_GetLowStockProducts");


                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AdditionalShippingCharge).HasPrecision(18, 4);

                entity.Property(e => e.AdminComment)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.AllowedQuantities)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ApprovedRatingSum).HasColumnType("int(11)");

                entity.Property(e => e.ApprovedTotalReviews).HasColumnType("int(11)");

                entity.Property(e => e.AvailableEndDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.AvailableStartDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.BackorderModeId).HasColumnType("int(11)");

                entity.Property(e => e.BasepriceAmount).HasPrecision(18, 4);

                entity.Property(e => e.BasepriceBaseAmount).HasPrecision(18, 4);

                entity.Property(e => e.BasepriceBaseUnitId).HasColumnType("int(11)");

                entity.Property(e => e.BasepriceUnitId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.DeliveryDateId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.DownloadActivationTypeId).HasColumnType("int(11)");

                entity.Property(e => e.DownloadExpirationDays).HasColumnType("int(11)");

                entity.Property(e => e.DownloadId).HasColumnType("int(11)");

                entity.Property(e => e.FullDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.GiftCardTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Gtin)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Height).HasPrecision(18, 4);

                entity.Property(e => e.Length).HasPrecision(18, 4);

                entity.Property(e => e.LowStockActivityId).HasColumnType("int(11)");

                entity.Property(e => e.ManageInventoryMethodId).HasColumnType("int(11)");

                entity.Property(e => e.ManufacturerPartNumber)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MarkAsNewEndDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.MarkAsNewStartDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.MaxNumberOfDownloads).HasColumnType("int(11)");

                entity.Property(e => e.MaximumCustomerEnteredPrice).HasPrecision(18, 4);

                entity.Property(e => e.MetaDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MinStockQuantity).HasColumnType("int(11)");

                entity.Property(e => e.MinimumCustomerEnteredPrice).HasPrecision(18, 4);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.NotApprovedRatingSum).HasColumnType("int(11)");

                entity.Property(e => e.NotApprovedTotalReviews).HasColumnType("int(11)");

                entity.Property(e => e.NotifyAdminForQuantityBelow).HasColumnType("int(11)");

                entity.Property(e => e.OldPrice).HasPrecision(18, 4);

                entity.Property(e => e.OrderMaximumQuantity).HasColumnType("int(11)");

                entity.Property(e => e.OrderMinimumQuantity).HasColumnType("int(11)");

                entity.Property(e => e.OverriddenGiftCardAmount).HasPrecision(18, 4);

                entity.Property(e => e.ParentGroupedProductId).HasColumnType("int(11)");

                entity.Property(e => e.PreOrderAvailabilityStartDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.Price).HasPrecision(18, 4);

                entity.Property(e => e.ProductAvailabilityRangeId).HasColumnType("int(11)");

                entity.Property(e => e.ProductCost).HasPrecision(18, 4);

                entity.Property(e => e.ProductTemplateId).HasColumnType("int(11)");

                entity.Property(e => e.ProductTypeId).HasColumnType("int(11)");

                entity.Property(e => e.RecurringCycleLength).HasColumnType("int(11)");

                entity.Property(e => e.RecurringCyclePeriodId).HasColumnType("int(11)");

                entity.Property(e => e.RecurringTotalCycles).HasColumnType("int(11)");

                entity.Property(e => e.RentalPriceLength).HasColumnType("int(11)");

                entity.Property(e => e.RentalPricePeriodId).HasColumnType("int(11)");

                entity.Property(e => e.RequiredProductIds)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SampleDownloadId).HasColumnType("int(11)");

                entity.Property(e => e.ShortDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Sku)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StockQuantity).HasColumnType("int(11)");

                entity.Property(e => e.TaxCategoryId).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.UserAgreementText)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.VendorId).HasColumnType("int(11)");

                entity.Property(e => e.WarehouseId).HasColumnType("int(11)");

                entity.Property(e => e.Weight).HasPrecision(18, 4);

                entity.Property(e => e.Width).HasPrecision(18, 4);

                entity.HasMany(d => d.ProductTag)
                    .WithMany(p => p.Product)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductProductTagMapping",
                        l => l.HasOne<ProductTag>().WithMany().HasForeignKey("ProductTagId").HasConstraintName("FK_109FC058A5577EEB67D2F3A876A4269E693BEDA8"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK_2F97322CE12E6881AE559D240E0CF60647E33676"),
                        j =>
                        {
                            j.HasKey("ProductId", "ProductTagId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("product_producttag_mapping").HasCharSet("latin1").UseCollation("latin1_swedish_ci");

                            j.HasIndex(new[] { "ProductTagId" }, "IX_5A62FE7519887322703971B07D62C2648D56BDEB");

                            j.HasIndex(new[] { "ProductId" }, "IX_5F850DC84A298A0021177DFFE6DA6AF5A8BA529D");

                            j.IndexerProperty<int>("ProductId").HasColumnType("int(11)").HasColumnName("Product_Id");

                            j.IndexerProperty<int>("ProductTagId").HasColumnType("int(11)").HasColumnName("ProductTag_Id");
                        });
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_category_mapping");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CategoryId, "IX_65D0E0647344EB198B9C2CE245C24526EA026B04");

                entity.HasIndex(e => e.ProductId, "IX_C069A2C78E4169E39784E2F8D1C8390483CCDC24");

                entity.HasIndex(e => new { e.ProductId, e.IsFeaturedProduct }, "IX_PCM_ProductId_Extended");

                entity.HasIndex(e => new { e.CategoryId, e.ProductId }, "IX_PCM_Product_and_Category");

                entity.HasIndex(e => e.IsFeaturedProduct, "IX_Product_Category_Mapping_IsFeaturedProduct");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategoryMapping)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_073BBE7E6F5507EB5B5F0F297A38DB14FB382AE9");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategoryMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_F95DA02385C247415A37EE6ED15A49BC3E462864");
            });

            modelBuilder.Entity<ProductManufacturerMapping>(entity =>
            {
                entity.ToTable("product_manufacturer_mapping");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId, "IX_4DE2FF87C02296F96D7DA49634AE6719C03E5E06");

                entity.HasIndex(e => e.ManufacturerId, "IX_DABA4762DFE5DDE81827BC9AEBC96E0930755460");

                entity.HasIndex(e => new { e.ProductId, e.IsFeaturedProduct }, "IX_PMM_ProductId_Extended");

                entity.HasIndex(e => new { e.ManufacturerId, e.ProductId }, "IX_PMM_Product_and_Manufacturer");

                entity.HasIndex(e => e.IsFeaturedProduct, "IX_Product_Manufacturer_Mapping_IsFeaturedProduct");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ManufacturerId).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.ProductManufacturerMapping)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK_80E3F417D8B858D1DE96A4A7A04DCE0700F8B9A3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductManufacturerMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_18E35C063DE3F9DD5BDF711CE1519DD90E39B63C");
            });

            modelBuilder.Entity<ProductPictureMapping>(entity =>
            {
                entity.ToTable("product_picture_mapping");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => new { e.Id, e.DisplayOrder }, "IX_Product_Picture_Mapping_Id_DisplayOrder");

                entity.HasIndex(e => e.ProductId, "IX_Product_Picture_Mapping_ProductId");

                entity.HasIndex(e => new { e.ProductId, e.DisplayOrder, e.Id }, "IX_Product_Picture_Mapping_ProductId_DisplayOrder_Id");

                entity.HasIndex(e => new { e.ProductId, e.PictureId }, "IX_Product_Picture_Mapping_ProductId_PictureId");

                entity.HasIndex(e => e.PictureId, "IX_product_picture_mapping_PictureId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.PictureId).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.HasOne(d => d.Picture)
                    .WithMany(p => p.ProductPictureMapping)
                    .HasForeignKey(d => d.PictureId)
                    .HasConstraintName("FK_EC3B5E9AF7965B2A51DC73A0B47AC0FAB063E572");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPictureMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_D73027800FBCA0976B3664AA2B14624AA6A04706");
            });

            modelBuilder.Entity<ProductProductattributeMapping>(entity =>
            {
                entity.ToTable("product_productattribute_mapping");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductAttributeId, "IX_47FA8F827F33CA5D7C889B64078C36A49F6790A6");

                entity.HasIndex(e => e.ProductId, "IX_F6226437D41700C3BDEDDE266458E52BCE9E3715");

                entity.HasIndex(e => new { e.ProductId, e.DisplayOrder }, "IX_Product_ProductAttribute_Mapping_ProductId_DisplayOrder");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributeControlTypeId).HasColumnType("int(11)");

                entity.Property(e => e.ConditionAttributeXml)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DefaultValue)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ProductAttributeId).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.TextPrompt)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ValidationFileAllowedExtensions)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ValidationFileMaximumSize).HasColumnType("int(11)");

                entity.Property(e => e.ValidationMaxLength).HasColumnType("int(11)");

                entity.Property(e => e.ValidationMinLength).HasColumnType("int(11)");

                entity.HasOne(d => d.ProductAttribute)
                    .WithMany(p => p.ProductProductattributeMapping)
                    .HasForeignKey(d => d.ProductAttributeId)
                    .HasConstraintName("FK_CB9C37622581D2B6F728E49884CDE88E4165F79C");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductProductattributeMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_BF77199B4E9AA217913E748D643B23876607F875");
            });

            modelBuilder.Entity<ProductSpecificationattributeMapping>(entity =>
            {
                entity.ToTable("product_specificationattribute_mapping");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId, "IX_6E3598F36D97BFA8D2B1DA6A2D670FA36334106B");

                entity.HasIndex(e => e.SpecificationAttributeOptionId, "IX_EE669865DEDFD7AEFB45F2F89EF1E442329254F3");

                entity.HasIndex(e => e.AllowFiltering, "IX_PSAM_AllowFiltering");

                entity.HasIndex(e => new { e.SpecificationAttributeOptionId, e.AllowFiltering }, "IX_PSAM_SpecificationAttributeOptionId_AllowFiltering");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributeTypeId).HasColumnType("int(11)");

                entity.Property(e => e.CustomValue)
                    .HasMaxLength(4000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.SpecificationAttributeOptionId).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSpecificationattributeMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_867782688814CFB630157CD09220E35E6729D479");

                entity.HasOne(d => d.SpecificationAttributeOption)
                    .WithMany(p => p.ProductSpecificationAttributeMapping)
                    .HasForeignKey(d => d.SpecificationAttributeOptionId)
                    .HasConstraintName("FK_066E0888389D7DFD2BA85BCB218CDA1F5B577540");
            });

            modelBuilder.Entity<Productattribute>(entity =>
            {
                entity.ToTable("productattribute");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Id, "IX_ProductAttribute_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<ProductAttributeCombination>(entity =>
            {
                entity.ToTable("productattributecombination");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId, "IX_10742F34F6C98BF11B11FBFB350254FBD0802277");

                entity.HasIndex(e => new { e.Sku, e.ProductId }, "IX_ProductAttributeCombination_Sku_ProductId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributesXml)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Gtin)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ManufacturerPartNumber)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MinStockQuantity).HasColumnType("int(11)");

                entity.Property(e => e.NotifyAdminForQuantityBelow).HasColumnType("int(11)");

                entity.Property(e => e.OverriddenPrice).HasPrecision(18, 4);

                entity.Property(e => e.PictureId).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Sku)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StockQuantity).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productattributecombination)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_DDD3F3C6C485CBBF9F6ABD2C9E8A795D249343A8");
            });

            modelBuilder.Entity<Productattributevalue>(entity =>
            {
                entity.ToTable("productattributevalue");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductAttributeMappingId, "IX_C8FD7E41BDF864606B567EA54EAAB6219686F356");

                entity.HasIndex(e => new { e.ProductAttributeMappingId, e.DisplayOrder }, "IX_ProductAttributeValue_ProductAttributeMappingId_DisplayOrder");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AssociatedProductId).HasColumnType("int(11)");

                entity.Property(e => e.AttributeValueTypeId).HasColumnType("int(11)");

                entity.Property(e => e.ColorSquaresRgb)
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Cost).HasPrecision(18, 4);

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ImageSquaresPictureId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PictureId).HasColumnType("int(11)");

                entity.Property(e => e.PriceAdjustment).HasPrecision(18, 4);

                entity.Property(e => e.ProductAttributeMappingId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.WeightAdjustment).HasPrecision(18, 4);

                entity.HasOne(d => d.ProductAttributeMapping)
                    .WithMany(p => p.Productattributevalue)
                    .HasForeignKey(d => d.ProductAttributeMappingId)
                    .HasConstraintName("FK_8E53C9EE981897428A0481B22AB19DC3EA908F05");
            });

            modelBuilder.Entity<Productavailabilityrange>(entity =>
            {
                entity.ToTable("productavailabilityrange");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Productreview>(entity =>
            {
                entity.ToTable("productreview");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_34DF548025246734401C64D1904FDC5119A405CC");

                entity.HasIndex(e => e.ProductId, "IX_C3A2EB2CAD92A0F3C47CCA524FD2848BC0026B81");

                entity.HasIndex(e => e.StoreId, "IX_CCA2A4F066E9F5700F1C5792E4F4D96B78E887D6");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.HelpfulNoTotal).HasColumnType("int(11)");

                entity.Property(e => e.HelpfulYesTotal).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Rating).HasColumnType("int(11)");

                entity.Property(e => e.ReplyText)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ReviewText)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_3C690095715D0BF8984649454E1A36AE5864B9B9");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productreview)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_8F287941FE06F0E785170933128CFB1FFD7D4337");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ProductReview)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_D161A45B1C012B5355F826D126E9F6EE3638C54B");
            });

            modelBuilder.Entity<ProductreviewReviewtypeMapping>(entity =>
            {
                entity.ToTable("productreview_reviewtype_mapping");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ReviewTypeId, "IX_A80FB7B7F056FCA6FF7011C07E1DF0DB21DD2723");

                entity.HasIndex(e => e.ProductReviewId, "IX_E6BD958D6D6A3B595249B1F2FB2836558198DBD6");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ProductReviewId).HasColumnType("int(11)");

                entity.Property(e => e.Rating).HasColumnType("int(11)");

                entity.Property(e => e.ReviewTypeId).HasColumnType("int(11)");

                entity.HasOne(d => d.ProductReview)
                    .WithMany(p => p.ProductreviewReviewtypeMapping)
                    .HasForeignKey(d => d.ProductReviewId)
                    .HasConstraintName("FK_9F3C938A74BB9514AF74BE9BAD599F8309F47C5D");

                entity.HasOne(d => d.ReviewType)
                    .WithMany(p => p.ProductreviewReviewtypeMapping)
                    .HasForeignKey(d => d.ReviewTypeId)
                    .HasConstraintName("FK_E8B0BE63569CE2E60AE1B1E50FE527E0E195C439");
            });

            modelBuilder.Entity<Productreviewhelpfulness>(entity =>
            {
                entity.ToTable("productreviewhelpfulness");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductReviewId, "IX_7528780A72E711ED59C639ABE6F5E79394EFC9C8");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.ProductReviewId).HasColumnType("int(11)");

                entity.HasOne(d => d.ProductReview)
                    .WithMany(p => p.Productreviewhelpfulness)
                    .HasForeignKey(d => d.ProductReviewId)
                    .HasConstraintName("FK_4FC0063973C0BF85F76DA15A03640604649565FF");
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.ToTable("producttag");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Name, "IX_ProductTag_Name");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Producttemplate>(entity =>
            {
                entity.ToTable("producttemplate");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.IgnoredProductTypes)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ViewPath)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Productwarehouseinventory>(entity =>
            {
                entity.ToTable("productwarehouseinventory");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId, "IX_194D2A5B9EF87F154B5DD69A1834FAFCDD487B94");

                entity.HasIndex(e => e.WarehouseId, "IX_D53A72DA5744EF523A405436021498998DDFABEA");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.ReservedQuantity).HasColumnType("int(11)");

                entity.Property(e => e.StockQuantity).HasColumnType("int(11)");

                entity.Property(e => e.WarehouseId).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productwarehouseinventory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_2120EF95AE859D188A03335EFD782A551C98613B");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.ProductWarehouseInventory)
                    .HasForeignKey(d => d.WarehouseId)
                    .HasConstraintName("FK_62F3117088899BC46531C64816CB0526AEE29017");
            });

            modelBuilder.Entity<Queuedemail>(entity =>
            {
                entity.ToTable("queuedemail");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.EmailAccountId, "IX_EADE912948B576BF4259B7C4050DC339A54F63AE");

                entity.HasIndex(e => e.CreatedOnUtc, "IX_QueuedEmail_CreatedOnUtc");

                entity.HasIndex(e => new { e.SentOnUtc, e.DontSendBeforeDateUtc }, "IX_QueuedEmail_SentOnUtc_DontSendBeforeDateUtc_Extended");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttachedDownloadId).HasColumnType("int(11)");

                entity.Property(e => e.AttachmentFileName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.AttachmentFilePath)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Bcc)
                    .HasMaxLength(500)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Body)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Cc)
                    .HasMaxLength(500)
                    .HasColumnName("CC")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.DontSendBeforeDateUtc).HasColumnType("datetime");

                entity.Property(e => e.EmailAccountId).HasColumnType("int(11)");

                entity.Property(e => e.From)
                    .IsRequired()
                    .HasMaxLength(500)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FromName)
                    .HasMaxLength(500)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PriorityId).HasColumnType("int(11)");

                entity.Property(e => e.ReplyTo)
                    .HasMaxLength(500)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ReplyToName)
                    .HasMaxLength(500)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SentOnUtc).HasColumnType("datetime");

                entity.Property(e => e.SentTries).HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.To)
                    .IsRequired()
                    .HasMaxLength(500)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ToName)
                    .HasMaxLength(500)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.EmailAccount)
                    .WithMany(p => p.QueuedEmail)
                    .HasForeignKey(d => d.EmailAccountId)
                    .HasConstraintName("FK_1B62499F76869C0810A8F3A176F7658DB37DAB4A");
            });

            modelBuilder.Entity<RecurringPayment>(entity =>
            {
                entity.ToTable("recurringpayment");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.InitialOrderId, "IX_BE0E46A4D4C7979A25335958B1321179F95A9263");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CycleLength).HasColumnType("int(11)");

                entity.Property(e => e.CyclePeriodId).HasColumnType("int(11)");

                entity.Property(e => e.InitialOrderId).HasColumnType("int(11)");

                entity.Property(e => e.StartDateUtc).HasColumnType("datetime");

                entity.Property(e => e.TotalCycles).HasColumnType("int(11)");

                entity.HasOne(d => d.InitialOrder)
                    .WithMany(p => p.RecurringPayment)
                    .HasForeignKey(d => d.InitialOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_1AA4E6EB7D08262CA4702B6F3693FAF24973E60A");
            });

            modelBuilder.Entity<Recurringpaymenthistory>(entity =>
            {
                entity.ToTable("recurringpaymenthistory");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.RecurringPaymentId, "IX_F15784D9E7C2AA49EAB3905620E308A649587B16");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.RecurringPaymentId).HasColumnType("int(11)");

                entity.HasOne(d => d.RecurringPayment)
                    .WithMany(p => p.RecurringPaymentHistory)
                    .HasForeignKey(d => d.RecurringPaymentId)
                    .HasConstraintName("FK_28C0076175DB569AD6CA81CB2E7BFFFE04AD0A03");
            });

            modelBuilder.Entity<Relatedproduct>(entity =>
            {
                entity.ToTable("relatedproduct");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId1, "IX_RelatedProduct_ProductId1");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.ProductId1).HasColumnType("int(11)");

                entity.Property(e => e.ProductId2).HasColumnType("int(11)");
            });

            modelBuilder.Entity<ReturnRequest>(entity =>
            {
                entity.ToTable("returnrequest");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_6111E95274ADB34D717DB9F3FF6270CEC853028C");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomNumber)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CustomerComments)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.OrderItemId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.ReasonForReturn)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.RequestedAction)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ReturnRequestStatusId).HasColumnType("int(11)");

                entity.Property(e => e.ReturnedQuantity).HasColumnType("int(11)");

                entity.Property(e => e.StaffNotes)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.UploadedFileId).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReturnRequest)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_AD4A43CA98A319E62AB648C84A660386E3E2962D");
            });

            modelBuilder.Entity<Returnrequestaction>(entity =>
            {
                entity.ToTable("returnrequestaction");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Returnrequestreason>(entity =>
            {
                entity.ToTable("returnrequestreason");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Reviewtype>(entity =>
            {
                entity.ToTable("reviewtype");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Rewardpointshistory>(entity =>
            {
                entity.ToTable("rewardpointshistory");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CustomerId, "IX_60F9BB409B5074CAA77093426EBEF6A510194A0A");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.EndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Points).HasColumnType("int(11)");

                entity.Property(e => e.PointsBalance).HasColumnType("int(11)");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.UsedAmount).HasPrecision(18, 4);

                entity.Property(e => e.ValidPoints).HasColumnType("int(11)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RewardPointsHistory)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_18FE24AC76D8CA88D3890A2915666335388BF06B");
            });

            modelBuilder.Entity<Scheduletask>(entity =>
            {
                entity.ToTable("scheduletask");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.LastEnabledUtc).HasColumnType("datetime");

                entity.Property(e => e.LastEndUtc).HasColumnType("datetime");

                entity.Property(e => e.LastStartUtc).HasColumnType("datetime");

                entity.Property(e => e.LastSuccessUtc).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Seconds).HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Searchterm>(entity =>
            {
                entity.ToTable("searchterm");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Count).HasColumnType("int(11)");

                entity.Property(e => e.Keyword)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("setting");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Id, "IX_Setting_Id");

                entity.HasIndex(e => e.Name, "IX_Setting_Name");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(6000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("shipment");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.OrderId, "IX_D7D61795361B29A6E41BFFB60A36B99CE2E77A50");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AdminComment)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.DeliveryDateUtc).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.Property(e => e.ReadyForPickupDateUtc).HasColumnType("datetime");

                entity.Property(e => e.ShippedDateUtc).HasColumnType("datetime");

                entity.Property(e => e.TotalWeight).HasPrecision(18, 4);

                entity.Property(e => e.TrackingNumber)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Shipment)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_D2D2913CAD954BFA003ED2AE92ED646226393F61");
            });

            modelBuilder.Entity<Shipmentitem>(entity =>
            {
                entity.ToTable("shipmentitem");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ShipmentId, "IX_80E4CFA78264430E212118ECB894E1B81E813243");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.OrderItemId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.ShipmentId).HasColumnType("int(11)");

                entity.Property(e => e.WarehouseId).HasColumnType("int(11)");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentItem)
                    .HasForeignKey(d => d.ShipmentId)
                    .HasConstraintName("FK_18C8746C96E44FC1E3789352C0630584E6D6D096");
            });

            modelBuilder.Entity<Shippingmethod>(entity =>
            {
                entity.ToTable("shippingmethod");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasMany(d => d.Country)
                    .WithMany(p => p.ShippingMethod)
                    .UsingEntity<Dictionary<string, object>>(
                        "Shippingmethodrestriction",
                        l => l.HasOne<Country>().WithMany().HasForeignKey("CountryId").HasConstraintName("FK_E0136F2DC41B921F877F72C01FC84164E48C494D"),
                        r => r.HasOne<Shippingmethod>().WithMany().HasForeignKey("ShippingMethodId").HasConstraintName("FK_94A22CC12F6B31B9CA44439CEF6463A054E62508"),
                        j =>
                        {
                            j.HasKey("ShippingMethodId", "CountryId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("shippingmethodrestrictions").HasCharSet("latin1").UseCollation("latin1_swedish_ci");

                            j.HasIndex(new[] { "CountryId" }, "IX_98FECBA712EC3A7AF759C110137BABE6423115BA");

                            j.HasIndex(new[] { "ShippingMethodId" }, "IX_A67E057E4259D823DFDB3A4FFFBDC22F9FF88570");

                            j.IndexerProperty<int>("ShippingMethodId").HasColumnType("int(11)").HasColumnName("ShippingMethod_Id");

                            j.IndexerProperty<int>("CountryId").HasColumnType("int(11)").HasColumnName("Country_Id");
                        });
            });

            modelBuilder.Entity<Shoppingcartitem>(entity =>
            {
                entity.ToTable("shoppingcartitem");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId, "IX_874149FC8129BC9A477567717104BF5951801611");

                entity.HasIndex(e => e.CustomerId, "IX_F59371B91ADC899F64B183252FFDAD65F99A60B0");

                entity.HasIndex(e => new { e.ShoppingCartTypeId, e.CustomerId }, "IX_ShoppingCartItem_ShoppingCartTypeId_CustomerId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributesXml)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.CustomerEnteredPrice).HasPrecision(18, 4);

                entity.Property(e => e.CustomerId).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.RentalEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.RentalStartDateUtc).HasColumnType("datetime");

                entity.Property(e => e.ShoppingCartTypeId).HasColumnType("int(11)");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.Property(e => e.UpdatedOnUtc).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoppingCartItem)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_71A82F96A45513FC75E7FE9D5D67F07A5FAFE1CF");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Shoppingcartitem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_F181ACB6395A22D53CA62D12693DA9ED42583B64");
            });

            modelBuilder.Entity<Specificationattribute>(entity =>
            {
                entity.ToTable("specificationattribute");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.SpecificationAttributeGroupId, "IX_A448A454CD518AB0B594506AF5062542BBA79170");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SpecificationAttributeGroupId).HasColumnType("int(11)");

                entity.HasOne(d => d.SpecificationAttributeGroup)
                    .WithMany(p => p.SpecificationAttribute)
                    .HasForeignKey(d => d.SpecificationAttributeGroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_87B01C9358C3462DE4ABBD3B9A71A65FD52D531E");
            });

            modelBuilder.Entity<Specificationattributegroup>(entity =>
            {
                entity.ToTable("specificationattributegroup");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Specificationattributeoption>(entity =>
            {
                entity.ToTable("specificationattributeoption");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.SpecificationAttributeId, "IX_20CA206E1041B61FFB1739DEAB2C2134475DBA4B");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ColorSquaresRgb)
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SpecificationAttributeId).HasColumnType("int(11)");

                entity.HasOne(d => d.SpecificationAttribute)
                    .WithMany(p => p.SpecificationAttributeOption)
                    .HasForeignKey(d => d.SpecificationAttributeId)
                    .HasConstraintName("FK_A5ED789CA87B66B039B80950B073C05474673047");
            });

            modelBuilder.Entity<StateProvince>(entity =>
            {
                entity.ToTable("stateprovince");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.CountryId, "IX_B5D25FF62BAA11CE55190C311232C49C9C3206C8");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CountryId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.StateProvince)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_2BD698F1D0EEAFE0EC514A1BA4B53D34427C2478");
            });

            modelBuilder.Entity<Stockquantityhistory>(entity =>
            {
                entity.ToTable("stockquantityhistory");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId, "IX_52918ED84971F1AC2192FABA83628A7DB4AE9BCD");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CombinationId).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.QuantityAdjustment).HasColumnType("int(11)");

                entity.Property(e => e.StockQuantity).HasColumnType("int(11)");

                entity.Property(e => e.WarehouseId).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stockquantityhistory)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_81B360FE895B708886E24D3D34BBCB856549CA60");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Hosts, "IX_Store_Hosts");

                entity.HasIndex(e => e.Id, "IX_Store_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CompanyAddress)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CompanyPhoneNumber)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.CompanyVat)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DefaultLanguageId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Hosts)
                    .HasMaxLength(1000)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Storemapping>(entity =>
            {
                entity.ToTable("storemapping");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.StoreId, "IX_FC249F594D98DD91961F5A358D8544703BE6E138");

                entity.HasIndex(e => e.EntityId, "IX_StoreMapping_EntityId");

                entity.HasIndex(e => new { e.EntityId, e.EntityName }, "IX_StoreMapping_EntityId_EntityName");

                entity.HasIndex(e => e.EntityName, "IX_StoreMapping_EntityName");

                entity.HasIndex(e => new { e.EntityName, e.StoreId }, "IX_StoreMapping_EntityName_StoreId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EntityId).HasColumnType("int(11)");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreMapping)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_2FB439EFF2DAF1A6ACA92AD5255B9C574469C71C");
            });

            modelBuilder.Entity<Taxcategory>(entity =>
            {
                entity.ToTable("taxcategory");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Tierprice>(entity =>
            {
                entity.ToTable("tierprice");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.ProductId, "IX_231B5005C419BF705692EE4AB5BBEF7EFFA20935");

                entity.HasIndex(e => e.CustomerRoleId, "IX_D7FF9897F12FC9DE46D1D9AA52049475E05C6946");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CustomerRoleId).HasColumnType("int(11)");

                entity.Property(e => e.EndDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.Price).HasPrecision(18, 4);

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.StartDateTimeUtc).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnType("int(11)");

                entity.HasOne(d => d.CustomerRole)
                    .WithMany(p => p.Tierprice)
                    .HasForeignKey(d => d.CustomerRoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_B8EEC67C511E2BA65F0008D2F7E151565F226B42");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Tierprice)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_004281468E56AE8F2C879D1F25BA88F86D67437A");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Body)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.MetaDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaKeywords)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaTitle)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Password)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.SystemName)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Title)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TopicTemplateId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Topictemplate>(entity =>
            {
                entity.ToTable("topictemplate");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.ViewPath)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<UrlRecord>(entity =>
            {
                entity.ToTable("urlrecord");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => new { e.EntityId, e.EntityName, e.LanguageId }, "IX_UrlRecord_EntityId_EntityName_LanguageId")
                    .IsUnique();

                entity.HasIndex(e => new { e.EntityId, e.EntityName, e.LanguageId, e.IsActive }, "IX_UrlRecord_EntityId_EntityName_LanguageId_IsActive");

                entity.HasIndex(e => new { e.EntityId, e.EntityName, e.LanguageId, e.IsActive, e.Id }, "IX_UrlRecord_EntityId_EntityName_LanguageId_IsActive_Id");

                entity.HasIndex(e => e.Slug, "IX_UrlRecord_Slug");

                entity.HasIndex(e => new { e.Slug, e.IsActive, e.Id }, "IX_UrlRecord_Slug_IsActive_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EntityId).HasColumnType("int(11)");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.LanguageId).HasColumnType("int(11)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("vendor");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AddressId).HasColumnType("int(11)");

                entity.Property(e => e.AdminComment)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Description)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaDescription)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaKeywords)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.MetaTitle)
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PageSize).HasColumnType("int(11)");

                entity.Property(e => e.PageSizeOptions)
                    .HasMaxLength(200)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PictureId).HasColumnType("int(11)");

                entity.Property(e => e.PriceFrom).HasPrecision(18, 4);

                entity.Property(e => e.PriceTo).HasPrecision(18, 4);
            });

            modelBuilder.Entity<Vendorattribute>(entity =>
            {
                entity.ToTable("vendorattribute");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AttributeControlTypeId).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<VendorAttributeValue>(entity =>
            {
                entity.ToTable("vendorattributevalue");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.VendorAttributeId, "IX_C4D5E3F596710165FA89CD9C228D835174B8CB35");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DisplayOrder).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.VendorAttributeId).HasColumnType("int(11)");

                entity.HasOne(d => d.VendorAttribute)
                    .WithMany(p => p.VendorAttributeValue)
                    .HasForeignKey(d => d.VendorAttributeId)
                    .HasConstraintName("FK_77C5985CFDA88F9F771740B14E7CBAFDE3555D4E");
            });

            modelBuilder.Entity<Vendornote>(entity =>
            {
                entity.ToTable("vendornote");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.VendorId, "IX_5E01CCC29E29B4FBD22AD8195385ACD1130C2A47");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CreatedOnUtc).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.VendorId).HasColumnType("int(11)");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.VendorNote)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_24375B9B78673F3D7469961D1A4A30B72296B359");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("warehouse");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AddressId).HasColumnType("int(11)");

                entity.Property(e => e.AdminComment)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
