using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swiftrade.Infrastructure.Migrations
{
    public partial class AddStoreIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Store_Hosts",
                table: "store",
                column: "Hosts");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Id",
                table: "store",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Store_Hosts",
                table: "store");

            migrationBuilder.DropIndex(
                name: "IX_Store_Id",
                table: "store");
        }
    }
}
