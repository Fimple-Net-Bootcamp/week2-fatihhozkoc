using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Space.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initialv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherConditions",
                columns: new[] { "Id", "AtmosphericPressure", "MoonId", "PlanetId", "PrecipitationType", "SkyCondition", "SurfaceTemperature", "Visibility", "WindDirection", "WindSpeed" },
                values: new object[] { 4, 1.2, null, 2, "Sıvı Su Yağmurları", "Parçalı Bulutlu", 35.0, 10.0, "Güneybatı", 20.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherConditions",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
