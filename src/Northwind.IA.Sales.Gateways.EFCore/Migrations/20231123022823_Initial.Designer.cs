﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Northwind.IA.Sales.Gateways.EFCore.Contexts;

#nullable disable

namespace Northwind.IA.Sales.Gateways.EFCore.Migrations
{
    [DbContext(typeof(NorthwindContext))]
    [Migration("20231123022823_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Northwind.AB.Sales.Backend.BusinessObjects.POCOs.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("DiscountType")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("ShipCity")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShipCountry")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShipPostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ShippingType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Northwind.IA.Sales.Gateways.EFCore.Entities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<decimal>("CurrentBalance")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = "ALFKI",
                            CurrentBalance = 0m,
                            Name = "Alfred Futterkis"
                        },
                        new
                        {
                            Id = "ANATR",
                            CurrentBalance = 0m,
                            Name = "Caceres"
                        },
                        new
                        {
                            Id = "ANTON",
                            CurrentBalance = 100m,
                            Name = "Antobio Moreno"
                        });
                });

            modelBuilder.Entity("Northwind.IA.Sales.Gateways.EFCore.Entities.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Northwind.IA.Sales.Gateways.EFCore.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Te Chai",
                            UnitPrice = 35m,
                            UnitsInStock = 20
                        },
                        new
                        {
                            Id = 2,
                            Name = "Chang",
                            UnitPrice = 55m,
                            UnitsInStock = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Annised Syrup",
                            UnitPrice = 65m,
                            UnitsInStock = 20
                        },
                        new
                        {
                            Id = 4,
                            Name = "Chef Anton's",
                            UnitPrice = 75m,
                            UnitsInStock = 40
                        });
                });

            modelBuilder.Entity("Northwind.AB.Sales.Backend.BusinessObjects.POCOs.Order", b =>
                {
                    b.HasOne("Northwind.IA.Sales.Gateways.EFCore.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Northwind.IA.Sales.Gateways.EFCore.Entities.OrderDetail", b =>
                {
                    b.HasOne("Northwind.AB.Sales.Backend.BusinessObjects.POCOs.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Northwind.IA.Sales.Gateways.EFCore.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
