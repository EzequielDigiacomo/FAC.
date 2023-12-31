﻿// <auto-generated />
using System;
using Fac.AccesoDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fac.AccesoDatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231017000115_PrimerMigracion")]
    partial class PrimerMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fac.Entidades.Atleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Beca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CelularDelAtleta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Club")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Dni")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("EmailDelAtleta")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("FechaDeNacimientoDelAtleta")
                        .HasColumnType("datetime2");

                    b.Property<string>("FotoDniDorsal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniFrontal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPasaporteDorsal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoPasaporteFrontal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NumeroCarnetObraSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDePasaporte")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObraSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermisoDeViaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Atletas");
                });

            modelBuilder.Entity("Fac.Entidades.MadreAtleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoMadre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CelularDeLaMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionDeLaMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DniMadre")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("EmailDeLaMadre")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FotoDniDorsalMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniFrontalMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMadre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("MadreAtletas");
                });

            modelBuilder.Entity("Fac.Entidades.PadreAtleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoPadre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CelularDelPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionDelPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DniPadre")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("EmailDelPadre")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FotoDniDorsalPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniFrontalPadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePadre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("PadreAtletas");
                });

            modelBuilder.Entity("Fac.Entidades.TutorAtleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoTutor")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CelularDelTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionDelTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DniTutor")
                        .HasMaxLength(99999999)
                        .HasColumnType("bigint");

                    b.Property<string>("EmailDelTutor")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FotoDniDorsalTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoDniFrontalTutor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreTutor")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TutorAtletas");
                });
#pragma warning restore 612, 618
        }
    }
}
