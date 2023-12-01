﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Context;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(XPandDbContext))]
    partial class XPandDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Planet", b =>
                {
                    b.Property<int>("PlanetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanetId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("PlanetId");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("Domain.Entities.PlanetExplorationRobot", b =>
                {
                    b.Property<int>("PlanetExplorationId")
                        .HasColumnType("int");

                    b.Property<int>("RobotId")
                        .HasColumnType("int");

                    b.HasKey("PlanetExplorationId", "RobotId");

                    b.ToTable("PlanetExplorationRobots");
                });

            modelBuilder.Entity("Domain.Entities.PlanetExplorationStatus", b =>
                {
                    b.Property<int>("PlanetExplorationStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlanetExplorationStatusId");

                    b.ToTable("PlanetExplorationStatuses");

                    b.HasData(
                        new
                        {
                            PlanetExplorationStatusId = 1,
                            Label = "OK"
                        },
                        new
                        {
                            PlanetExplorationStatusId = 2,
                            Label = "!OK"
                        },
                        new
                        {
                            PlanetExplorationStatusId = 3,
                            Label = "TODO"
                        },
                        new
                        {
                            PlanetExplorationStatusId = 4,
                            Label = "En route"
                        });
                });

            modelBuilder.Entity("PlanetExploration", b =>
                {
                    b.Property<int>("PlanetExplorationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanetExplorationId"), 1L, 1);

                    b.Property<int>("CaptainId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<int>("PlanetExplorationStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PlanetId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("PlanetExplorationId");

                    b.HasIndex("PlanetExplorationStatusId")
                        .IsUnique();

                    b.HasIndex("PlanetId")
                        .IsUnique();

                    b.ToTable("PlanetExplorations");
                });

            modelBuilder.Entity("Domain.Entities.PlanetExplorationRobot", b =>
                {
                    b.HasOne("PlanetExploration", "PlanetExploration")
                        .WithMany("Robots")
                        .HasForeignKey("PlanetExplorationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PlanetExploration");
                });

            modelBuilder.Entity("PlanetExploration", b =>
                {
                    b.HasOne("Domain.Entities.PlanetExplorationStatus", "PlanetExplorationStatus")
                        .WithOne()
                        .HasForeignKey("PlanetExploration", "PlanetExplorationStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Planet", "Planet")
                        .WithOne("PlanetExploration")
                        .HasForeignKey("PlanetExploration", "PlanetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Planet");

                    b.Navigation("PlanetExplorationStatus");
                });

            modelBuilder.Entity("Domain.Entities.Planet", b =>
                {
                    b.Navigation("PlanetExploration");
                });

            modelBuilder.Entity("PlanetExploration", b =>
                {
                    b.Navigation("Robots");
                });
#pragma warning restore 612, 618
        }
    }
}
