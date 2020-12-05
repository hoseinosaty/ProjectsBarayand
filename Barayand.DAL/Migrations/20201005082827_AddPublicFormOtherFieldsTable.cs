using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddPublicFormOtherFieldsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "F_MsgSubTopic",
                table: "PublicForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "F_MsgTopic",
                table: "PublicForms",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "F_MsgSubTopic",
                table: "PublicForms");

            migrationBuilder.DropColumn(
                name: "F_MsgTopic",
                table: "PublicForms");
        }
    }
}
