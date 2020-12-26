using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddSectionIdToPromotionBoxProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "X_MainProdId",
                table: "PromotionBoxProducts");

            migrationBuilder.AddColumn<int>(
                name: "X_SectionId",
                table: "PromotionBoxProducts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "X_SectionId",
                table: "PromotionBoxProducts");

            migrationBuilder.AddColumn<int>(
                name: "X_MainProdId",
                table: "PromotionBoxProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
