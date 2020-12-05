using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddLangToGalleryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "VideoGallery",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "ImageGallery",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lang",
                table: "VideoGallery");

            migrationBuilder.DropColumn(
                name: "Lang",
                table: "ImageGallery");
        }
    }
}
