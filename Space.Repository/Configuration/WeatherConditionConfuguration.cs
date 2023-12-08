using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Space.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Repository.Configuration
{
    public class WeatherConditionConfuguration : IEntityTypeConfiguration<WeatherCondition>
    {
        public void Configure(EntityTypeBuilder<WeatherCondition> builder)
        {
            // Temel anahtarın ayarlanması
            builder.HasKey(wc => wc.Id);

            // Hava durumu verilerinin yapılandırılması
            builder.Property(wc => wc.SurfaceTemperature).IsRequired();
            builder.Property(wc => wc.AtmosphericPressure).IsRequired();
            builder.Property(wc => wc.WindDirection).HasMaxLength(50);
            builder.Property(wc => wc.WindSpeed).IsRequired();
            builder.Property(wc => wc.PrecipitationType).HasMaxLength(100);
            builder.Property(wc => wc.SkyCondition).HasMaxLength(100);
            builder.Property(wc => wc.Visibility).IsRequired();
            builder.Property(wc=>wc.date).IsRequired();

            // 'Planet' ile ilişkinin yapılandırılması
            builder.HasOne(wc => wc.Planet)
                   .WithMany(p => p.WeatherConditions)
                   .HasForeignKey(wc => wc.PlanetId)
                   .OnDelete(DeleteBehavior.Restrict) // İlişkili gezegen silindiğinde hava durumu verilerinin nasıl davranacağını tanımlar
                   .IsRequired(false);

            // 'Moon' ile ilişkinin yapılandırılması
            builder.HasOne(wc => wc.Moon)
                   .WithMany(m => m.WeatherConditions)
                   .HasForeignKey(wc => wc.MoonId)
                   .OnDelete(DeleteBehavior.Restrict) // İlişkili uydu silindiğinde hava durumu verilerinin nasıl davranacağını tanımlar
                   .IsRequired(false); 
        }
    }
}
