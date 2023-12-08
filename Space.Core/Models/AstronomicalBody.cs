using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Core.Models
{
    public abstract class AstronomicalBody
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string SurfaceFeature { get; set; } // Gezegen ve uydunun yüzey özelliği(krater, düz)
        public bool Habitable { get; set; }  // Gezegenin yaşanılabilir olup olmadığı
        public List<string> MainAtmosphericComponents { get; set; } // Atmosferdeki başlıca bileşenler
    }
}
