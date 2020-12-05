using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AttributeAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeAnswer",
                columns: table => new
                {
                    X_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    X_CatAttrId = table.Column<int>(nullable: false),
                    X_Answer = table.Column<string>(nullable: true),
                    X_Status = table.Column<bool>(nullable: false),
                    X_IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeAnswer", x => x.X_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeAnswer");
        }
    }
}
