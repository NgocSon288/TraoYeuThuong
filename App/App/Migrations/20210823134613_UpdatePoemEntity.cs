using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UpdatePoemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "StoryPoems",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "StoryPoems",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stories",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 23, 20, 46, 12, 909, DateTimeKind.Local).AddTicks(8140),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 22, 21, 36, 54, 782, DateTimeKind.Local).AddTicks(2785));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "StoryPoems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "StoryPoems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 22, 21, 36, 54, 782, DateTimeKind.Local).AddTicks(2785),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 23, 20, 46, 12, 909, DateTimeKind.Local).AddTicks(8140));
        }
    }
}
