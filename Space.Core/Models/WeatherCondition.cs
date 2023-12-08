using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Core.Models
{
    public class WeatherCondition
    {
        public int Id {  get; set; }
        // Hava durumu verileri
        public double SurfaceTemperature { get; set; } // Derece Celsius cinsinden
        public double AtmosphericPressure { get; set; } // Atmosfer basıncı, bar cinsinden
        public string WindDirection { get; set; } // Rüzgar yönü
        public double WindSpeed { get; set; } // Kilometre/saat cinsinden
        public string PrecipitationType { get; set; } // Örnek: "Asit Yağmurları", "Demir Yağmurları"
        public string SkyCondition { get; set; } // Örnek: "Çok Bulutlu", "Gaz Bulutları"
        public double Visibility { get; set; } // Kilometre cinsinden görüş mesafesi
        public DateTime date { get; set; }

        // Planet ile bireçok ilişki
        public int? PlanetId { get; set; }
        public Planet Planet { get; set; }

        // Moon ile bireçok ilişki 
        public int? MoonId { get; set; }
        public Moon Moon { get; set; }
    }
}
