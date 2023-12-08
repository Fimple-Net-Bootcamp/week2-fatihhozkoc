using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Space.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initailv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "WeatherConditions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WeatherConditions",
                keyColumn: "Id",
                keyValue: 1,
                column: "date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "WeatherConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "date",
                value: new DateTime(2023, 12, 8, 16, 22, 54, 443, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "WeatherConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "date",
                value: new DateTime(2023, 12, 8, 16, 22, 54, 443, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.UpdateData(
                table: "WeatherConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "date",
                value: new DateTime(2023, 12, 8, 16, 22, 54, 443, DateTimeKind.Local).AddTicks(5575));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "WeatherConditions");
        }
    }
}
