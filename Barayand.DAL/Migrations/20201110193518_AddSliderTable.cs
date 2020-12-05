using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddSliderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    S_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    S_Titles = table.Column<string>(maxLength: 1000, nullable: false),
                    S_OrderField = table.Column<int>(nullable: false,defaultValue:1),
                    S_Link = table.Column<string>(maxLength: 500, nullable: true),
                    S_AltTag = table.Column<string>(maxLength: 500, nullable: true),
                    S_TooltipTitle = table.Column<string>(maxLength: 500, nullable: true),
                    S_DesktopFileLink = table.Column<string>(maxLength: 500, nullable: true),
                    S_MobileFileLink = table.Column<string>(maxLength: 500, nullable: true),
                    S_Status = table.Column<bool>(nullable: false),
                    S_ShowAnimation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.S_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");
        }
    }
}
