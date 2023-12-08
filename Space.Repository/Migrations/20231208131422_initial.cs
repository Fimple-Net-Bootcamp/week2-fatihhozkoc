using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Space.Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberofMoons = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SurfaceFeature = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Habitable = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    MainAtmosphericComponents = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanetId = table.Column<int>(type: "int", nullable: false),
                    IsTidallyLocked = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SurfaceFeature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habitable = table.Column<bool>(type: "bit", nullable: false),
                    MainAtmosphericComponents = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moons_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceTemperature = table.Column<double>(type: "float", nullable: false),
                    AtmosphericPressure = table.Column<double>(type: "float", nullable: false),
                    WindDirection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WindSpeed = table.Column<double>(type: "float", nullable: false),
                    PrecipitationType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SkyCondition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Visibility = table.Column<double>(type: "float", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: true),
                    MoonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherConditions_Moons_MoonId",
                        column: x => x.MoonId,
                        principalTable: "Moons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherConditions_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "Id", "Habitable", "MainAtmosphericComponents", "Name", "NumberofMoons", "SurfaceFeature" },
                values: new object[,]
                {
                    { 1, true, "[\"Nitrogen\",\"Oxygen\",\"Argon\"]", "Terra", 1, "Dağlık ve Ova Alanlar" },
                    { 2, false, "[\"Carbon Dioxide\",\"Nitrogen\",\"Argon\"]", "Mars", 2, "Kızıl Çöl ve Kraterler" },
                    { 3, false, "[\"Hydrogen\",\"Helium\",\"Methane\"]", "Jupiter", 79, "Gaz Devi, Bulut Bantları ve Fırtınalar" }
                });

            migrationBuilder.InsertData(
                table: "Moons",
                columns: new[] { "Id", "Habitable", "IsTidallyLocked", "MainAtmosphericComponents", "Name", "PlanetId", "SurfaceFeature" },
                values: new object[,]
                {
                    { 1, false, true, "[]", "Luna", 1, "Kraterler ve Düz Ovalar" },
                    { 2, false, false, "[]", "Phobos", 2, "Küçük ve Kraterli" },
                    { 3, false, true, "[]", "Europa", 3, "Buzlu Yüzey ve Okyanus" }
                });

            migrationBuilder.InsertData(
                table: "WeatherConditions",
                columns: new[] { "Id", "AtmosphericPressure", "MoonId", "PlanetId", "PrecipitationType", "SkyCondition", "SurfaceTemperature", "Visibility", "WindDirection", "WindSpeed" },
                values: new object[,]
                {
                    { 1, 0.90000000000000002, null, 1, "Asit Yağmurları", "Yüksek Bulutluluk", -23.0, 16.0, "Kuzey", 40.0 },
                    { 3, 1.2, null, 2, "Sıvı Su Yağmurları", "Parçalı Bulutlu", 35.0, 10.0, "Güneybatı", 20.0 },
                    { 2, 0.0, 1, null, "Demir Yağmurları", "Açık Gök", -120.0, 100.0, "Doğu", 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moons_PlanetId",
                table: "Moons",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherConditions_MoonId",
                table: "WeatherConditions",
                column: "MoonId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherConditions_PlanetId",
                table: "WeatherConditions",
                column: "PlanetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherConditions");

            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
