using App.ApplicationCore.Domain;
using App.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure
{
    public class Context : DbContext
    { DbSet<ApplicationCore.Domain.Activite> Activites { get; set; }
        DbSet<ApplicationCore.Domain.Conseiller> Conseillers { get; set; }
        DbSet<ApplicationCore.Domain.Pack> Packs { get; set; }
        DbSet<ApplicationCore.Domain.Reservation> Reservations { get; set; }
       
        DbSet<ApplicationCore.Domain.Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseLazyLoadingProxies().
                UseSqlServer(this.GetJsonConnectionString("appsettings.json"));
            base.OnConfiguring(optionsBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activite>().OwnsOne(e => e.zone);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Model.GetEntityTypes()
    .SelectMany(t => t.GetProperties())
    .Where(p => p.ClrType == typeof(string))
    .ToList()
    .ForEach(p => p.SetMaxLength(15));


            modelBuilder.Entity<Client>()
                .HasOne(c => c.Conseiller)
                .WithMany(co => co.Clients)
                .HasForeignKey(c => c.ConseillerFk)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new ReservationConfig());
        }

        
    }

   
}
