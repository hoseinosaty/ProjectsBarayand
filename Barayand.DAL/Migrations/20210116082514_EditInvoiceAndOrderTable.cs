using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class EditInvoiceAndOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "O_ColorId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "O_GiftId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "O_ProductManuualId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "O_WarrantyId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "I_BoxWrapperId",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "O_ColorId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "O_GiftId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "O_ProductManuualId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "O_WarrantyId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "I_BoxWrapperId",
                table: "Invoice");
        }
    }
}
