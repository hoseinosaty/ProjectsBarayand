using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddPromotionBoxModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromotionBoxs",
                columns: table => new
                {
                    B_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    B_Title = table.Column<int>(nullable: false),
                    B_Image = table.Column<string>(nullable: true),
                    B_Seo = table.Column<string>(nullable: true),
                    B_Link = table.Column<string>(nullable: true),
                    B_LoadType = table.Column<int>(nullable: false),
                    B_Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionBoxs", x => x.B_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionBoxs");
        }
    }
}
