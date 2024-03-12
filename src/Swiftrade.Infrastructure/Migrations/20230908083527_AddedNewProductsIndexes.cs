using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swiftrade.Infrastructure.Migrations
{
    public partial class AddedNewProductsIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_DisplayOrder",
                table: "product",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                table: "product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id_DisplayOrder",
                table: "product",
                columns: new[] { "Id", "DisplayOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Published_Deleted_MarkAsNew",
                table: "product",
                columns: new[] { "Published", "Deleted", "MarkAsNew" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_DisplayOrder",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_Id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_Id_DisplayOrder",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_Published_Deleted_MarkAsNew",
                table: "product");
        }
    }
}
