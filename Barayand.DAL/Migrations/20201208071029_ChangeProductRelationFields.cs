using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class ChangeProductRelationFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedProduct",
                table: "RelatedProduct");

            migrationBuilder.DropColumn(
                name: "PR_Id",
                table: "RelatedProduct");

            migrationBuilder.DropColumn(
                name: "PR_PId",
                table: "RelatedProduct");

            migrationBuilder.DropColumn(
                name: "PR_RId",
                table: "RelatedProduct");

            migrationBuilder.AddColumn<int>(
                name: "X_Id",
                table: "RelatedProduct",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "X_ColorId",
                table: "RelatedProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X_MainProdId",
                table: "RelatedProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X_ProdId",
                table: "RelatedProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "X_WarrantyId",
                table: "RelatedProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedProduct",
                table: "RelatedProduct",
                column: "X_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedProduct",
                table: "RelatedProduct");

            migrationBuilder.DropColumn(
                name: "X_Id",
                table: "RelatedProduct");

            migrationBuilder.DropColumn(
                name: "X_ColorId",
                table: "RelatedProduct");

            migrationBuilder.DropColumn(
                name: "X_MainProdId",
                table: "RelatedProduct");

            migrationBuilder.DropColumn(
                name: "X_ProdId",
                table: "RelatedProduct");

            migrationBuilder.DropColumn(
                name: "X_WarrantyId",
                table: "RelatedProduct");

            migrationBuilder.AddColumn<int>(
                name: "PR_Id",
                table: "RelatedProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PR_PId",
                table: "RelatedProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PR_RId",
                table: "RelatedProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedProduct",
                table: "RelatedProduct",
                column: "PR_Id");
        }
    }
}
