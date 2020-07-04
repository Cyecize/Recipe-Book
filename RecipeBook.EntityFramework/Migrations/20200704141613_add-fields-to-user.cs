using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.EntityFramework.Migrations
{
    public partial class addfieldstouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date_registered",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date_registered",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");
        }
    }
}
