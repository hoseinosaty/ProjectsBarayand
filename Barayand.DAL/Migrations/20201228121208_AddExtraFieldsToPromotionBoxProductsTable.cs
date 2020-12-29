using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddExtraFieldsToPromotionBoxProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "X_EndDate",
                table: "PromotionBoxProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "X_ShowInIndex",
                table: "PromotionBoxProducts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "X_StartDate",
                table: "PromotionBoxProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "X_Status",
                table: "PromotionBoxProducts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "X_EndDate",
                table: "PromotionBoxProducts");

            migrationBuilder.DropColumn(
                name: "X_ShowInIndex",
                table: "PromotionBoxProducts");

            migrationBuilder.DropColumn(
                name: "X_StartDate",
                table: "PromotionBoxProducts");

            migrationBuilder.DropColumn(
                name: "X_Status",
                table: "PromotionBoxProducts");
        }
    }
}
