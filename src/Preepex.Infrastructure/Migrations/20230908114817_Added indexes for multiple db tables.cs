using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Preepex.Infrastructure.Migrations
{
    public partial class Addedindexesformultipledbtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_Picture_Mapping_ProductId_DisplayOrder_Id",
                table: "product_picture_mapping",
                columns: new[] { "ProductId", "DisplayOrder", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Language_Published",
                table: "language",
                column: "Published");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_DisplayOrder_Id",
                table: "currency",
                columns: new[] { "DisplayOrder", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_Published",
                table: "currency",
                column: "Published");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_Picture_Mapping_ProductId_DisplayOrder_Id",
                table: "product_picture_mapping");

            migrationBuilder.DropIndex(
                name: "IX_Language_Published",
                table: "language");

            migrationBuilder.DropIndex(
                name: "IX_Currency_DisplayOrder_Id",
                table: "currency");

            migrationBuilder.DropIndex(
                name: "IX_Currency_Published",
                table: "currency");
        }
    }
}
