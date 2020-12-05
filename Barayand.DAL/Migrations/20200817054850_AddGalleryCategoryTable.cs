using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddGalleryCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GalleryCategory",
                columns: table => new
                {
                    GC_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    GC_Titles = table.Column<string>(nullable: true),
                    GC_SortField = table.Column<int>(nullable: false),
                    GC_Seo = table.Column<string>(nullable: true),
                    GC_Icon = table.Column<string>(nullable: true),
                    GC_Description = table.Column<string>(nullable: true),
                    GC_Status = table.Column<bool>(nullable: false),
                    GC_IsDeleted = table.Column<bool>(nullable: false),
                    GC_Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryCategory", x => x.GC_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryCategory");
        }
    }
}
