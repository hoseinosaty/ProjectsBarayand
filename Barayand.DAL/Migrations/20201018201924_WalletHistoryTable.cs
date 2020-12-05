using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class WalletHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WalletHistory",
                columns: table => new
                {
                    WH_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    WH_CustomerId = table.Column<int>(nullable: false),
                    WH_AdderId = table.Column<int>(nullable: false,defaultValue:0),
                    WH_TransactionType = table.Column<int>(nullable: false,defaultValue:1),
                    WH_Amount = table.Column<decimal>(nullable: false,defaultValue:0),
                    WH_PayType = table.Column<int>(nullable: false,defaultValue:1),
                    WH_PayBankRecipFile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletHistory", x => x.WH_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalletHistory");
        }
    }
}
