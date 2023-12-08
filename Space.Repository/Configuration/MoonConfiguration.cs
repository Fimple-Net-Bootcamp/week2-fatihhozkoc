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
    public class MoonConfiguration : IEntityTypeConfiguration<Moon>
    {
        public void Configure(EntityTypeBuilder<Moon> builder)
        {
            // Temel anahtarın ayarlanması
            builder.HasKey(m => m.Id);

            // 'Name', 'SurfaceFeature', 'Habitable', ve 'MainAtmosphericComponents' özelliklerinin yapılandırılması
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.SurfaceFeature).IsRequired();
            builder.Property(m => m.Habitable).IsRequired();
            builder.Property(m => m.MainAtmosphericComponents)
                   .HasConversion(
                       v => JsonConvert.SerializeObject(v),
                       v => JsonConvert.DeserializeObject<List<string>>(v))
                   .IsRequired();

            // 'PlanetId' ve 'Planet' ilişkisinin yapılandırılması
            builder.HasOne(m => m.Planet)
                   .WithMany(p => p.Moons)
                   .HasForeignKey(m => m.PlanetId);

            // 'IsTidallyLocked' özelliği için yapılandırma
            builder.Property(m => m.IsTidallyLocked).IsRequired();

            // 'WeatherConditions' koleksiyonu için ilişki yapılandırması
            builder.HasMany(m => m.WeatherConditions)
                   .WithOne(m=>m.Moon) 
                   .HasForeignKey(m => m.MoonId); // Foreign Key alan adı
        }
    }
}
