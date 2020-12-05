using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class UpdateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "U_Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Post",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "verify_code",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "U_Role",
                table: "Users",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "U_Role",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "U_Gender",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "U_Post",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "U_Username",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "verify_code",
                table: "Users",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);
        }
    }
}
