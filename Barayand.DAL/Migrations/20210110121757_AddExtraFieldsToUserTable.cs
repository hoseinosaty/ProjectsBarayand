using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddExtraFieldsToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "U_BirthDate",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_CreditCardNum",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_HomeTel",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_IdentityCode",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "U_BirthDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_CreditCardNum",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_HomeTel",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_IdentityCode",
                table: "Users");
        }
    }
}
