using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddBetterPriceRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BetterPriceRequest",
                columns: table => new
                {
                    B_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    B_ProductId = table.Column<int>(nullable: false),
                    B_Price = table.Column<string>(nullable: true),
                    B_StoreWebAddress = table.Column<string>(nullable: true),
                    B_StoreName = table.Column<string>(nullable: true),
                    B_StoreOwnCity = table.Column<string>(nullable: true),
                    B_StoreType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetterPriceRequest", x => x.B_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BetterPriceRequest");
        }
    }
}
