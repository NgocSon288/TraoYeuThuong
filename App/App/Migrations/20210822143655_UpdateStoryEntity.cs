using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UpdateStoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stories",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 22, 21, 36, 54, 782, DateTimeKind.Local).AddTicks(2785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 22, 15, 31, 48, 457, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Stories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Stories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 22, 15, 31, 48, 457, DateTimeKind.Local).AddTicks(7497),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 22, 21, 36, 54, 782, DateTimeKind.Local).AddTicks(2785));
        }
    }
}
