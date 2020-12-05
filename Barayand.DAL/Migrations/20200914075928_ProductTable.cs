using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class ProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    P_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    P_MainCatId = table.Column<int>(nullable: false),
                    P_EndLevelCatId = table.Column<int>(nullable: false),
                    P_BrandId = table.Column<int>(nullable: false),
                    P_LabelId = table.Column<int>(nullable: false),
                    P_Title = table.Column<string>(nullable: true),
                    P_ListTitle = table.Column<string>(nullable: true),
                    P_DetailsTitle = table.Column<string>(nullable: true),
                    P_DetailsSubTitle = table.Column<string>(nullable: true),
                    P_Image = table.Column<string>(nullable: true),
                    P_Status = table.Column<bool>(nullable: false),
                    P_Seo = table.Column<string>(nullable: true),
                    P_ImgGallery = table.Column<string>(maxLength: 2500, nullable: true),
                    P_Description = table.Column<string>(maxLength: 5000, nullable: true),
                    P_TechnicalInfo = table.Column<string>(maxLength: 5000, nullable: true),
                    P_Price = table.Column<double>(nullable: false),
                    P_Discount = table.Column<double>(nullable: false),
                    P_DiscountType = table.Column<int>(nullable: false),
                    P_AvailableCount = table.Column<int>(nullable: false),
                    P_SaleCount = table.Column<int>(nullable: false),
                    P_IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.P_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
