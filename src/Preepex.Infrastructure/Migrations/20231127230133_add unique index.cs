using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Preepex.Infrastructure.Migrations
{
    public partial class adduniqueindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UrlRecord_EntityId_EntityName_LanguageId",
                table: "urlrecord",
                columns: new[] { "EntityId", "EntityName", "LanguageId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlRecord_EntityId_EntityName_LanguageId",
                table: "urlrecord");
        }
    }
}
