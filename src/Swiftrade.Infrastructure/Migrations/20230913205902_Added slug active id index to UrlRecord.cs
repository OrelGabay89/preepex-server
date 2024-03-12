using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swiftrade.Infrastructure.Migrations
{
    public partial class AddedslugactiveidindextoUrlRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UrlRecord_Slug_IsActive_Id",
                table: "urlrecord",
                columns: new[] { "Slug", "IsActive", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlRecord_Slug_IsActive_Id",
                table: "urlrecord");
        }
    }
}
