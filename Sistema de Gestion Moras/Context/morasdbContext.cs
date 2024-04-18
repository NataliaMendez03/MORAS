﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata;
using Sistema_de_Gestion_Moras.Models;
namespace Sistema_de_Gestion_Moras.Context
{
    public class berriesdbContext : DbContext
    {
        ///HOLA :D
        public berriesdbContext(DbContextOptions<berriesdbContext> options) : base(options)
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

            modelBuilder.Entity<PurchaseDetail>()
                .HasKey(e => e.IdPurchaseDetail);
            modelBuilder.Entity<Storage>()
             .HasKey(e => e.IdStorage);
            modelBuilder.Entity<Contact>()
                .HasKey(e => e.IdContact);
            modelBuilder.Entity<Employees>()
                .HasKey(e => e.IdEmployees);
            modelBuilder.Entity<Post>()
                .HasKey(e => e.IdPost);
            modelBuilder.Entity<State>()
                .HasKey(e => e.IdState);
            modelBuilder.Entity<IdentificationType>()
                .HasKey(e => e.IdIdentificationType);

            modelBuilder.Entity<City>()
                .HasKey(e => e.IdCity);
            modelBuilder.Entity<Address>()
                .HasKey(e => e.IdAddress);
            modelBuilder.Entity<Quality>()
                .HasKey(e => e.IdQuality);
            modelBuilder.Entity<Providers>()
                .HasKey(e => e.IdProviders);
            modelBuilder.Entity<BillSale>()
                .HasKey(e => e.IdBillSale);
            modelBuilder.Entity<Purchase>()
                .HasKey(e => e.IdPurchase);
            modelBuilder.Entity<ProvidervsInputs>()
              .HasKey(e => e.IdProvsInp);

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

        public DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<IdentificationType> IdentificationType { get; set; }

        public DbSet<City> City { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Quality> Quality { get; set; }
        public DbSet<Providers> Providers { get; set; }
        public DbSet<BillSale> BillSale { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<ProvidervsInputs> ProvidervsInputs { get; set; }

    }
}
