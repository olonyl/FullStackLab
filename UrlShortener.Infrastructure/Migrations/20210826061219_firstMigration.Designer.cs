﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrlShortener.Infrastructure;

namespace UrlShortener.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210826061219_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UrlShortener.Domain.Entities.Click", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Browser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Platform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UrlId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UrlId");

                    b.ToTable("Clicks");
                });

            modelBuilder.Entity("UrlShortener.Domain.Entities.Url", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Urls");
                });

            modelBuilder.Entity("UrlShortener.Domain.Entities.Click", b =>
                {
                    b.HasOne("UrlShortener.Domain.Entities.Url", "Url")
                        .WithMany("Clicks")
                        .HasForeignKey("UrlId");

                    b.Navigation("Url");
                });

            modelBuilder.Entity("UrlShortener.Domain.Entities.Url", b =>
                {
                    b.Navigation("Clicks");
                });
#pragma warning restore 612, 618
        }
    }
}