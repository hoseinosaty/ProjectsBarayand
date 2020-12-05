using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class EditOrderTableForGbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "O_Version",
                table: "Order",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lang",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "O_Version",
                table: "Order");
        }
    }
}
