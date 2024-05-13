using Microsoft.EntityFrameworkCore;
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
        // Primary Keys
            modelBuilder.Entity<Tracking>().HasKey(e => e.IdTracking);
            modelBuilder.Entity<SalesDetails>().HasKey(e => e.IdSalesDetails);
            modelBuilder.Entity<Dispatch>().HasKey(e => e.IdDispatch);
            modelBuilder.Entity<Client>().HasKey(e => e.IdClient);
            modelBuilder.Entity<Harvests>().HasKey(e => e.IdHarvests);
            modelBuilder.Entity<Person>().HasKey(e => e.IdPerson);
            modelBuilder.Entity<Supplies>().HasKey(e => e.IdSupplies);
            modelBuilder.Entity<PurchaseDetail>().HasKey(e => e.IdPurchaseDetail);
            modelBuilder.Entity<Storage>().HasKey(e => e.IdStorage);
            modelBuilder.Entity<Contact>().HasKey(e => e.IdContact);
            modelBuilder.Entity<Employees>().HasKey(e => e.IdEmployees);
            modelBuilder.Entity<Post>().HasKey(e => e.IdPost);
            modelBuilder.Entity<State>().HasKey(e => e.IdState);
            modelBuilder.Entity<IdentificationType>().HasKey(e => e.IdIdentificationType);
            modelBuilder.Entity<City>().HasKey(e => e.IdCity);
            modelBuilder.Entity<Address>().HasKey(e => e.IdAddress);
            modelBuilder.Entity<Quality>().HasKey(e => e.IdQuality);
            modelBuilder.Entity<Providers>().HasKey(e => e.IdProviders);
            modelBuilder.Entity<BillSale>().HasKey(e => e.IdBillSale);
            modelBuilder.Entity<Purchase>().HasKey(e => e.IdPurchase);
            modelBuilder.Entity<ProvidervsInputs>().HasKey(e => e.IdProvsInp);
            modelBuilder.Entity<Login>().HasKey(e => e.IdLogin);
            modelBuilder.Entity<Missions>().HasKey(e => e.IdMission);
            modelBuilder.Entity<Achievements>().HasKey(e => e.IdArchievement);
            modelBuilder.Entity<Levels>().HasKey(e => e.IdLevel);
            modelBuilder.Entity<Landmarks>().HasKey(e => e.IdLandmarks);
            modelBuilder.Entity<SystemLogin>().HasKey(e => e.IdSystemLogin);



            // Foreign Keys
            modelBuilder.Entity<Address>().HasOne(e => e.City).WithMany().HasForeignKey(e => e.IdCity);

            modelBuilder.Entity<BillSale>().HasOne(e => e.Client).WithMany().HasForeignKey(e => e.IdClient);
            modelBuilder.Entity<BillSale>().HasOne(e => e.SalesDetails).WithMany().HasForeignKey(e => e.IdSalesDetails);

            modelBuilder.Entity<Client>().HasOne(e => e.Person).WithMany().HasForeignKey(e => e.IdPerson);

            modelBuilder.Entity<Dispatch>().HasOne(e => e.Employees).WithMany().HasForeignKey(e => e.IdEmployees);
            modelBuilder.Entity<Dispatch>().HasOne(e => e.SalesDetails).WithMany().HasForeignKey(e => e.IdSalesDetails);
            modelBuilder.Entity<Dispatch>().HasOne(e => e.Tracking).WithMany().HasForeignKey(e => e.IdTracking);

            modelBuilder.Entity<Employees>().HasOne(e => e.Post).WithMany().HasForeignKey(e => e.IdPost);
            modelBuilder.Entity<Employees>().HasOne(e => e.Person).WithMany().HasForeignKey(e => e.IdPerson);

            modelBuilder.Entity<Harvests>().HasOne(e => e.Employees).WithMany().HasForeignKey(e => e.Idemployees);
            modelBuilder.Entity<Harvests>().HasOne(e => e.Quality).WithMany().HasForeignKey(e => e.IdQuality);

            modelBuilder.Entity<Person>().HasOne(e => e.Contact).WithMany().HasForeignKey(e => e.IdContact);
            modelBuilder.Entity<Person>().HasOne(e => e.Address).WithMany().HasForeignKey(e => e.IdAddress);
            modelBuilder.Entity<Person>().HasOne(e => e.TypeIdentification).WithMany().HasForeignKey(e => e.IdTypeIdentification);

            modelBuilder.Entity<Providers>().HasOne(e => e.Person).WithMany().HasForeignKey(e => e.IdPerson);

            modelBuilder.Entity<ProvidervsInputs>().HasOne(e => e.Providers).WithMany().HasForeignKey(e => e.IdProviders);
            modelBuilder.Entity<ProvidervsInputs>().HasOne(e => e.Supplies).WithMany().HasForeignKey(e => e.IdSupplies);

            modelBuilder.Entity<Purchase>().HasOne(e => e.Providers).WithMany().HasForeignKey(e => e.IdProviders);
            modelBuilder.Entity<Purchase>().HasOne(e => e.PurchaseDetail).WithMany().HasForeignKey(e => e.IdPurchaseDetail);

            modelBuilder.Entity<PurchaseDetail>().HasOne(e => e.Supplies).WithMany().HasForeignKey(e => e.IdSupplies);

            modelBuilder.Entity<Storage>().HasOne(e => e.Harvests).WithMany().HasForeignKey(e => e.IdHarvests);

            modelBuilder.Entity<Tracking>().HasOne(e => e.State).WithMany().HasForeignKey(e => e.IdState);

            modelBuilder.Entity<Achievements>().HasOne(e => e.Mission).WithMany().HasForeignKey(e => e.IdMission);
            modelBuilder.Entity<Achievements>().HasOne(e => e.Login).WithMany().HasForeignKey(e => e.IdLogin);

            modelBuilder.Entity<Missions>().HasOne(e => e.Levels).WithMany().HasForeignKey(e => e.IdLevel);

            modelBuilder.Entity<Landmarks>().HasOne(e => e.Levels).WithMany().HasForeignKey(e => e.IdLevel);
            modelBuilder.Entity<Landmarks>().HasOne(e => e.Harvests).WithMany().HasForeignKey(e => e.IdHarvests);

            modelBuilder.Entity<SystemLogin>().HasOne(e => e.Person).WithMany().HasForeignKey(e => e.IdPerson);




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
        public DbSet<Login> Login { get; set; }
        public DbSet<Missions> Missions { get; set; }
        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<Levels> Levels { get; set; }
        public DbSet<Landmarks> Landmarks { get; set; }
        public DbSet<SystemLogin> SystemLogin { get; set; }


    }
}
