using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddTypeFieldToCopponTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CP_UsageCount",
                table: "Coppon");

            migrationBuilder.AddColumn<int>(
                name: "CP_Type",
                table: "Coppon",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CP_Type",
                table: "Coppon");

            migrationBuilder.AddColumn<int>(
                name: "CP_UsageCount",
                table: "Coppon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
