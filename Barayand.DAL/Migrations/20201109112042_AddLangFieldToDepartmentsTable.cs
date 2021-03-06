﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddLangFieldToDepartmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "Departments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lang",
                table: "Departments");
        }
    }
}
