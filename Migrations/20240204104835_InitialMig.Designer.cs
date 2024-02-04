﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi.Models;

#nullable disable

namespace ProductsApi.Migrations
{
    [DbContext(typeof(ProductsDbContext))]
    [Migration("20240204104835_InitialMig")]
    partial class InitialMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("ProductsApi.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            IsActive = true,
                            Price = 50000.0,
                            ProductName = "Iphone 13"
                        },
                        new
                        {
                            ProductId = 2,
                            IsActive = false,
                            Price = 60000.0,
                            ProductName = "Iphone 14"
                        },
                        new
                        {
                            ProductId = 3,
                            IsActive = true,
                            Price = 70000.0,
                            ProductName = "Iphone 15"
                        },
                        new
                        {
                            ProductId = 4,
                            IsActive = false,
                            Price = 80000.0,
                            ProductName = "Iphone 16"
                        },
                        new
                        {
                            ProductId = 5,
                            IsActive = true,
                            Price = 90000.0,
                            ProductName = "Iphone 17"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
