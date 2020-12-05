using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddDeletedFieldToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PC_IsDeleted",
                table: "ProductCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Brands",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted_At",
                table: "Authentication",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "PC_IsDeleted",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Deleted_At",
                table: "Authentication");
        }
    }
}
