using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Core.Models
{
    public class Planet : AstronomicalBody
    {
        // Gezegenin uydularını temsil eden koleksiyon
        public ICollection<Moon> Moons { get; set; }

        // Gezegenin hava durumu ile bireçok ilişkisi
        public ICollection<WeatherCondition> WeatherConditions { get; set; }

        // Gezegenin sahip olduğu uydu sayısı
        public int NumberofMoons {  get; set; }
    }
}
