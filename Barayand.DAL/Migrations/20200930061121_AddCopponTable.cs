using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddCopponTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coppon",
                columns: table => new
                {
                    CP_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    CP_Title = table.Column<string>(nullable: true),
                    CP_Code = table.Column<string>(nullable: true),
                    CP_StartDate = table.Column<DateTime>(nullable: false),
                    CP_EndDate = table.Column<DateTime>(nullable: false),
                    CP_Discount = table.Column<decimal>(nullable: false,defaultValue:0),
                    CP_UsageCount = table.Column<int>(nullable: false, defaultValue: 0),
                    CP_Status = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coppon", x => x.CP_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coppon");
        }
    }
}
