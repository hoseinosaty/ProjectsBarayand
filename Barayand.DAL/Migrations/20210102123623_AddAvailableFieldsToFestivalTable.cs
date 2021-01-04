using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddAvailableFieldsToFestivalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "F_IsDeleted",
                table: "FestivalOffer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "F_Status",
                table: "FestivalOffer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F_IsDeleted",
                table: "FestivalOffer");

            migrationBuilder.DropColumn(
                name: "F_Status",
                table: "FestivalOffer");
        }
    }
}
