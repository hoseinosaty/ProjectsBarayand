using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    C_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    C_ParentId = table.Column<int>(nullable: false,defaultValue:0),
                    C_UserName = table.Column<string>(nullable: true),
                    C_UserEmail = table.Column<string>(nullable: true),
                    C_Rate = table.Column<int>(nullable: false, defaultValue: 0),
                    C_Type = table.Column<int>(nullable: false, defaultValue: 1),
                    C_EntityId = table.Column<int>(nullable: false, defaultValue: 0),
                    C_Status = table.Column<int>(nullable: false, defaultValue: 1),
                    C_Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.C_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}
