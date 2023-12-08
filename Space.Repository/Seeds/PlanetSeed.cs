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
    public class PlanetSeed : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.HasData(
                new Planet
                {
                    Id = 1,
                    Name = "Terra",
                    SurfaceFeature = "Dağlık ve Ova Alanlar",
                    Habitable = true,
                    MainAtmosphericComponents = new List<string> { "Nitrogen", "Oxygen", "Argon" },
                    NumberofMoons = 1
                },
                new Planet
                {
                    Id = 2,
                    Name = "Mars",
                    SurfaceFeature = "Kızıl Çöl ve Kraterler",
                    Habitable = false,
                    MainAtmosphericComponents = new List<string> { "Carbon Dioxide", "Nitrogen", "Argon" },
                    NumberofMoons = 2
                },
                new Planet
                {
                    Id = 3,
                    Name = "Jupiter",
                    SurfaceFeature = "Gaz Devi, Bulut Bantları ve Fırtınalar",
                    Habitable = false,
                    MainAtmosphericComponents = new List<string> { "Hydrogen", "Helium", "Methane" },
                    NumberofMoons = 79
                }
                );
        }
    }
}
