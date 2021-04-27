﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxContext))]
    [Migration("20210427144939_Adding Relationship between store and Pizza")]
    partial class AddingRelationshipbetweenstoreandPizza
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AOrderAPizza", b =>
                {
                    b.Property<long>("OrdersEntityID")
                        .HasColumnType("bigint");

                    b.Property<long>("PizzasEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("OrdersEntityID", "PizzasEntityID");

                    b.HasIndex("PizzasEntityID");

                    b.ToTable("AOrderAPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.ACustomer", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.ToTable("Customers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ACustomer");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AOrder", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ACustomerEntityID")
                        .HasColumnType("bigint");

                    b.Property<long?>("CustomerEntityID")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<long?>("StoreEntityID")
                        .HasColumnType("bigint");

                    b.HasKey("EntityID");

                    b.HasIndex("ACustomerEntityID");

                    b.HasIndex("CustomerEntityID");

                    b.HasIndex("StoreEntityID");

                    b.ToTable("Orders");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AOrder");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CrustEntityID")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SizeEntityID")
                        .HasColumnType("bigint");

                    b.Property<long?>("ToppingEntityID")
                        .HasColumnType("bigint");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.HasIndex("CrustEntityID");

                    b.HasIndex("SizeEntityID");

                    b.HasIndex("ToppingEntityID");

                    b.ToTable("Pizzas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("APizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityID");

                    b.ToTable("Stores");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AStore");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Crusts");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.Property<long>("EntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("APizzaEntityID")
                        .HasColumnType("bigint");

                    b.Property<long?>("APizzaEntityID1")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("EntityID");

                    b.HasIndex("APizzaEntityID");

                    b.HasIndex("APizzaEntityID1");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.RegCustomer", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.ACustomer");

                    b.HasDiscriminator().HasValue("RegCustomer");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Samual Adams"
                        });
                });

            modelBuilder.Entity("RegOrder", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.AOrder");

                    b.HasDiscriminator().HasValue("RegOrder");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.CheesePizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("CheesePizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.CustomPizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("CustomPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.MeatLoversPizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("MeatLoversPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.VeggiePizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("VeggiePizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.ChicagoStore", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

                    b.HasDiscriminator().HasValue("ChicagoStore");

                    b.HasData(
                        new
                        {
                            EntityID = 2L,
                            Name = "Chitown Pizzeria"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.NewYorkStore", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

                    b.HasDiscriminator().HasValue("NewYorkStore");

                    b.HasData(
                        new
                        {
                            EntityID = 1L,
                            Name = "Da Best NY Pizza"
                        });
                });

            modelBuilder.Entity("AOrderAPizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.AOrder", null)
                        .WithMany()
                        .HasForeignKey("OrdersEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasEntityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AOrder", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.ACustomer", null)
                        .WithMany()
                        .HasForeignKey("ACustomerEntityID");

                    b.HasOne("PizzaBox.Domain.Abstracts.ACustomer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerEntityID");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityID");

                    b.Navigation("Customer");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustEntityID");

                    b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeEntityID");

                    b.HasOne("PizzaBox.Domain.Models.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingEntityID");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("APizzaEntityID");

                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", null)
                        .WithMany()
                        .HasForeignKey("APizzaEntityID1");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.ACustomer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
