﻿// <auto-generated />
using System;
using GtRacingNews.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GtRacingNews.Data.Data.Migrations
{
    [DbContext(typeof(GTNewsDbContext))]
    [Migration("20220222095334_InitialCommit")]
    partial class InitialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Championship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Championships");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Cup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChampionshipId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Car", b =>
                {
                    b.HasOne("GtRacingNews.Data.DataModels.Team", null)
                        .WithMany("Cars")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Championship", b =>
                {
                    b.HasOne("GtRacingNews.Data.DataModels.User", null)
                        .WithMany("ReadAbout")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Driver", b =>
                {
                    b.HasOne("GtRacingNews.Data.DataModels.Team", null)
                        .WithMany("Drivers")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.News", b =>
                {
                    b.HasOne("GtRacingNews.Data.DataModels.User", null)
                        .WithMany("ReadLater")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Team", b =>
                {
                    b.HasOne("GtRacingNews.Data.DataModels.Championship", null)
                        .WithMany("Teams")
                        .HasForeignKey("ChampionshipId");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Championship", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.Team", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("GtRacingNews.Data.DataModels.User", b =>
                {
                    b.Navigation("ReadAbout");

                    b.Navigation("ReadLater");
                });
#pragma warning restore 612, 618
        }
    }
}
