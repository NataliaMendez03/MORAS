﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_de_Gestion_Moras.Context;

#nullable disable

namespace Sistema_de_Gestion_Moras.Migrations
{
    [DbContext(typeof(berriesdbContext))]
    [Migration("20240427034835_LoginKey")]
    partial class LoginKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IdentificationType", b =>
                {
                    b.Property<int>("IdIdentificationType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIdentificationType"));

                    b.Property<string>("IdentifiType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdIdentificationType");

                    b.ToTable("IdentificationType");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Achievements", b =>
                {
                    b.Property<int>("IdArchievement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArchievement"));

                    b.Property<DateTime>("DateAchievement")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLogin")
                        .HasColumnType("int");

                    b.Property<int>("IdMission")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdArchievement");

                    b.HasIndex("IdLogin");

                    b.HasIndex("IdMission");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Address", b =>
                {
                    b.Property<int>("IdAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAddress"));

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdAddress");

                    b.HasIndex("IdCity");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.BillSale", b =>
                {
                    b.Property<int>("IdBillSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBillSale"));

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdSalesDetails")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdBillSale");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdSalesDetails");

                    b.ToTable("BillSale");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.City", b =>
                {
                    b.Property<int>("IdCity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCity"));

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdCity");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdClient");

                    b.HasIndex("IdPerson");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Contact", b =>
                {
                    b.Property<int>("IdContact")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContact"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdContact");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Dispatch", b =>
                {
                    b.Property<int>("IdDispatch")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDispatch"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEmployees")
                        .HasColumnType("int");

                    b.Property<int>("IdSalesDetails")
                        .HasColumnType("int");

                    b.Property<int>("IdTracking")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdDispatch");

                    b.HasIndex("IdEmployees");

                    b.HasIndex("IdSalesDetails");

                    b.HasIndex("IdTracking");

                    b.ToTable("Dispatch");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Employees", b =>
                {
                    b.Property<int>("IdEmployees")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmployees"));

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<int>("IdPost")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdEmployees");

                    b.HasIndex("IdPerson");

                    b.HasIndex("IdPost");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Harvests", b =>
                {
                    b.Property<int>("IdHarvests")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHarvests"));

                    b.Property<string>("HarvestAmount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HarvestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdQuality")
                        .HasColumnType("int");

                    b.Property<int>("Idemployees")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdHarvests");

                    b.HasIndex("IdQuality");

                    b.HasIndex("Idemployees");

                    b.ToTable("Harvests");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Levels", b =>
                {
                    b.Property<int>("IdLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLevel"));

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdLevel");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Login", b =>
                {
                    b.Property<int>("IdLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLogin"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisterDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLogin");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Missions", b =>
                {
                    b.Property<int>("IdMission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMission"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdLevel")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameMission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdMission");

                    b.HasIndex("IdLevel");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Person", b =>
                {
                    b.Property<int>("IdPerson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerson"));

                    b.Property<int>("IdAddress")
                        .HasColumnType("int");

                    b.Property<int>("IdContact")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeIdentification")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberIdentification")
                        .HasColumnType("int");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdPerson");

                    b.HasIndex("IdAddress");

                    b.HasIndex("IdContact");

                    b.HasIndex("IdTypeIdentification");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Post", b =>
                {
                    b.Property<int>("IdPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPost"));

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NamePost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdPost");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Providers", b =>
                {
                    b.Property<int>("IdProviders")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProviders"));

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdProviders");

                    b.HasIndex("IdPerson");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.ProvidervsInputs", b =>
                {
                    b.Property<int>("IdProvsInp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProvsInp"));

                    b.Property<int>("IdProviders")
                        .HasColumnType("int");

                    b.Property<int>("IdSupplies")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdProvsInp");

                    b.HasIndex("IdProviders");

                    b.HasIndex("IdSupplies");

                    b.ToTable("ProvidervsInputs");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Purchase", b =>
                {
                    b.Property<int>("IdPurchase")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPurchase"));

                    b.Property<DateTime>("DateProviders")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProviders")
                        .HasColumnType("int");

                    b.Property<int>("IdPurchaseDetail")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdPurchase");

                    b.HasIndex("IdProviders");

                    b.HasIndex("IdPurchaseDetail");

                    b.ToTable("Purchase");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.PurchaseDetail", b =>
                {
                    b.Property<int>("IdPurchaseDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPurchaseDetail"));

                    b.Property<int>("IdSupplies")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PurchasePrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdPurchaseDetail");

                    b.HasIndex("IdSupplies");

                    b.ToTable("PurchaseDetail");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Quality", b =>
                {
                    b.Property<int>("IdQuality")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdQuality"));

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NQuality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdQuality");

                    b.ToTable("Quality");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.SalesDetails", b =>
                {
                    b.Property<int>("IdSalesDetails")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSalesDetails"));

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SalePrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdSalesDetails");

                    b.ToTable("SalesDetails");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.State", b =>
                {
                    b.Property<int>("IdState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdState"));

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdState");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Storage", b =>
                {
                    b.Property<int>("IdStorage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStorage"));

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdHarvests")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStorage");

                    b.HasIndex("IdHarvests");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Supplies", b =>
                {
                    b.Property<int>("IdSupplies")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSupplies"));

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSupplies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdSupplies");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Tracking", b =>
                {
                    b.Property<int>("IdTracking")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTracking"));

                    b.Property<DateTime>("DateTracking")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StateDelete")
                        .HasColumnType("bit");

                    b.HasKey("IdTracking");

                    b.HasIndex("IdState");

                    b.ToTable("Tracking");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Achievements", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Login", "Login")
                        .WithMany()
                        .HasForeignKey("IdLogin")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.Missions", "Mission")
                        .WithMany()
                        .HasForeignKey("IdMission")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Login");

                    b.Navigation("Mission");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Address", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("IdCity")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.BillSale", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.SalesDetails", "SalesDetails")
                        .WithMany()
                        .HasForeignKey("IdSalesDetails")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("SalesDetails");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Client", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Dispatch", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Employees", "Employees")
                        .WithMany()
                        .HasForeignKey("IdEmployees")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.SalesDetails", "SalesDetails")
                        .WithMany()
                        .HasForeignKey("IdSalesDetails")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.Tracking", "Tracking")
                        .WithMany()
                        .HasForeignKey("IdTracking")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("SalesDetails");

                    b.Navigation("Tracking");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Employees", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("IdPost")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Harvests", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Quality", "Quality")
                        .WithMany()
                        .HasForeignKey("IdQuality")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.Employees", "Employees")
                        .WithMany()
                        .HasForeignKey("Idemployees")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Quality");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Missions", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Levels", "Levels")
                        .WithMany()
                        .HasForeignKey("IdLevel")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Levels");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Person", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("IdAddress")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("IdContact")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("IdentificationType", "TypeIdentification")
                        .WithMany()
                        .HasForeignKey("IdTypeIdentification")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Contact");

                    b.Navigation("TypeIdentification");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Providers", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.ProvidervsInputs", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Providers", "Providers")
                        .WithMany()
                        .HasForeignKey("IdProviders")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.Supplies", "Supplies")
                        .WithMany()
                        .HasForeignKey("IdSupplies")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Providers");

                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Purchase", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Providers", "Providers")
                        .WithMany()
                        .HasForeignKey("IdProviders")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Sistema_de_Gestion_Moras.Models.PurchaseDetail", "PurchaseDetail")
                        .WithMany()
                        .HasForeignKey("IdPurchaseDetail")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Providers");

                    b.Navigation("PurchaseDetail");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.PurchaseDetail", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Supplies", "Supplies")
                        .WithMany()
                        .HasForeignKey("IdSupplies")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Supplies");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Storage", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.Harvests", "Harvests")
                        .WithMany()
                        .HasForeignKey("IdHarvests")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Harvests");
                });

            modelBuilder.Entity("Sistema_de_Gestion_Moras.Models.Tracking", b =>
                {
                    b.HasOne("Sistema_de_Gestion_Moras.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
