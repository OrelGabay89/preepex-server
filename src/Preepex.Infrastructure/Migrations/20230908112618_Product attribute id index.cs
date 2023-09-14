using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Preepex.Infrastructure.Migrations
{
    public partial class Productattributeidindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_Id",
                table: "productattribute",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductAttribute_Id",
                table: "productattribute");
        }
    }
}
