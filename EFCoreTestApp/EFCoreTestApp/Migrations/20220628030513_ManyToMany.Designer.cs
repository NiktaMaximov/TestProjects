﻿// <auto-generated />
using System;
using EFCoreTestApp.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreTestApp.Migrations
{
    [DbContext(typeof(EFDatabaseContext))]
    [Migration("20220628030513_ManyToMany")]
    partial class ManyToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreTestApp.Models.ConcatDetails", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("LocationID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SupplierId")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.HasIndex("SupplierId")
                        .IsUnique()
                        .HasFilter("[SupplierId] IS NOT NULL");

                    b.ToTable("ConcatDetails");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.ConcatLocation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ConcatLocation");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Colors")
                        .HasColumnType("int");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.ProductShipmentJunction", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long>("ShipmentId")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ProductShipmentJunction");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.Shipment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EndCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipperName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartCity")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.Supplier", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.ConcatDetails", b =>
                {
                    b.HasOne("EFCoreTestApp.Models.ConcatLocation", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("EFCoreTestApp.Models.Supplier", "Supplier")
                        .WithOne("Concat")
                        .HasForeignKey("EFCoreTestApp.Models.ConcatDetails", "SupplierId");

                    b.Navigation("Location");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.Product", b =>
                {
                    b.HasOne("EFCoreTestApp.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.ProductShipmentJunction", b =>
                {
                    b.HasOne("EFCoreTestApp.Models.Product", "Product")
                        .WithMany("ProductShipments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreTestApp.Models.Shipment", "Shipment")
                        .WithMany("ProductShipments")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.Product", b =>
                {
                    b.Navigation("ProductShipments");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.Shipment", b =>
                {
                    b.Navigation("ProductShipments");
                });

            modelBuilder.Entity("EFCoreTestApp.Models.Supplier", b =>
                {
                    b.Navigation("Concat");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
