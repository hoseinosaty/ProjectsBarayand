﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Barayand.DAL.Migrations
{
    public partial class AddEntityIdPromotionBoxProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "B_EntityId",
                table: "PromotionBoxs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B_EntityId",
                table: "PromotionBoxs");
        }
    }
}
