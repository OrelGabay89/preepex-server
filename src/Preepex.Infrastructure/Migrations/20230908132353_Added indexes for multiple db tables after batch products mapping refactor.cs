using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Preepex.Infrastructure.Migrations
{
    public partial class Addedindexesformultipledbtablesafterbatchproductsmappingrefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_0A76F88D5B36EE11752798CC1AEC887B119395D8",
                table: "product_picture_mapping");

            migrationBuilder.DropIndex(
                name: "IX_1151378E30052BEAC16DB55D3E56D8D6A857FB02",
                table: "product_picture_mapping");

            migrationBuilder.RenameIndex(
                name: "IX_UrlRecord_Custom_1",
                table: "urlrecord",
                newName: "IX_UrlRecord_EntityId_EntityName_LanguageId_IsActive");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Picture_Mapping_PictureId",
                table: "product_picture_mapping",
                newName: "IX_product_picture_mapping_PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_UrlRecord_EntityId_EntityName_LanguageId_IsActive_Id",
                table: "urlrecord",
                columns: new[] { "EntityId", "EntityName", "LanguageId", "IsActive", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Picture_Mapping_ProductId_PictureId",
                table: "product_picture_mapping",
                columns: new[] { "ProductId", "PictureId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Published_Deleted_MarkAsNew_LimitedToStores_Id",
                table: "product",
                columns: new[] { "Published", "Deleted", "MarkAsNew", "LimitedToStores", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Language_Published_DisplayOrder_Id",
                table: "language",
                columns: new[] { "Published", "DisplayOrder", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_Published_DisplayOrder_Id",
                table: "currency",
                columns: new[] { "Published", "DisplayOrder", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Published_Deleted_ShowOnHomepage_DisplayOrder_Id",
                table: "category",
                columns: new[] { "Published", "Deleted", "ShowOnHomepage", "DisplayOrder", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlRecord_EntityId_EntityName_LanguageId_IsActive_Id",
                table: "urlrecord");

            migrationBuilder.DropIndex(
                name: "IX_Product_Picture_Mapping_ProductId_PictureId",
                table: "product_picture_mapping");

            migrationBuilder.DropIndex(
                name: "IX_Products_Published_Deleted_MarkAsNew_LimitedToStores_Id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_Language_Published_DisplayOrder_Id",
                table: "language");

            migrationBuilder.DropIndex(
                name: "IX_Currency_Published_DisplayOrder_Id",
                table: "currency");

            migrationBuilder.DropIndex(
                name: "IX_Category_Published_Deleted_ShowOnHomepage_DisplayOrder_Id",
                table: "category");

            migrationBuilder.RenameIndex(
                name: "IX_UrlRecord_EntityId_EntityName_LanguageId_IsActive",
                table: "urlrecord",
                newName: "IX_UrlRecord_Custom_1");

            migrationBuilder.RenameIndex(
                name: "IX_product_picture_mapping_PictureId",
                table: "product_picture_mapping",
                newName: "IX_Product_Picture_Mapping_PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_0A76F88D5B36EE11752798CC1AEC887B119395D8",
                table: "product_picture_mapping",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_1151378E30052BEAC16DB55D3E56D8D6A857FB02",
                table: "product_picture_mapping",
                column: "PictureId");
        }
    }
}
