using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UpdateTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "StoryCelebrates",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stories",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 22, 15, 31, 48, 457, DateTimeKind.Local).AddTicks(7497),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 8, 21, 21, 2, 14, 423, DateTimeKind.Local).AddTicks(1944));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "StoryCelebrates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 21, 21, 2, 14, 423, DateTimeKind.Local).AddTicks(1944),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 8, 22, 15, 31, 48, 457, DateTimeKind.Local).AddTicks(7497));
        }
    }
}
