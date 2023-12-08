using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Space.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Space.Repository.Seeds
{
    public class WheatherConditionSeed : IEntityTypeConfiguration<WeatherCondition>
    {
        public void Configure(EntityTypeBuilder<WeatherCondition> builder)
        {
            builder.HasData(
                new WeatherCondition
                {
                    Id = 1,
                    SurfaceTemperature = -23.0,
                    AtmosphericPressure = 0.9,
                    WindDirection = "Kuzey",
                    WindSpeed = 40.0,
                    PrecipitationType = "Asit Yağmurları",
                    SkyCondition = "Yüksek Bulutluluk",
                    Visibility = 16.0,
                    date = DateTime.Now,
                    PlanetId = 1, // Bu, önceden oluşturulan bir Planet ID'sine referans vermelidir.
                    MoonId = null // Bu değer null olabilir, eğer hava durumu bir gezegene aitse
                },
                new WeatherCondition
                {
                    Id = 2,
                    SurfaceTemperature = -120.0,
                    AtmosphericPressure = 0.0, // Uyduda atmosfer olmayabilir
                    WindDirection = "Doğu",
                    WindSpeed = 0.0, // Uyduda rüzgar olmayabilir
                    PrecipitationType = "Demir Yağmurları",
                    SkyCondition = "Açık Gök",
                    Visibility = 100.0,
                    date = DateTime.Now,
                    PlanetId = null, // Bu değer null olabilir, eğer hava durumu bir uyduda ise
                    MoonId = 1 // Bu, önceden oluşturulan bir Moon ID'sine referans vermelidir.
                },
                new WeatherCondition
                {
                    Id = 3,
                    SurfaceTemperature = 35.0, // Sıcak bir gezegen veya uydu için
                    AtmosphericPressure = 1.2, // Yüksek basınçlı bir atmosfer
                    WindDirection = "Güneybatı",
                    WindSpeed = 20.0,
                    PrecipitationType = "Sıvı Su Yağmurları",
                    SkyCondition = "Parçalı Bulutlu",
                    Visibility = 10.0,
                    date = DateTime.Now,
                    PlanetId = 2, // Bu, önceden oluşturulan bir Planet ID'sine referans vermelidir.
                    MoonId = null // Bu değer null olabilir, eğer hava durumu bir gezegene aitse
                },
                new WeatherCondition
                {
                    Id = 4,
                    SurfaceTemperature = 35.0, // Sıcak bir gezegen veya uydu için
                    AtmosphericPressure = 1.2, // Yüksek basınçlı bir atmosfer
                    WindDirection = "Güneybatı",
                    WindSpeed = 20.0,
                    PrecipitationType = "Sıvı Su Yağmurları",
                    SkyCondition = "Parçalı Bulutlu",
                    Visibility = 10.0,
                    date = DateTime.Now,
                    PlanetId = 2, // Bu, önceden oluşturulan bir Planet ID'sine referans vermelidir.
                    MoonId = null // Bu değer null olabilir, eğer hava durumu bir gezegene aitse
                }
     );
        }
    }
}
