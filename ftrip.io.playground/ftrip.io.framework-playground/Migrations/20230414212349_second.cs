using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ftrip.io.framework_playground.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WeatherForecasts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "WeatherForecasts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "WeatherForecasts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "WeatherForecasts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "WeatherForecasts");
        }
    }
}
