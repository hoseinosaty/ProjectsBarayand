using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddFlagsCategoryAttributeRelationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "X_IsDeleted",
                table: "CategoryAttribute",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "X_Status",
                table: "CategoryAttribute",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "X_IsDeleted",
                table: "CategoryAttribute");

            migrationBuilder.DropColumn(
                name: "X_Status",
                table: "CategoryAttribute");
        }
    }
}
