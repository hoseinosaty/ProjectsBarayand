using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class TrainingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    T_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    T_Code = table.Column<string>(nullable: true),
                    T_MainCatId = table.Column<int>(nullable: false),
                    T_EndLevelCatId = table.Column<int>(nullable: false),
                    T_Level = table.Column<int>(nullable: false,defaultValue:1),
                    T_Title = table.Column<string>(nullable: true),
                    T_Time = table.Column<string>(nullable: true),
                    T_Image = table.Column<string>(nullable: true),
                    T_Video = table.Column<string>(nullable: true),
                    T_Status = table.Column<bool>(nullable: false),
                    T_Seo = table.Column<string>(nullable: true),
                    T_Url = table.Column<string>(nullable: true),
                    T_ImgGallery = table.Column<string>(maxLength: 2500, nullable: true),
                    T_Description = table.Column<string>(maxLength: 5000, nullable: true),
                    T_Summary = table.Column<string>(maxLength: 5000, nullable: true),
                    T_Cost = table.Column<double>(nullable: false),
                    T_Discount = table.Column<double>(nullable: false),
                    T_DiscountType = table.Column<int>(nullable: false),
                    T_SaleCount = table.Column<int>(nullable: false),
                    T_IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.T_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainings");
        }
    }
}
