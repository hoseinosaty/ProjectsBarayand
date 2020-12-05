using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddAdditionalFieldToProdCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PC_Description",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PC_ImgTitle",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PC_PrefixCode",
                table: "ProductCategory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PC_Description",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "PC_ImgTitle",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "PC_PrefixCode",
                table: "ProductCategory");
        }
    }
}
