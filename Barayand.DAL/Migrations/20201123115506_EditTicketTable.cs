using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class EditTicketTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketResponse");

            migrationBuilder.DropColumn(
                name: "T_Category",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "T_Title",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "T_ParentId",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "T_Userid",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "T_ParentId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "T_Userid",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "T_Category",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "T_Title",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketResponse",
                columns: table => new
                {
                    TR_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TR_Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TR_Tid = table.Column<int>(type: "int", nullable: false),
                    TR_Userid = table.Column<int>(type: "int", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketResponse", x => x.TR_Id);
                });
        }
    }
}
