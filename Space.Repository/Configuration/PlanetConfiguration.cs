using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Space.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Repository.Configuration
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            // Temel anahtarın ayarlanması
            builder.HasKey(p => p.Id);

            // 'Name' özelliği için yapılandırmalar
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // 'SurfaceFeature' ve 'Habitable' özellikleri, 'AstronomicalBody' sınıfından türetilmiştir.
            builder.Property(p => p.SurfaceFeature)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Habitable)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.NumberofMoons).IsRequired();

            // 'MainAtmosphericComponents' listesinin yapılandırılması
            // Bu alanın bir JSON olarak saklanmasını sağlamak için
            builder.Property(p => p.MainAtmosphericComponents)
                   .HasConversion(
                       v => JsonConvert.SerializeObject(v),
                       v => JsonConvert.DeserializeObject<List<string>>(v))
                   .IsRequired();

            // 'Moons' koleksiyonu için ilişki yapılandırması
            builder.HasMany(p => p.Moons)
                   .WithOne(p=>p.Planet) 
                   .HasForeignKey(p=>p.PlanetId); // Foreign Key alan adı

            // 'WeatherConditions' koleksiyonu için ilişki yapılandırması
            builder.HasMany(p => p.WeatherConditions)
                   .WithOne(p=>p.Planet) 
                   .HasForeignKey(p=>p.PlanetId); // Foreign Key alan adı

        }
    }
}
