using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddFormulaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "P_BinPrice",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "P_DiscountPeriodTime",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "P_DownloadLink",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "P_ExternalPrice",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "P_GiftBin",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "P_Isbn",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "P_PageCount",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "P_PeriodDiscountPrice",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "P_PriceFormulaId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "P_PriceType",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "P_PrintAblePrice",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "P_PrintAbleVerPrice",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "P_PrintAbleVersion",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "P_PriodDiscountFormulaId",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "P_Weight",
                table: "Product",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Formula",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    F_Title = table.Column<string>(nullable: true),
                    F_Formula = table.Column<string>(nullable: true),
                    F_Status = table.Column<bool>(nullable: false,defaultValue:true),
                    F_IsDeleted = table.Column<bool>(nullable: false,defaultValue:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula", x => x.F_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formula");

            migrationBuilder.DropColumn(
                name: "P_BinPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_DiscountPeriodTime",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_DownloadLink",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_ExternalPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_GiftBin",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_Isbn",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PageCount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PeriodDiscountPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PriceFormulaId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PriceType",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PrintAblePrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PrintAbleVerPrice",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PrintAbleVersion",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_PriodDiscountFormulaId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "P_Weight",
                table: "Product");
        }
    }
}
