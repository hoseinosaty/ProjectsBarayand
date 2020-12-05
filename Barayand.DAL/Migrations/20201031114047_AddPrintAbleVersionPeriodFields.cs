using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddPrintAbleVersionPeriodFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "P_PeriodPrintableFomrulaId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "P_PeriodPrintablePrice",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "P_PeriodPrintablePriceType",
                table: "Product",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_PeriodPrintableFomrulaId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PeriodPrintablePrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PeriodPrintablePriceType",
                table: "Product");
        }
    }
}
