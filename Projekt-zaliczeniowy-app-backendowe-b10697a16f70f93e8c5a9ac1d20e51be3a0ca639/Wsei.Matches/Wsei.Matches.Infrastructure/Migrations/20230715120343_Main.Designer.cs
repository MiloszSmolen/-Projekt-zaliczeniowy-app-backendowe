﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wsei.Matches.Infrastructure.Contexts;

#nullable disable

namespace Wsei.Matches.Infrastructure.Migrations
{
    [DbContext(typeof(MatchesDbContext))]
    [Migration("20230715120343_Main")]
    partial class Main
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "TestCountry"
                        },
                        new
                        {
                            Id = 2,
                            Name = "TestCountry2"
                        });
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GuestTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StadiumId")
                        .HasColumnType("int");

                    b.Property<float?>("TicketPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("StadiumId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.League", b =>
                {
                    b.HasOne("Wsei.Matches.Core.DbModel.Country", "Country")
                        .WithMany("Leagues")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Match", b =>
                {
                    b.HasOne("Wsei.Matches.Core.DbModel.Team", "GuestTeam")
                        .WithMany("GuestMatches")
                        .HasForeignKey("GuestTeamId")
                        .IsRequired();

                    b.HasOne("Wsei.Matches.Core.DbModel.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .IsRequired();

                    b.HasOne("Wsei.Matches.Core.DbModel.League", "League")
                        .WithMany("Matches")
                        .HasForeignKey("LeagueId");

                    b.HasOne("Wsei.Matches.Core.DbModel.Stadium", "Stadium")
                        .WithMany("Matches")
                        .HasForeignKey("StadiumId");

                    b.Navigation("GuestTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("League");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Team", b =>
                {
                    b.HasOne("Wsei.Matches.Core.DbModel.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId");

                    b.Navigation("League");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Country", b =>
                {
                    b.Navigation("Leagues");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.League", b =>
                {
                    b.Navigation("Matches");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Stadium", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Wsei.Matches.Core.DbModel.Team", b =>
                {
                    b.Navigation("GuestMatches");

                    b.Navigation("HomeMatches");
                });
#pragma warning restore 612, 618
        }
    }
}
