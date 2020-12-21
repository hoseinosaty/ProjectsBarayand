using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddProductManualTavle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductManual",
                columns: table => new
                {
                    M_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    M_Title = table.Column<string>(nullable: true),
                    M_FileName = table.Column<string>(nullable: true),
                    M_Status = table.Column<bool>(nullable: false,defaultValue:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManual", x => x.M_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductManual");
        }
    }
}
