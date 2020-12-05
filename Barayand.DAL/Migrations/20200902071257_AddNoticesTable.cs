using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddNoticesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notices",
                columns: table => new
                {
                    N_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_At = table.Column<DateTime>(nullable: true),
                    Updated_At = table.Column<DateTime>(nullable: true),
                    Deleted_At = table.Column<DateTime>(nullable: true),
                    N_Type = table.Column<int>(nullable: false),
                    N_CId = table.Column<int>(nullable: false),
                    N_Title = table.Column<string>(maxLength: 500, nullable: true),
                    N_Sup = table.Column<string>(maxLength: 500, nullable: true),
                    N_Date = table.Column<DateTime>(nullable: false),
                    N_Sort = table.Column<int>(nullable: false),
                    N_Status = table.Column<bool>(nullable: false),
                    N_Image = table.Column<string>(maxLength: 1000, nullable: true),
                    N_Seo = table.Column<string>(maxLength: 4000, nullable: true),
                    N_Media = table.Column<string>(maxLength: 4000, nullable: true),
                    N_MediaType = table.Column<int>(nullable: false),
                    N_Summary = table.Column<string>(maxLength: 2500, nullable: true),
                    N_Content = table.Column<string>(maxLength: 4000, nullable: true),
                    N_IsDeleted = table.Column<bool>(nullable: false),
                    N_Url = table.Column<string>(nullable: true),
                    N_Attachment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.N_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notices");
        }
    }
}
