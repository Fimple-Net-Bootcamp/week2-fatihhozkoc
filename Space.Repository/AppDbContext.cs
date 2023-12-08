using Microsoft.EntityFrameworkCore;
using Space.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Space.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Planet> Planets { get; set; }  
        public DbSet<Moon> Moons { get; set; }
        public DbSet<WeatherCondition> WeatherConditions {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IEntityTypeConfiguration interface'ini implemente ettiğim tüm sınıfları kapsar, tek tek yazmak yerine
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
