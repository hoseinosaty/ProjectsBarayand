using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class ProductAttributeAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductAttributeAnswer",
                columns: table => new
                {
                    X_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X_PId = table.Column<int>(nullable: false),
                    X_AId = table.Column<int>(nullable: false),
                    X_AnswerId = table.Column<int>(nullable: false),
                    X_AnswerTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeAnswer", x => x.X_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAttributeAnswer");
        }
    }
}
