using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddExtraFieldsToNewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "N_BannerImage",
                table: "Notices",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "N_IsSlideShow",
                table: "Notices",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "N_BannerImage",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "N_IsSlideShow",
                table: "Notices");
        }
    }
}
