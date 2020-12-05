using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddSomeFieldToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_PrintAblePrice",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "P_Author",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "P_PeriodDiscountPriceType",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "P_PrintAbleVerFormulaId",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "P_PrintAbleVerPriceType",
                table: "Product",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_Author",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PeriodDiscountPriceType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PrintAbleVerFormulaId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PrintAbleVerPriceType",
                table: "Product");

            migrationBuilder.AddColumn<decimal>(
                name: "P_PrintAblePrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
