using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class UpdateBrandTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B_LogoUrl",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "B_SeoSetting",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "B_Sort",
                table: "Brands");

            migrationBuilder.AddColumn<bool>(
                name: "B_IsDeleted",
                table: "Brands",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "B_Logo",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "B_Seo",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "B_SortField",
                table: "Brands",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B_IsDeleted",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "B_Logo",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "B_Seo",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "B_SortField",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "B_LogoUrl",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "B_SeoSetting",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "B_Sort",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
