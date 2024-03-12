using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swiftrade.Infrastructure.Migrations
{
    public partial class Addedindexestofetchnewproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_Deleted",
                table: "product",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LimitedToStores",
                table: "product",
                column: "LimitedToStores");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LimitedToStores_Id",
                table: "product",
                columns: new[] { "LimitedToStores", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarkAsNew",
                table: "product",
                column: "MarkAsNew");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Deleted",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_LimitedToStores",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_LimitedToStores_Id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarkAsNew",
                table: "product");
        }
    }
}
