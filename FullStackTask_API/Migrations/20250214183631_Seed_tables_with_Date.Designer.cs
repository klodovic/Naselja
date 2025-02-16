﻿// <auto-generated />
using System;
using FullStackTask_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FullStackTask_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250214183631_Seed_tables_with_Date")]
    partial class Seed_tables_with_Date
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KoiosAPI.Model.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Drzava");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 2, 14, 19, 36, 31, 101, DateTimeKind.Local).AddTicks(5486),
                            Naziv = "Hrvatska"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 2, 14, 19, 36, 31, 103, DateTimeKind.Local).AddTicks(6683),
                            Naziv = "Slovenija"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 2, 14, 19, 36, 31, 103, DateTimeKind.Local).AddTicks(6711),
                            Naziv = "Italija"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2025, 2, 14, 19, 36, 31, 103, DateTimeKind.Local).AddTicks(6714),
                            Naziv = "Austrija"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2025, 2, 14, 19, 36, 31, 103, DateTimeKind.Local).AddTicks(6717),
                            Naziv = "Francuska"
                        });
                });

            modelBuilder.Entity("KoiosAPI.Model.Naselje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("PostanskiBroj")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Naselje");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 2, 14, 19, 36, 31, 105, DateTimeKind.Local).AddTicks(8533),
                            DrzavaId = 1,
                            Naziv = "Dubrava",
                            PostanskiBroj = 10000
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 2, 14, 19, 36, 31, 105, DateTimeKind.Local).AddTicks(8876),
                            DrzavaId = 2,
                            Naziv = "Dobova",
                            PostanskiBroj = 2000
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 2, 14, 19, 36, 31, 105, DateTimeKind.Local).AddTicks(8882),
                            DrzavaId = 5,
                            Naziv = "Pariz",
                            PostanskiBroj = 5623
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
