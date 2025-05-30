﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MottuControlApi.Data;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace MottuControlApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250525131215_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MottuControlApi.Models.ImagemPatio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CaminhoImagem")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)");

                    b.Property<DateTime>("DataCaptura")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("PatioId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("PatioId");

                    b.ToTable("ImagensPatio");
                });

            modelBuilder.Entity("MottuControlApi.Models.Moto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<int>("PatioId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.HasKey("Id");

                    b.HasIndex("PatioId");

                    b.ToTable("Motos");
                });

            modelBuilder.Entity("MottuControlApi.Models.Patio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("Id");

                    b.ToTable("Patios");
                });

            modelBuilder.Entity("MottuControlApi.Models.SensorIoT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MotoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.HasKey("Id");

                    b.HasIndex("MotoId");

                    b.ToTable("Sensores");
                });

            modelBuilder.Entity("MottuControlApi.Models.StatusMonitoramento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("MotoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)");

                    b.HasKey("Id");

                    b.HasIndex("MotoId");

                    b.ToTable("StatusMonitoramentos");
                });

            modelBuilder.Entity("MottuControlApi.Models.ImagemPatio", b =>
                {
                    b.HasOne("MottuControlApi.Models.Patio", "Patio")
                        .WithMany("Imagens")
                        .HasForeignKey("PatioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patio");
                });

            modelBuilder.Entity("MottuControlApi.Models.Moto", b =>
                {
                    b.HasOne("MottuControlApi.Models.Patio", "Patio")
                        .WithMany("Motos")
                        .HasForeignKey("PatioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Patio");
                });

            modelBuilder.Entity("MottuControlApi.Models.SensorIoT", b =>
                {
                    b.HasOne("MottuControlApi.Models.Moto", "Moto")
                        .WithMany("Sensores")
                        .HasForeignKey("MotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Moto");
                });

            modelBuilder.Entity("MottuControlApi.Models.StatusMonitoramento", b =>
                {
                    b.HasOne("MottuControlApi.Models.Moto", "Moto")
                        .WithMany("HistoricoStatus")
                        .HasForeignKey("MotoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Moto");
                });

            modelBuilder.Entity("MottuControlApi.Models.Moto", b =>
                {
                    b.Navigation("HistoricoStatus");

                    b.Navigation("Sensores");
                });

            modelBuilder.Entity("MottuControlApi.Models.Patio", b =>
                {
                    b.Navigation("Imagens");

                    b.Navigation("Motos");
                });
#pragma warning restore 612, 618
        }
    }
}
