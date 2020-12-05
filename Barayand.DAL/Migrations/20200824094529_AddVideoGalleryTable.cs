using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddVideoGalleryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoGallery",
                columns: table => new
                {
                    VG_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    VG_CatId = table.Column<int>(nullable: false),
                    VG_Title = table.Column<string>(maxLength: 500, nullable: false),
                    VG_Status = table.Column<bool>(nullable: false),
                    VG_SortField = table.Column<int>(nullable: false),
                    VG_UrlType = table.Column<int>(nullable: false),
                    VG_VideoUrl = table.Column<string>(maxLength: 4000, nullable: true),
                    VG_VideoImage = table.Column<string>(maxLength: 4000, nullable: true),
                    VG_Keywords = table.Column<string>(maxLength: 1000, nullable: true),
                    VG_Seo = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGallery", x => x.VG_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGallery");
        }
    }
}
