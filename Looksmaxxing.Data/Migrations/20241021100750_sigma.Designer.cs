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
    [Migration("20241021100750_sigma")]
    partial class sigma
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Looksmaxxing.Core.Domain.Sigma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SigmaDied")
                        .HasColumnType("datetime2");

                    b.Property<int>("SigmaLevel")
                        .HasColumnType("int");

                    b.Property<int>("SigmaMove")
                        .HasColumnType("int");

                    b.Property<int>("SigmaMovePower")
                        .HasColumnType("int");

                    b.Property<string>("SigmaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SigmaType")
                        .HasColumnType("int");

                    b.Property<DateTime>("SigmaWasBorn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SigmaXP")
                        .HasColumnType("int");

                    b.Property<int>("SigmaXPNextLevel")
                        .HasColumnType("int");

                    b.Property<int>("SpecialSigmaMove")
                        .HasColumnType("int");

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
