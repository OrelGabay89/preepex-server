using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Preepex.Infrastructure.Migrations
{
    public partial class Addedurlrecordindexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UrlRecord_IsActive_Id",
                table: "urlrecord",
                columns: new[] { "IsActive", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_UrlRecord_LanguageId",
                table: "urlrecord",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlRecord_IsActive_Id",
                table: "urlrecord");

            migrationBuilder.DropIndex(
                name: "IX_UrlRecord_LanguageId",
                table: "urlrecord");
        }
    }
}
