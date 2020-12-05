using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddNoticesCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoticesCategory",
                columns: table => new
                {
                    NC_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    NC_Type = table.Column<int>(nullable: false),
                    NC_Title = table.Column<string>(maxLength: 500, nullable: false),
                    NC_SortField = table.Column<int>(nullable: false),
                    NC_Seo = table.Column<string>(nullable: true),
                    NC_SeoUrl = table.Column<string>(maxLength: 1500, nullable: true),
                    NC_Status = table.Column<bool>(nullable: false),
                    NC_IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoticesCategory", x => x.NC_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoticesCategory");
        }
    }
}
