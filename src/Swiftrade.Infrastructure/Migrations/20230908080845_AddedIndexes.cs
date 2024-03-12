using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swiftrade.Infrastructure.Migrations
{
    public partial class AddedIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8");

            // migrationBuilder.CreateIndex(
            //     name: "IX_02F617482C79A6C2BE7A0C8A6455B2E8E14780EC",
            //     table: "aclrecord",
            //     column: "CustomerRoleId");

        //     migrationBuilder.CreateIndex(
        //         name: "IX_AclRecord_EntityId_EntityName",
        //         table: "aclrecord",
        //         columns: new[] { "EntityId", "EntityName" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_0F273FFBCE7BB550E87EADE8C0D4FE78CEA4F21A",
        //         table: "activitylog",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_ActivityLog_CreatedOnUtc",
        //         table: "activitylog",
        //         column: "CreatedOnUtc");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_FA05048FC292BA387AD9F54569223A2361D29543",
        //         table: "activitylog",
        //         column: "ActivityLogTypeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_0318CCE12D3601D14FD4102212A47D530180466D",
        //         table: "address",
        //         column: "CountryId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_4A044E7C99A04BAA49E77199A91412218B24A8C4",
        //         table: "address",
        //         column: "StateProvinceId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_B8DBEDC16E08BA4792A1836F0CFBAE45476188BC",
        //         table: "addressattributevalue",
        //         column: "AddressAttributeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_53E30AC40CBC90074D6593764F2E48388B497292",
        //         table: "affiliate",
        //         column: "AddressId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_8894A8AA1D20379488AAF6BD14062F7BFB17E220",
        //         table: "backinstocksubscription",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_CA2CD976F0AAC58A1BC6565C5FA026CCC23AF1A7",
        //         table: "backinstocksubscription",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_610623902D397FF33F3287BF1345D7512C66145D",
        //         table: "blogcomment",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_7EA6B2B4EAF446CC41EE99A3824A85C8190B57D0",
        //         table: "blogcomment",
        //         column: "BlogPostId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_9B64658D6D24EDEAB7F497D63D82313E0CCB64F5",
        //         table: "blogcomment",
        //         column: "StoreId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_EFC2F432AA3D91D9D6E18EDFF06769FF1B7D5CD8",
        //         table: "blogpost",
        //         column: "LanguageId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Category_Deleted_Extended",
        //         table: "category",
        //         column: "Deleted");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Category_DisplayOrder",
        //         table: "category",
        //         column: "DisplayOrder");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Category_LimitedToStores",
        //         table: "category",
        //         column: "LimitedToStores");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Category_ParentCategoryId",
        //         table: "category",
        //         column: "ParentCategoryId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Category_SubjectToAcl",
        //         table: "category",
        //         column: "SubjectToAcl");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_36B591D67F6ADB5848B096AF344F381721D1781C",
        //         table: "checkoutattributevalue",
        //         column: "CheckoutAttributeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Country_DisplayOrder",
        //         table: "country",
        //         column: "DisplayOrder");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Currency_DisplayOrder",
        //         table: "currency",
        //         column: "DisplayOrder");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_5FD07AEA757DD98D3E04CA86906517868F44A287",
        //         table: "customer",
        //         column: "ShippingAddress_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_79820CBB6A38BC446E7FC52E7582A458F3A2AC75",
        //         table: "customer",
        //         column: "BillingAddress_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Customer_CreatedOnUtc",
        //         table: "customer",
        //         column: "CreatedOnUtc");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Customer_CustomerGuid",
        //         table: "customer",
        //         column: "CustomerGuid");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Customer_Email",
        //         table: "customer",
        //         column: "Email");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Customer_SystemName",
        //         table: "customer",
        //         column: "SystemName");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Customer_Username",
        //         table: "customer",
        //         column: "Username");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_09E9645547A7290962418327EE12D590BC1995F5",
        //         table: "customer_customerrole_mapping",
        //         column: "Customer_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_E0FD9013E1AA40ED714BD90CE38AA3C1D57484E5",
        //         table: "customer_customerrole_mapping",
        //         column: "CustomerRole_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_64250EDA44F67EFAD151EB1EFE0D2EA08456B864",
        //         table: "customeraddresses",
        //         column: "Address_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_9AC0D6FE14A030F18305F46F428ACB6898B4187F",
        //         table: "customeraddresses",
        //         column: "Customer_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_F42BE25FE6DC8F058A887BA1DEFB46198BC8D321",
        //         table: "customerattributevalue",
        //         column: "CustomerAttributeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_154E5C21B851AD9590F318EF6F718DB570DAEFF1",
        //         table: "customerpassword",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_3B15D52F81BDC47B279B9DD028BD1445B9A462F7",
        //         table: "discount_appliedtocategories",
        //         column: "Discount_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_49CBAA99A1E2A276261D82400D383E5FE727C172",
        //         table: "discount_appliedtocategories",
        //         column: "Category_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_4878483EA6D877C2F4E05C5D2E7DCBCE5F1D7D84",
        //         table: "discount_appliedtomanufacturers",
        //         column: "Manufacturer_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_B27FB643C3BB153FA3E393FE3CE8AB72E6A6B90F",
        //         table: "discount_appliedtomanufacturers",
        //         column: "Discount_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_33C579DE1781A7E8E15007E3FE54F0FF377BC60C",
        //         table: "discount_appliedtoproducts",
        //         column: "Discount_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_57E9214528270AE442DF14F651EFC02B2218B19E",
        //         table: "discount_appliedtoproducts",
        //         column: "Product_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_B38979C2C3C47F2E4B698BDA6D236ECB9332F896",
        //         table: "discountrequirement",
        //         column: "DiscountId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_D506930CC015664811ECD666E873DB3A56442AC7",
        //         table: "discountrequirement",
        //         column: "ParentId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_8F03BAA695B2105F0748CD33C1C69257A187A6AC",
        //         table: "discountusagehistory",
        //         column: "DiscountId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_90D4BA0B388CAF5150F27E1D9F2781A06F77284E",
        //         table: "discountusagehistory",
        //         column: "OrderId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_6D54D5251B1D23560C6CCB69543958292FE936DC",
        //         table: "externalauthenticationrecord",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_8DCD3E5EEB323E614072D382CED0FDE15C28A20C",
        //         table: "forums_forum",
        //         column: "ForumGroupId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Forums_Forum_DisplayOrder",
        //         table: "forums_forum",
        //         column: "DisplayOrder");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Forums_Group_DisplayOrder",
        //         table: "forums_group",
        //         column: "DisplayOrder");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_66346A7D2B56A00742967506FC5896A954702923",
        //         table: "forums_post",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_BB7E36F50844E72B331791A9096CADB5DBFBA6C3",
        //         table: "forums_post",
        //         column: "TopicId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_CE01D00491CDDF94D755273812C89769B8A6D72D",
        //         table: "forums_postvote",
        //         column: "ForumPostId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_04445AF7F58A268687EF7EFAF57B1E4692C90756",
        //         table: "forums_subscription",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Forums_Subscription_ForumId",
        //         table: "forums_subscription",
        //         column: "ForumId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Forums_Subscription_TopicId",
        //         table: "forums_subscription",
        //         column: "TopicId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_74331CDF3DC43C580490017D2FF9557D66C6AF3C",
        //         table: "forums_topic",
        //         column: "ForumId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DDBC009BDA798D5E86F200A619BAEFEE2780A562",
        //         table: "forums_topic",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GenericAttribute_EntityId_and_KeyGroup",
        //         table: "genericattribute",
        //         columns: new[] { "EntityId", "KeyGroup" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_E753BB83C0D47CD444B41734828D6CE31BDA4547",
        //         table: "giftcard",
        //         column: "PurchasedWithOrderItemId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_2DDA907C9212253D7148AA484EFC08F8DB11DBB9",
        //         table: "giftcardusagehistory",
        //         column: "UsedWithOrderId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_8D5FE9820B51CCB45277D64FC6E52C55CDEB59CF",
        //         table: "giftcardusagehistory",
        //         column: "GiftCardId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Language_DisplayOrder",
        //         table: "language",
        //         column: "DisplayOrder");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_C902AB0FC6278AB50D88DBAAAE90B40D17CBE388",
        //         table: "localestringresource",
        //         column: "LanguageId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_LocaleStringResource",
        //         table: "localestringresource",
        //         columns: new[] { "ResourceName", "LanguageId" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DBC6F45E7AB497D690C477A31075255AF97FFBBF",
        //         table: "localizedproperty",
        //         column: "LanguageId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_E09C290A319BBF71BAEA063D33F45A248F16B85E",
        //         table: "log",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Log_CreatedOnUtc",
        //         table: "log",
        //         column: "CreatedOnUtc");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Manufacturer_DisplayOrder",
        //         table: "manufacturer",
        //         column: "DisplayOrder");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Manufacturer_LimitedToStores",
        //         table: "manufacturer",
        //         column: "LimitedToStores");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Manufacturer_SubjectToAcl",
        //         table: "manufacturer",
        //         column: "SubjectToAcl");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "UC_Version",
        //         table: "migrationversioninfo",
        //         column: "Version",
        //         unique: true);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_7F02E3C278A944BE59537727A19FEA3A6855AE27",
        //         table: "news",
        //         column: "LanguageId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_4327C9836AB73A3FD882D71C073014C5DF40D484",
        //         table: "newscomment",
        //         column: "NewsItemId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_BDAB1EFC98942D6D41898F6649AC03B2FBDA57E4",
        //         table: "newscomment",
        //         column: "StoreId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_FEA2E6F746138EB2B8393B8661D8A9091FBC9A46",
        //         table: "newscomment",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_NewsletterSubscription_Email_StoreId",
        //         table: "newslettersubscription",
        //         columns: new[] { "Email", "StoreId" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "FK_E2B3006CB294B6FD2E08E9DB53E7296283CB8A61",
        //         table: "order",
        //         column: "RewardPointsHistoryEntryId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_0E470D4A2077F13DD52B58146A78BB6D9FF598A3",
        //         table: "order",
        //         column: "PickupAddressId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_30A52D6385B52F71FB5EDB1D893B738E8549DE8B",
        //         table: "order",
        //         column: "ShippingAddressId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_D4D583CDFB5B9FA861705763C89DE617044108E3",
        //         table: "order",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_E7755CC7F881D5026F1484CD9F844657848310FB",
        //         table: "order",
        //         column: "BillingAddressId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Order_CreatedOnUtc",
        //         table: "order",
        //         column: "CreatedOnUtc");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_01DC8234EFFE848F4BACFA16F95AA7A4EF77375D",
        //         table: "orderitem",
        //         column: "OrderId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_25727F4EB701F202F56ABC70D9470E7FB2F2D00B",
        //         table: "orderitem",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_467179DFA023725B2181B4EFF2F3C95252D34FB4",
        //         table: "ordernote",
        //         column: "OrderId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_998C4F8A5D91E3E4FDC76D88B167DE40A75A3259",
        //         table: "permissionrecord_role_mapping",
        //         column: "PermissionRecord_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_E7B19180C681C3B292B2234BF89F7F3FB62264BF",
        //         table: "permissionrecord_role_mapping",
        //         column: "CustomerRole_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_E19B7EA10CC9EEDC673118A073359DDDD6E23D5E",
        //         table: "picturebinary",
        //         column: "PictureId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_ED22A23331718AB1C4E03DC35EE6CE7A772786E8",
        //         table: "poll",
        //         column: "LanguageId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_CEB5FCB66C26383053ECFC887B4B724CEC3DA43A",
        //         table: "pollanswer",
        //         column: "PollId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_0076E1ECE40F941D4C0E2C14BFD3E8385771812D",
        //         table: "pollvotingrecord",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_623CFDF34577171DD8C2C47A6F2A473E1BD97E4F",
        //         table: "pollvotingrecord",
        //         column: "PollAnswerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_0B8B35187AF308E8F9D8B2E28B3DA957BE85A5DB",
        //         table: "predefinedproductattributevalue",
        //         column: "ProductAttributeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GetLowStockProducts",
        //         table: "product",
        //         columns: new[] { "Deleted", "VendorId", "ProductTypeId", "ManageInventoryMethodId", "MinStockQuantity", "UseMultipleWarehouses" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_Delete_Id",
        //         table: "product",
        //         columns: new[] { "Deleted", "Id" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_Deleted_and_Published",
        //         table: "product",
        //         columns: new[] { "Published", "Deleted" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_LimitedToStores",
        //         table: "product",
        //         column: "LimitedToStores");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_ParentGroupedProductId",
        //         table: "product",
        //         column: "ParentGroupedProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_PriceDatesEtc",
        //         table: "product",
        //         columns: new[] { "Price", "AvailableStartDateTimeUtc", "AvailableEndDateTimeUtc", "Published", "Deleted" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_Published",
        //         table: "product",
        //         column: "Published");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_ShowOnHomepage",
        //         table: "product",
        //         column: "ShowOnHomepage");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_SubjectToAcl",
        //         table: "product",
        //         column: "SubjectToAcl");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_VisibleIndividually",
        //         table: "product",
        //         column: "VisibleIndividually");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_VisibleIndividually_Published_Deleted_Extended",
        //         table: "product",
        //         columns: new[] { "VisibleIndividually", "Published", "Deleted" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_65D0E0647344EB198B9C2CE245C24526EA026B04",
        //         table: "product_category_mapping",
        //         column: "CategoryId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_C069A2C78E4169E39784E2F8D1C8390483CCDC24",
        //         table: "product_category_mapping",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PCM_Product_and_Category",
        //         table: "product_category_mapping",
        //         columns: new[] { "CategoryId", "ProductId" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PCM_ProductId_Extended",
        //         table: "product_category_mapping",
        //         columns: new[] { "ProductId", "IsFeaturedProduct" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_Category_Mapping_IsFeaturedProduct",
        //         table: "product_category_mapping",
        //         column: "IsFeaturedProduct");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_4DE2FF87C02296F96D7DA49634AE6719C03E5E06",
        //         table: "product_manufacturer_mapping",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DABA4762DFE5DDE81827BC9AEBC96E0930755460",
        //         table: "product_manufacturer_mapping",
        //         column: "ManufacturerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PMM_Product_and_Manufacturer",
        //         table: "product_manufacturer_mapping",
        //         columns: new[] { "ManufacturerId", "ProductId" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PMM_ProductId_Extended",
        //         table: "product_manufacturer_mapping",
        //         columns: new[] { "ProductId", "IsFeaturedProduct" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_Manufacturer_Mapping_IsFeaturedProduct",
        //         table: "product_manufacturer_mapping",
        //         column: "IsFeaturedProduct");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_0A76F88D5B36EE11752798CC1AEC887B119395D8",
        //         table: "product_picture_mapping",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_1151378E30052BEAC16DB55D3E56D8D6A857FB02",
        //         table: "product_picture_mapping",
        //         column: "PictureId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_47FA8F827F33CA5D7C889B64078C36A49F6790A6",
        //         table: "product_productattribute_mapping",
        //         column: "ProductAttributeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_F6226437D41700C3BDEDDE266458E52BCE9E3715",
        //         table: "product_productattribute_mapping",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_Product_ProductAttribute_Mapping_ProductId_DisplayOrder",
        //         table: "product_productattribute_mapping",
        //         columns: new[] { "ProductId", "DisplayOrder" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_5A62FE7519887322703971B07D62C2648D56BDEB",
        //         table: "product_producttag_mapping",
        //         column: "ProductTag_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_5F850DC84A298A0021177DFFE6DA6AF5A8BA529D",
        //         table: "product_producttag_mapping",
        //         column: "Product_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_6E3598F36D97BFA8D2B1DA6A2D670FA36334106B",
        //         table: "product_specificationattribute_mapping",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_EE669865DEDFD7AEFB45F2F89EF1E442329254F3",
        //         table: "product_specificationattribute_mapping",
        //         column: "SpecificationAttributeOptionId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PSAM_AllowFiltering",
        //         table: "product_specificationattribute_mapping",
        //         column: "AllowFiltering");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PSAM_SpecificationAttributeOptionId_AllowFiltering",
        //         table: "product_specificationattribute_mapping",
        //         columns: new[] { "SpecificationAttributeOptionId", "AllowFiltering" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_10742F34F6C98BF11B11FBFB350254FBD0802277",
        //         table: "productattributecombination",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_C8FD7E41BDF864606B567EA54EAAB6219686F356",
        //         table: "productattributevalue",
        //         column: "ProductAttributeMappingId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_ProductAttributeValue_ProductAttributeMappingId_DisplayOrder",
        //         table: "productattributevalue",
        //         columns: new[] { "ProductAttributeMappingId", "DisplayOrder" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_ProductProducttagMappings_ProductId",
        //         table: "ProductProducttagMappings",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_34DF548025246734401C64D1904FDC5119A405CC",
        //         table: "productreview",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_C3A2EB2CAD92A0F3C47CCA524FD2848BC0026B81",
        //         table: "productreview",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_CCA2A4F066E9F5700F1C5792E4F4D96B78E887D6",
        //         table: "productreview",
        //         column: "StoreId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_A80FB7B7F056FCA6FF7011C07E1DF0DB21DD2723",
        //         table: "productreview_reviewtype_mapping",
        //         column: "ReviewTypeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_E6BD958D6D6A3B595249B1F2FB2836558198DBD6",
        //         table: "productreview_reviewtype_mapping",
        //         column: "ProductReviewId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_7528780A72E711ED59C639ABE6F5E79394EFC9C8",
        //         table: "productreviewhelpfulness",
        //         column: "ProductReviewId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_ProductTag_Name",
        //         table: "producttag",
        //         column: "Name");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_194D2A5B9EF87F154B5DD69A1834FAFCDD487B94",
        //         table: "productwarehouseinventory",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_D53A72DA5744EF523A405436021498998DDFABEA",
        //         table: "productwarehouseinventory",
        //         column: "WarehouseId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_EADE912948B576BF4259B7C4050DC339A54F63AE",
        //         table: "queuedemail",
        //         column: "EmailAccountId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QueuedEmail_CreatedOnUtc",
        //         table: "queuedemail",
        //         column: "CreatedOnUtc");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QueuedEmail_SentOnUtc_DontSendBeforeDateUtc_Extended",
        //         table: "queuedemail",
        //         columns: new[] { "SentOnUtc", "DontSendBeforeDateUtc" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_BE0E46A4D4C7979A25335958B1321179F95A9263",
        //         table: "recurringpayment",
        //         column: "InitialOrderId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_F15784D9E7C2AA49EAB3905620E308A649587B16",
        //         table: "recurringpaymenthistory",
        //         column: "RecurringPaymentId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_RelatedProduct_ProductId1",
        //         table: "relatedproduct",
        //         column: "ProductId1");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_6111E95274ADB34D717DB9F3FF6270CEC853028C",
        //         table: "returnrequest",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_60F9BB409B5074CAA77093426EBEF6A510194A0A",
        //         table: "rewardpointshistory",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_D7D61795361B29A6E41BFFB60A36B99CE2E77A50",
        //         table: "shipment",
        //         column: "OrderId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_80E4CFA78264430E212118ECB894E1B81E813243",
        //         table: "shipmentitem",
        //         column: "ShipmentId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_98FECBA712EC3A7AF759C110137BABE6423115BA",
        //         table: "shippingmethodrestrictions",
        //         column: "Country_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_A67E057E4259D823DFDB3A4FFFBDC22F9FF88570",
        //         table: "shippingmethodrestrictions",
        //         column: "ShippingMethod_Id");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_874149FC8129BC9A477567717104BF5951801611",
        //         table: "shoppingcartitem",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_F59371B91ADC899F64B183252FFDAD65F99A60B0",
        //         table: "shoppingcartitem",
        //         column: "CustomerId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_ShoppingCartItem_ShoppingCartTypeId_CustomerId",
        //         table: "shoppingcartitem",
        //         columns: new[] { "ShoppingCartTypeId", "CustomerId" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_A448A454CD518AB0B594506AF5062542BBA79170",
        //         table: "specificationattribute",
        //         column: "SpecificationAttributeGroupId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_20CA206E1041B61FFB1739DEAB2C2134475DBA4B",
        //         table: "specificationattributeoption",
        //         column: "SpecificationAttributeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_B5D25FF62BAA11CE55190C311232C49C9C3206C8",
        //         table: "stateprovince",
        //         column: "CountryId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_52918ED84971F1AC2192FABA83628A7DB4AE9BCD",
        //         table: "stockquantityhistory",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_FC249F594D98DD91961F5A358D8544703BE6E138",
        //         table: "storemapping",
        //         column: "StoreId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_StoreMapping_EntityId_EntityName",
        //         table: "storemapping",
        //         columns: new[] { "EntityId", "EntityName" });
        //
        migrationBuilder.CreateIndex(
            name: "IX_StoreMapping_EntityName",
            table: "storemapping",
            column: "EntityName");
        //
        
        migrationBuilder.CreateIndex(
            name: "IX_StoreMapping_EntityName_StoreId",
            table: "storemapping",
            columns: new[] { "EntityName", "StoreId" });
        
        
        //     migrationBuilder.CreateIndex(
        //         name: "IX_231B5005C419BF705692EE4AB5BBEF7EFFA20935",
        //         table: "tierprice",
        //         column: "ProductId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_D7FF9897F12FC9DE46D1D9AA52049475E05C6946",
        //         table: "tierprice",
        //         column: "CustomerRoleId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_UrlRecord_Custom_1",
        //         table: "urlrecord",
        //         columns: new[] { "EntityId", "EntityName", "LanguageId", "IsActive" });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_UrlRecord_Slug",
        //         table: "urlrecord",
        //         column: "Slug");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_C4D5E3F596710165FA89CD9C228D835174B8CB35",
        //         table: "vendorattributevalue",
        //         column: "VendorAttributeId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_5E01CCC29E29B4FBD22AD8195385ACD1130C2A47",
        //         table: "vendornote",
        //         column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //     migrationBuilder.DropTable(
        //         name: "aclrecord");
        //
        //     migrationBuilder.DropTable(
        //         name: "activitylog");
        //
        //     migrationBuilder.DropTable(
        //         name: "addressattributevalue");
        //
        //     migrationBuilder.DropTable(
        //         name: "affiliate");
        //
        //     migrationBuilder.DropTable(
        //         name: "backinstocksubscription");
        //
        //     migrationBuilder.DropTable(
        //         name: "blogcomment");
        //
        //     migrationBuilder.DropTable(
        //         name: "campaign");
        //
        //     migrationBuilder.DropTable(
        //         name: "categorytemplate");
        //
        //     migrationBuilder.DropTable(
        //         name: "checkoutattributevalue");
        //
        //     migrationBuilder.DropTable(
        //         name: "crosssellproduct");
        //
        //     migrationBuilder.DropTable(
        //         name: "currency");
        //
        //     migrationBuilder.DropTable(
        //         name: "customer_customerrole_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "customeraddresses");
        //
        //     migrationBuilder.DropTable(
        //         name: "customerattributevalue");
        //
        //     migrationBuilder.DropTable(
        //         name: "customerpassword");
        //
        //     migrationBuilder.DropTable(
        //         name: "deliverydate");
        //
        //     migrationBuilder.DropTable(
        //         name: "discount_appliedtocategories");
        //
        //     migrationBuilder.DropTable(
        //         name: "discount_appliedtomanufacturers");
        //
        //     migrationBuilder.DropTable(
        //         name: "discount_appliedtoproducts");
        //
        //     migrationBuilder.DropTable(
        //         name: "discountrequirement");
        //
        //     migrationBuilder.DropTable(
        //         name: "discountusagehistory");
        //
        //     migrationBuilder.DropTable(
        //         name: "download");
        //
        //     migrationBuilder.DropTable(
        //         name: "externalauthenticationrecord");
        //
        //     migrationBuilder.DropTable(
        //         name: "forums_postvote");
        //
        //     migrationBuilder.DropTable(
        //         name: "forums_subscription");
        //
        //     migrationBuilder.DropTable(
        //         name: "ForumsPrivatemessages");
        //
        //     migrationBuilder.DropTable(
        //         name: "gdprconsent");
        //
        //     migrationBuilder.DropTable(
        //         name: "gdprlog");
        //
        //     migrationBuilder.DropTable(
        //         name: "genericattribute");
        //
        //     migrationBuilder.DropTable(
        //         name: "giftcardusagehistory");
        //
        //     migrationBuilder.DropTable(
        //         name: "localestringresource");
        //
        //     migrationBuilder.DropTable(
        //         name: "localizedproperty");
        //
        //     migrationBuilder.DropTable(
        //         name: "log");
        //
        //     migrationBuilder.DropTable(
        //         name: "manufacturertemplate");
        //
        //     migrationBuilder.DropTable(
        //         name: "measuredimension");
        //
        //     migrationBuilder.DropTable(
        //         name: "measureweight");
        //
        //     migrationBuilder.DropTable(
        //         name: "messagetemplate");
        //
        //     migrationBuilder.DropTable(
        //         name: "migrationversioninfo");
        //
        //     migrationBuilder.DropTable(
        //         name: "newscomment");
        //
        //     migrationBuilder.DropTable(
        //         name: "newslettersubscription");
        //
        //     migrationBuilder.DropTable(
        //         name: "ordernote");
        //
        //     migrationBuilder.DropTable(
        //         name: "permissionrecord_role_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "picturebinary");
        //
        //     migrationBuilder.DropTable(
        //         name: "pollvotingrecord");
        //
        //     migrationBuilder.DropTable(
        //         name: "predefinedproductattributevalue");
        //
        //     migrationBuilder.DropTable(
        //         name: "product_category_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "product_manufacturer_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "product_picture_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "product_producttag_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "product_specificationattribute_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "productattributecombination");
        //
        //     migrationBuilder.DropTable(
        //         name: "productattributevalue");
        //
        //     migrationBuilder.DropTable(
        //         name: "productavailabilityrange");
        //
        //     migrationBuilder.DropTable(
        //         name: "ProductProducttagMappings");
        //
        //     migrationBuilder.DropTable(
        //         name: "productreview_reviewtype_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "productreviewhelpfulness");
        //
        //     migrationBuilder.DropTable(
        //         name: "producttemplate");
        //
        //     migrationBuilder.DropTable(
        //         name: "productwarehouseinventory");
        //
        //     migrationBuilder.DropTable(
        //         name: "queuedemail");
        //
        //     migrationBuilder.DropTable(
        //         name: "recurringpaymenthistory");
        //
        //     migrationBuilder.DropTable(
        //         name: "relatedproduct");
        //
        //     migrationBuilder.DropTable(
        //         name: "returnrequest");
        //
        //     migrationBuilder.DropTable(
        //         name: "returnrequestaction");
        //
        //     migrationBuilder.DropTable(
        //         name: "returnrequestreason");
        //
        //     migrationBuilder.DropTable(
        //         name: "scheduletask");
        //
        //     migrationBuilder.DropTable(
        //         name: "searchterm");
        //
        //     migrationBuilder.DropTable(
        //         name: "setting");
        //
        //     migrationBuilder.DropTable(
        //         name: "shipmentitem");
        //
        //     migrationBuilder.DropTable(
        //         name: "shippingmethodrestrictions");
        //
        //     migrationBuilder.DropTable(
        //         name: "shoppingcartitem");
        //
        //     migrationBuilder.DropTable(
        //         name: "stockquantityhistory");
        //
        //     migrationBuilder.DropTable(
        //         name: "storemapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "taxcategory");
        //
        //     migrationBuilder.DropTable(
        //         name: "tierprice");
        //
        //     migrationBuilder.DropTable(
        //         name: "topic");
        //
        //     migrationBuilder.DropTable(
        //         name: "topictemplate");
        //
        //     migrationBuilder.DropTable(
        //         name: "urlrecord");
        //
        //     migrationBuilder.DropTable(
        //         name: "vendorattributevalue");
        //
        //     migrationBuilder.DropTable(
        //         name: "vendornote");
        //
        //     migrationBuilder.DropTable(
        //         name: "activitylogtype");
        //
        //     migrationBuilder.DropTable(
        //         name: "addressattribute");
        //
        //     migrationBuilder.DropTable(
        //         name: "blogpost");
        //
        //     migrationBuilder.DropTable(
        //         name: "checkoutattribute");
        //
        //     migrationBuilder.DropTable(
        //         name: "customerattribute");
        //
        //     migrationBuilder.DropTable(
        //         name: "discount");
        //
        //     migrationBuilder.DropTable(
        //         name: "forums_post");
        //
        //     migrationBuilder.DropTable(
        //         name: "giftcard");
        //
        //     migrationBuilder.DropTable(
        //         name: "news");
        //
        //     migrationBuilder.DropTable(
        //         name: "permissionrecord");
        //
        //     migrationBuilder.DropTable(
        //         name: "pollanswer");
        //
        //     migrationBuilder.DropTable(
        //         name: "category");
        //
        //     migrationBuilder.DropTable(
        //         name: "manufacturer");
        //
        //     migrationBuilder.DropTable(
        //         name: "picture");
        //
        //     migrationBuilder.DropTable(
        //         name: "producttag");
        //
        //     migrationBuilder.DropTable(
        //         name: "specificationattributeoption");
        //
        //     migrationBuilder.DropTable(
        //         name: "product_productattribute_mapping");
        //
        //     migrationBuilder.DropTable(
        //         name: "reviewtype");
        //
        //     migrationBuilder.DropTable(
        //         name: "productreview");
        //
        //     migrationBuilder.DropTable(
        //         name: "warehouse");
        //
        //     migrationBuilder.DropTable(
        //         name: "emailaccount");
        //
        //     migrationBuilder.DropTable(
        //         name: "recurringpayment");
        //
        //     migrationBuilder.DropTable(
        //         name: "shipment");
        //
        //     migrationBuilder.DropTable(
        //         name: "shippingmethod");
        //
        //     migrationBuilder.DropTable(
        //         name: "customerrole");
        //
        //     migrationBuilder.DropTable(
        //         name: "vendorattribute");
        //
        //     migrationBuilder.DropTable(
        //         name: "vendor");
        //
        //     migrationBuilder.DropTable(
        //         name: "forums_topic");
        //
        //     migrationBuilder.DropTable(
        //         name: "orderitem");
        //
        //     migrationBuilder.DropTable(
        //         name: "poll");
        //
        //     migrationBuilder.DropTable(
        //         name: "specificationattribute");
        //
        //     migrationBuilder.DropTable(
        //         name: "productattribute");
        //
        //     migrationBuilder.DropTable(
        //         name: "store");
        //
        //     migrationBuilder.DropTable(
        //         name: "forums_forum");
        //
        //     migrationBuilder.DropTable(
        //         name: "order");
        //
        //     migrationBuilder.DropTable(
        //         name: "product");
        //
        //     migrationBuilder.DropTable(
        //         name: "language");
        //
        //     migrationBuilder.DropTable(
        //         name: "specificationattributegroup");
        //
        //     migrationBuilder.DropTable(
        //         name: "forums_group");
        //
        //     migrationBuilder.DropTable(
        //         name: "address");
        //
        //     migrationBuilder.DropTable(
        //         name: "rewardpointshistory");
        //
        //     migrationBuilder.DropTable(
        //         name: "stateprovince");
        //
        //     migrationBuilder.DropTable(
        //         name: "customer");
        //
        //     migrationBuilder.DropTable(
        //         name: "country");
        }
    }
}
