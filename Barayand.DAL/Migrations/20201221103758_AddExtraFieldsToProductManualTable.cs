using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddExtraFieldsToProductManualTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "M_Price",
                table: "ProductManual",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "M_ProductId",
                table: "ProductManual",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "M_Price",
                table: "ProductManual");

            migrationBuilder.DropColumn(
                name: "M_ProductId",
                table: "ProductManual");
        }
    }
}
