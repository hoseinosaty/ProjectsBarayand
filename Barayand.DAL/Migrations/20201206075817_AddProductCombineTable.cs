using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddProductCombineTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCombine",
                columns: table => new
                {
                    X_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    X_ProductId = table.Column<int>(nullable: false),
                    X_WarrantyId = table.Column<int>(nullable: false),
                    X_ColorId = table.Column<int>(nullable: false),
                    X_Price = table.Column<decimal>(nullable: false, defaultValue: 0),
                    X_Discount = table.Column<decimal>(nullable: false, defaultValue: 0),
                    X_DiscountType = table.Column<int>(nullable:false, defaultValue:1),
                    X_Default = table.Column<bool>(nullable: false, defaultValue: false),
                    X_Status = table.Column<bool>(nullable: false,defaultValue:true),
                    X_IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCombine", x => x.X_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCombine");
        }
    }
}
