using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swiftrade.Infrastructure.Migrations
{
    public partial class AddedindexestoSettingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Setting_Id",
                table: "setting",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Setting_Name",
                table: "setting",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Setting_Id",
                table: "setting");

            migrationBuilder.DropIndex(
                name: "IX_Setting_Name",
                table: "setting");
        }
    }
}
