﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Space.Repository;

#nullable disable

namespace Space.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231208131422_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Space.Core.Models.Moon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Habitable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTidallyLocked")
                        .HasColumnType("bit");

                    b.Property<string>("MainAtmosphericComponents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.Property<string>("SurfaceFeature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Moons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Habitable = false,
                            IsTidallyLocked = true,
                            MainAtmosphericComponents = "[]",
                            Name = "Luna",
                            PlanetId = 1,
                            SurfaceFeature = "Kraterler ve Düz Ovalar"
                        },
                        new
                        {
                            Id = 2,
                            Habitable = false,
                            IsTidallyLocked = false,
                            MainAtmosphericComponents = "[]",
                            Name = "Phobos",
                            PlanetId = 2,
                            SurfaceFeature = "Küçük ve Kraterli"
                        },
                        new
                        {
                            Id = 3,
                            Habitable = false,
                            IsTidallyLocked = true,
                            MainAtmosphericComponents = "[]",
                            Name = "Europa",
                            PlanetId = 3,
                            SurfaceFeature = "Buzlu Yüzey ve Okyanus"
                        });
                });

            modelBuilder.Entity("Space.Core.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Habitable")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.Property<string>("MainAtmosphericComponents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumberofMoons")
                        .HasColumnType("int");

                    b.Property<string>("SurfaceFeature")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Planets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Habitable = true,
                            MainAtmosphericComponents = "[\"Nitrogen\",\"Oxygen\",\"Argon\"]",
                            Name = "Terra",
                            NumberofMoons = 1,
                            SurfaceFeature = "Dağlık ve Ova Alanlar"
                        },
                        new
                        {
                            Id = 2,
                            Habitable = false,
                            MainAtmosphericComponents = "[\"Carbon Dioxide\",\"Nitrogen\",\"Argon\"]",
                            Name = "Mars",
                            NumberofMoons = 2,
                            SurfaceFeature = "Kızıl Çöl ve Kraterler"
                        },
                        new
                        {
                            Id = 3,
                            Habitable = false,
                            MainAtmosphericComponents = "[\"Hydrogen\",\"Helium\",\"Methane\"]",
                            Name = "Jupiter",
                            NumberofMoons = 79,
                            SurfaceFeature = "Gaz Devi, Bulut Bantları ve Fırtınalar"
                        });
                });

            modelBuilder.Entity("Space.Core.Models.WeatherCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AtmosphericPressure")
                        .HasColumnType("float");

                    b.Property<int?>("MoonId")
                        .HasColumnType("int");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("int");

                    b.Property<string>("PrecipitationType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SkyCondition")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("SurfaceTemperature")
                        .HasColumnType("float");

                    b.Property<double>("Visibility")
                        .HasColumnType("float");

                    b.Property<string>("WindDirection")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("WindSpeed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MoonId");

                    b.HasIndex("PlanetId");

                    b.ToTable("WeatherConditions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AtmosphericPressure = 0.90000000000000002,
                            PlanetId = 1,
                            PrecipitationType = "Asit Yağmurları",
                            SkyCondition = "Yüksek Bulutluluk",
                            SurfaceTemperature = -23.0,
                            Visibility = 16.0,
                            WindDirection = "Kuzey",
                            WindSpeed = 40.0
                        },
                        new
                        {
                            Id = 2,
                            AtmosphericPressure = 0.0,
                            MoonId = 1,
                            PrecipitationType = "Demir Yağmurları",
                            SkyCondition = "Açık Gök",
                            SurfaceTemperature = -120.0,
                            Visibility = 100.0,
                            WindDirection = "Doğu",
                            WindSpeed = 0.0
                        },
                        new
                        {
                            Id = 3,
                            AtmosphericPressure = 1.2,
                            PlanetId = 2,
                            PrecipitationType = "Sıvı Su Yağmurları",
                            SkyCondition = "Parçalı Bulutlu",
                            SurfaceTemperature = 35.0,
                            Visibility = 10.0,
                            WindDirection = "Güneybatı",
                            WindSpeed = 20.0
                        });
                });

            modelBuilder.Entity("Space.Core.Models.Moon", b =>
                {
                    b.HasOne("Space.Core.Models.Planet", "Planet")
                        .WithMany("Moons")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("Space.Core.Models.WeatherCondition", b =>
                {
                    b.HasOne("Space.Core.Models.Moon", "Moon")
                        .WithMany("WeatherConditions")
                        .HasForeignKey("MoonId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Space.Core.Models.Planet", "Planet")
                        .WithMany("WeatherConditions")
                        .HasForeignKey("PlanetId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Moon");

                    b.Navigation("Planet");
                });

            modelBuilder.Entity("Space.Core.Models.Moon", b =>
                {
                    b.Navigation("WeatherConditions");
                });

            modelBuilder.Entity("Space.Core.Models.Planet", b =>
                {
                    b.Navigation("Moons");

                    b.Navigation("WeatherConditions");
                });
#pragma warning restore 612, 618
        }
    }
}
