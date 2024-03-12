using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swiftrade.Infrastructure.Migrations
{
    public partial class Addsomeindexestoimprovefetchingcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Category_Id_DisplayOrder_ParentCategoryId",
                table: "category",
                columns: new[] { "Id", "DisplayOrder", "ParentCategoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id_Published_Deleted",
                table: "category",
                columns: new[] { "Id", "Published", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Published_Deleted",
                table: "category",
                columns: new[] { "Published", "Deleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Published_Deleted_LimitedToStores_ParentCategoryId_DisplayOrder_Id",
                table: "category",
                columns: new[] { "Published", "Deleted", "LimitedToStores", "ParentCategoryId", "DisplayOrder", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Category_Id_DisplayOrder_ParentCategoryId",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_Category_Id_Published_Deleted",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_Category_Published_Deleted",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_Category_Published_Deleted_LimitedToStores_ParentCategoryId_DisplayOrder_Id",
                table: "category");
        }
    }
}
