using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class UpdateAttributeTable_AddFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "A_IsDeleted",
                table: "Attribute",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "A_Status",
                table: "Attribute",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "A_IsDeleted",
                table: "Attribute");

            migrationBuilder.DropColumn(
                name: "A_Status",
                table: "Attribute");
        }
    }
}
