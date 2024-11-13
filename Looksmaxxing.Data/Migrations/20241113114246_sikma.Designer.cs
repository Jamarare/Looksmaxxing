﻿// <auto-generated />
using System;
using Looksmaxxing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Looksmaxxing.Data.Migrations
{
    [DbContext(typeof(LooksmaxxingContext))]
    [Migration("20241113114246_sikma")]
    partial class sikma
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Looksmaxxing.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SigmaID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("FilesToDatabase");
                });

            modelBuilder.Entity("Looksmaxxing.Core.Domain.Sigma", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SigmaDied")
                        .HasColumnType("datetime2");

                    b.Property<int>("SigmaLevel")
                        .HasColumnType("int");

                    b.Property<string>("SigmaMove")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SigmaMovePower")
                        .HasColumnType("int");

                    b.Property<string>("SigmaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SigmaStatus")
                        .HasColumnType("int");

                    b.Property<int>("SigmaType")
                        .HasColumnType("int");

                    b.Property<DateTime>("SigmaWasBorn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SigmaXP")
                        .HasColumnType("int");

                    b.Property<int>("SigmaXPNextLevel")
                        .HasColumnType("int");

                    b.Property<string>("SpecialSigmaMove")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialSigmaMovePower")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sigmas");
                });
#pragma warning restore 612, 618
        }
    }
}
