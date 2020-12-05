using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddSessionIdWalletHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WH_PayBankRecipFile",
                table: "WalletHistory");

            migrationBuilder.AddColumn<string>(
                name: "WH_PayBankRecip",
                table: "WalletHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WH_SessionId",
                table: "WalletHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WH_PayBankRecip",
                table: "WalletHistory");

            migrationBuilder.DropColumn(
                name: "WH_SessionId",
                table: "WalletHistory");

            migrationBuilder.AddColumn<string>(
                name: "WH_PayBankRecipFile",
                table: "WalletHistory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
