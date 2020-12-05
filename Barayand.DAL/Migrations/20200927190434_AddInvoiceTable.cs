using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddInvoiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    I_Id = table.Column<string>(nullable: true),
                    I_UserId = table.Column<int>(nullable: false, defaultValue: 0),
                    I_PaymentType = table.Column<int>(nullable: false,defaultValue:0),
                    I_RecipientInfo = table.Column<string>(nullable: true),
                    I_CopponId = table.Column<int>(nullable: false, defaultValue: 0),
                    I_CopponDiscount = table.Column<decimal>(nullable: false, defaultValue: 0),
                    I_ShippingCost = table.Column<decimal>(nullable: false, defaultValue: 0),
                    I_ShippingMethod = table.Column<int>(nullable: false, defaultValue: 0),
                    I_PaymentInfo = table.Column<string>(nullable: true),
                    I_PaymentDate = table.Column<DateTime>(nullable: false),
                    I_TotalAmount = table.Column<decimal>(nullable: false, defaultValue: 0),
                    I_DeliveryDate = table.Column<string>(nullable: true),
                    I_Status = table.Column<int>(nullable: false, defaultValue: 0),
                    I_RequestedPOS = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");
        }
    }
}
