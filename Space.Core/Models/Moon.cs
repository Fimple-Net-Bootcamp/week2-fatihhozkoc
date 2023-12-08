using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Core.Models
{
    public class Moon: AstronomicalBody
    {
        // Uydunun ilişkili olduğu gezegen ile referansı 
        public int PlanetId { get; set; } 
        public Planet Planet { get; set; }

        //  Uydu, gezegenine karşı sabit konumda mı yoksa hareketli mi?
        public bool IsTidallyLocked { get; set; }   

        // Uydunun hava durumu bireçok ilişki referansı
        public ICollection<WeatherCondition> WeatherConditions { get; set; }
    }
}
