using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class TrainingSeasonsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingSeasons",
                columns: table => new
                {
                    S_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    S_TId = table.Column<int>(nullable: false),
                    S_Title = table.Column<string>(nullable: true),
                    S_Time = table.Column<string>(nullable: true),
                    S_Cost = table.Column<decimal>(nullable: false,defaultValue:0),
                    S_Sort = table.Column<int>(nullable: false,defaultValue:1),
                    S_VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSeasons", x => x.S_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingSeasons");
        }
    }
}
