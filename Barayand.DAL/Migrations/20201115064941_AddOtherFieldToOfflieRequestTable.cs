using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddOtherFieldToOfflieRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "O_DeliverDate",
                table: "OfflineRequest",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "O_Price",
                table: "OfflineRequest",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "O_DeliverDate",
                table: "OfflineRequest");

            migrationBuilder.DropColumn(
                name: "O_Price",
                table: "OfflineRequest");
        }
    }
}
