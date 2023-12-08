using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Space.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initialv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "WeatherConditions",
                keyColumn: "Id",
                keyValue: 2,
                column: "date",
                value: new DateTime(2023, 12, 8, 16, 26, 1, 965, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "WeatherConditions",
                keyColumn: "Id",
                keyValue: 3,
                column: "date",
                value: new DateTime(2023, 12, 8, 16, 26, 1, 965, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "WeatherConditions",
                keyColumn: "Id",
                keyValue: 4,
                column: "date",
                value: new DateTime(2023, 12, 8, 16, 26, 1, 965, DateTimeKind.Local).AddTicks(7032));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
