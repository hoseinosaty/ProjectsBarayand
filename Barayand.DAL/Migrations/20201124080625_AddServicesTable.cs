using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddServicesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    S_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    S_Title = table.Column<string>(nullable: true),
                    S_Image = table.Column<string>(nullable: true),
                    S_Sort = table.Column<int>(nullable: false),
                    S_Status = table.Column<bool>(nullable: false),
                    S_Seo = table.Column<string>(nullable: true),
                    S_Content = table.Column<string>(nullable: true),
                    S_Icon = table.Column<string>(nullable: true),
                    S_ImageGallery = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.S_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
