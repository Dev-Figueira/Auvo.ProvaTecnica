﻿// <auto-generated />
using System;
using Auvo.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Auvo.Data.Migrations
{
    [DbContext(typeof(AuvoDbContext))]
    [Migration("20200812173854_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Auvo.Busness.Models.Ponto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Ponto");
                });

            modelBuilder.Entity("Auvo.Busness.Models.Registro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NomeDoColaborador")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("PontoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoDoRegistro")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("PontoId");

                    b.ToTable("Registro");
                });

            modelBuilder.Entity("Auvo.Busness.Models.Registro", b =>
                {
                    b.HasOne("Auvo.Busness.Models.Ponto", "Ponto")
                        .WithMany("Registros")
                        .HasForeignKey("PontoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}