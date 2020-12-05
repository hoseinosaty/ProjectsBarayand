using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class UpdateProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "P_ListTitle",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ManualRate",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "P_CompanyWarranty",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "P_EnergyId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "P_ImmediateSend",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "P_MCuntryId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "P_Manuals",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManualRate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_CompanyWarranty",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_EnergyId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_ImmediateSend",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_MCuntryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_Manuals",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "P_ListTitle",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
