using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class OfflieRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfflineRequest",
                columns: table => new
                {
                    O_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    O_User = table.Column<int>(nullable: false),
                    O_Url = table.Column<string>(nullable: true),
                    O_Details = table.Column<string>(nullable: true),
                    O_Status = table.Column<int>(nullable: false,defaultValue:1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfflineRequest", x => x.O_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfflineRequest");
        }
    }
}
