using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddExpertReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpertReview",
                columns: table => new
                {
                    E_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    E_ProductId = table.Column<int>(nullable: false),
                    E_Title = table.Column<string>(nullable: true),
                    E_Description = table.Column<string>(nullable: true),
                    E_Sort = table.Column<int>(nullable: false),
                    E_Image = table.Column<string>(nullable: true),
                    E_Status = table.Column<bool>(nullable: false),
                    E_IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertReview", x => x.E_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpertReview");
        }
    }
}
