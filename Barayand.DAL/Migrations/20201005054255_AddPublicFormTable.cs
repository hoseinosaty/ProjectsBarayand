using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddPublicFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicForms",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    F_Type = table.Column<int>(nullable: false,defaultValue:1),
                    F_MsgType = table.Column<int>(nullable: false, defaultValue: 1),
                    F_User = table.Column<string>(maxLength: 500, nullable: true),
                    F_UserPhone = table.Column<string>(maxLength: 500, nullable: true),
                    F_UserEmail = table.Column<string>(maxLength: 500, nullable: true),
                    F_Msg = table.Column<string>(maxLength: 4000, nullable: true),
                    F_Status = table.Column<bool>(nullable: false, defaultValue: false),
                    F_Response = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicForms", x => x.F_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicForms");
        }
    }
}
