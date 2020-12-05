using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class Uuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_Avatar",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_Email",
                table: "Users",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_Family",
                table: "Users",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "U_Gender",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "U_Name",
                table: "Users",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "U_Phone",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "U_Post",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "U_Status",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "U_Username",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "verify_code",
                table: "Users",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "U_Avatar",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Family",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Post",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "U_Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "verify_code",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Users",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Users",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
