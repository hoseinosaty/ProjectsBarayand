using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class EditInvoiceTableForGbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "I_DeliverDateTime",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "I_ProductType",
                table: "Invoice");

            migrationBuilder.AddColumn<string>(
                name: "I_Reason",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "I_TotalProductAmount",
                table: "Invoice",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "I_Reason",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "I_TotalProductAmount",
                table: "Invoice");

            migrationBuilder.AddColumn<string>(
                name: "I_DeliverDateTime",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "I_ProductType",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
