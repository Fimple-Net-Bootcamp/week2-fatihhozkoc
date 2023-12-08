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
    public class MoonSeed : IEntityTypeConfiguration<Moon>
    {
        public void Configure(EntityTypeBuilder<Moon> builder)
        {
            builder.HasData(
        new Moon
        {
            Id = 1,
            Name = "Luna",
            SurfaceFeature = "Kraterler ve Düz Ovalar",
            Habitable = false,
            PlanetId = 1, 
            IsTidallyLocked = true,
            MainAtmosphericComponents = new List<string>() // Atmosferik bileşenler örnek
        },
        new Moon
        {
            Id = 2,
            Name = "Phobos",
            SurfaceFeature = "Küçük ve Kraterli",
            Habitable = false,
            PlanetId = 2, 
            IsTidallyLocked = false,
            MainAtmosphericComponents = new List<string>() // Atmosferik bileşenler örnek
        },
        new Moon
        {
            Id = 3,
            Name = "Europa",
            SurfaceFeature = "Buzlu Yüzey ve Okyanus",
            Habitable = false,
            PlanetId = 3, 
            IsTidallyLocked = true,
            MainAtmosphericComponents = new List<string>() // Atmosferik bileşenler örnek
        }
    );
        }
    }
}
