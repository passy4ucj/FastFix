using Microsoft.EntityFrameworkCore.Migrations;

namespace FastFixApi.Migrations
{
    public partial class DatabaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSubCategories_ServiceCategories_ServiceCategoryId",
                table: "ServiceSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_ServiceSubCategories_ServiceCategoryId",
                table: "ServiceSubCategories");

            migrationBuilder.DropColumn(
                name: "ServiceCategoryId",
                table: "ServiceSubCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ServiceSubCategories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "ServiceCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSubCategories_CategoryId",
                table: "ServiceSubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSubCategories_ServiceCategories_CategoryId",
                table: "ServiceSubCategories",
                column: "CategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSubCategories_ServiceCategories_CategoryId",
                table: "ServiceSubCategories");

            migrationBuilder.DropIndex(
                name: "IX_ServiceSubCategories_CategoryId",
                table: "ServiceSubCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ServiceSubCategories");

            migrationBuilder.AddColumn<int>(
                name: "ServiceCategoryId",
                table: "ServiceSubCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "ServiceCategories",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSubCategories_ServiceCategoryId",
                table: "ServiceSubCategories",
                column: "ServiceCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSubCategories_ServiceCategories_ServiceCategoryId",
                table: "ServiceSubCategories",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
