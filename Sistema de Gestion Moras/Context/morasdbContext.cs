using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using Sistema_de_Gestion_Moras.Models;
namespace Sistema_de_Gestion_Moras.Context
{
    public class morasdbContext: DbContext
    {
        ///HOLA :D
        public morasdbContext(DbContextOptions<morasdbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tracking>()
                .HasKey(e => e.IdTracking);
            modelBuilder.Entity<SalesDetails>()
             .HasKey(e => e.IdSalesDetails);
            modelBuilder.Entity<Dispatch>()
                .HasKey(e => e.IdDispatch);
            modelBuilder.Entity<Client>()
                .HasKey(e => e.IdClient);
            modelBuilder.Entity<Harvests>()
                .HasKey(e => e.IdHarvests);
            modelBuilder.Entity<Person>()
                .HasKey(e => e.IdPerson);
            modelBuilder.Entity<Supplies>()
                .HasKey(e => e.IdSupplies);
            //HasNoKey()
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;

            }
        }
        public DbSet<Tracking> Tracking { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<Dispatch> Dispatch { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Harvests> Harvests { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Supplies> Supplies { get; set; }
    }
}
