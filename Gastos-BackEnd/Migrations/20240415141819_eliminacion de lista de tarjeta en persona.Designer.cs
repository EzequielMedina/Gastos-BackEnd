﻿// <auto-generated />
using System;
using Gastos_BackEnd.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gastos_BackEnd.Migrations
{
    [DbContext(typeof(GastosDbContext))]
    [Migration("20240415141819_eliminacion de lista de tarjeta en persona")]
    partial class eliminaciondelistadetarjetaenpersona
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gastos_BackEnd.Entity.PersonaPorTarjetum", b =>
                {
                    b.Property<Guid>("PersonaPorTarjetaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TarjetaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonaPorTarjetaId");

                    b.HasIndex("PersonaId");

                    b.HasIndex("TarjetaId");

                    b.ToTable("PersonaPorTarjeta");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Categorium", b =>
                {
                    b.Property<Guid>("Categoriald")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Categoriald")
                        .HasName("PK__Categori__F35292A991230A17");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Gasto", b =>
                {
                    b.Property<Guid>("GastoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid>("Categoriald")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("NombreGasto")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Personald")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TipoGastold")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GastoId")
                        .HasName("PK__Gasto__815BB0F042970835");

                    b.HasIndex("Categoriald");

                    b.HasIndex("Personald");

                    b.HasIndex("TipoGastold");

                    b.ToTable("Gasto", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Ingreso", b =>
                {
                    b.Property<Guid>("Ingresold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Descripcion")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Ingresold")
                        .HasName("PK__Ingreso__DBF5AF368BA5BEE0");

                    b.ToTable("Ingreso", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.IngresoPorPersona", b =>
                {
                    b.Property<Guid>("Ingresold")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Personald")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Ingresold", "Personald");

                    b.HasIndex("Personald");

                    b.ToTable("IngresoPorPersona", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Movimiento", b =>
                {
                    b.Property<Guid>("Movimientold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Descripcion")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<Guid>("GastoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("MontoTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Movimientold")
                        .HasName("PK__Movimien__BF912077B5AA5E24");

                    b.HasIndex("GastoId");

                    b.ToTable("Movimiento", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Periodo", b =>
                {
                    b.Property<Guid>("Periodold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("date");

                    b.Property<decimal?>("Monto")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("NombrePeriodo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("TarjetaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Periodold")
                        .HasName("PK__Periodo__0ADCD0AC013116D5");

                    b.HasIndex("TarjetaId");

                    b.ToTable("Periodo", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.PeriodoPorGasto", b =>
                {
                    b.Property<Guid>("Periodold")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GastoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Periodold", "GastoId");

                    b.HasIndex("GastoId");

                    b.ToTable("PeriodoPorGasto", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Persona", b =>
                {
                    b.Property<Guid>("Personald")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Personald")
                        .HasName("PK__Persona__7C35C71847E88CC5");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.TarjetaPorPeriodo", b =>
                {
                    b.Property<int?>("CoutaActual")
                        .HasColumnType("int");

                    b.Property<int?>("CoutasTotales")
                        .HasColumnType("int");

                    b.Property<Guid>("GastoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Periodold")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TarjetaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TarjetaId ");

                    b.HasIndex("GastoId");

                    b.HasIndex("Periodold");

                    b.HasIndex("TarjetaId");

                    b.ToTable("TarjetaPorPeriodo", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Tarjetum", b =>
                {
                    b.Property<Guid>("TarjetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TarjetaId")
                        .HasName("PK__Tarjeta__C8250776213C208B");

                    b.ToTable("Tarjeta");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.TipoGasto", b =>
                {
                    b.Property<Guid>("TipoGastold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TipoGastold")
                        .HasName("PK__TipoGast__C00FC16A74B21049");

                    b.ToTable("TipoGasto", (string)null);
                });

            modelBuilder.Entity("Gastos_BackEnd.Entity.PersonaPorTarjetum", b =>
                {
                    b.HasOne("Gastos_BackEnd.Repository.Entity.Persona", "Persona")
                        .WithMany("PersonaPorTarjeta")
                        .HasForeignKey("PersonaId")
                        .IsRequired()
                        .HasConstraintName("FK_PersonaPorTarjeta_Persona");

                    b.HasOne("Gastos_BackEnd.Repository.Entity.Tarjetum", "Tarjeta")
                        .WithMany("PersonaPorTarjeta")
                        .HasForeignKey("TarjetaId")
                        .IsRequired()
                        .HasConstraintName("FK_PersonaPorTarjeta_Tarjeta");

                    b.Navigation("Persona");

                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Gasto", b =>
                {
                    b.HasOne("Gastos_BackEnd.Repository.Entity.Categorium", "CategorialdNavigation")
                        .WithMany("Gastos")
                        .HasForeignKey("Categoriald")
                        .IsRequired()
                        .HasConstraintName("FK__Gasto__Categoria__35BCFE0A");

                    b.HasOne("Gastos_BackEnd.Repository.Entity.Persona", "PersonaldNavigation")
                        .WithMany("Gastos")
                        .HasForeignKey("Personald")
                        .IsRequired()
                        .HasConstraintName("FK__Gasto__Personald__34C8D9D1");

                    b.HasOne("Gastos_BackEnd.Repository.Entity.TipoGasto", "TipoGastoldNavigation")
                        .WithMany("Gastos")
                        .HasForeignKey("TipoGastold")
                        .IsRequired()
                        .HasConstraintName("FK__Gasto__TipoGasto__36B12243");

                    b.Navigation("CategorialdNavigation");

                    b.Navigation("PersonaldNavigation");

                    b.Navigation("TipoGastoldNavigation");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.IngresoPorPersona", b =>
                {
                    b.HasOne("Gastos_BackEnd.Repository.Entity.Ingreso", "IngresoldNavigation")
                        .WithMany()
                        .HasForeignKey("Ingresold")
                        .IsRequired()
                        .HasConstraintName("FK__IngresoPo__Ingre__45F365D3");

                    b.HasOne("Gastos_BackEnd.Repository.Entity.Persona", "PersonaldNavigation")
                        .WithMany()
                        .HasForeignKey("Personald")
                        .IsRequired()
                        .HasConstraintName("FK__IngresoPo__Perso__46E78A0C");

                    b.Navigation("IngresoldNavigation");

                    b.Navigation("PersonaldNavigation");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Movimiento", b =>
                {
                    b.HasOne("Gastos_BackEnd.Repository.Entity.Gasto", "Gasto")
                        .WithMany("Movimientos")
                        .HasForeignKey("GastoId")
                        .IsRequired()
                        .HasConstraintName("FK__Movimient__Gasto__3B75D760");

                    b.Navigation("Gasto");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Periodo", b =>
                {
                    b.HasOne("Gastos_BackEnd.Repository.Entity.Tarjetum", "Tarjeta")
                        .WithMany()
                        .HasForeignKey("TarjetaId");

                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.PeriodoPorGasto", b =>
                {
                    b.HasOne("Gastos_BackEnd.Repository.Entity.Gasto", "Gasto")
                        .WithMany()
                        .HasForeignKey("GastoId")
                        .IsRequired()
                        .HasConstraintName("FK__PeriodoPo__Gasto__440B1D61");

                    b.HasOne("Gastos_BackEnd.Repository.Entity.Periodo", "PeriodoldNavigation")
                        .WithMany()
                        .HasForeignKey("Periodold")
                        .IsRequired()
                        .HasConstraintName("FK__PeriodoPo__Perio__4316F928");

                    b.Navigation("Gasto");

                    b.Navigation("PeriodoldNavigation");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.TarjetaPorPeriodo", b =>
                {
                    b.HasOne("Gastos_BackEnd.Repository.Entity.Gasto", "Gasto")
                        .WithMany()
                        .HasForeignKey("GastoId")
                        .IsRequired()
                        .HasConstraintName("FK_TarjetaPorPeriodo_Gasto");

                    b.HasOne("Gastos_BackEnd.Repository.Entity.Periodo", "PeriodoldNavigation")
                        .WithMany()
                        .HasForeignKey("Periodold")
                        .IsRequired()
                        .HasConstraintName("FK__TarjetaPo__Perio__412EB0B6");

                    b.HasOne("Gastos_BackEnd.Repository.Entity.Tarjetum", "Tarjeta")
                        .WithMany()
                        .HasForeignKey("TarjetaId")
                        .IsRequired()
                        .HasConstraintName("FK__TarjetaPo__Tarje__403A8C7D");

                    b.Navigation("Gasto");

                    b.Navigation("PeriodoldNavigation");

                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Categorium", b =>
                {
                    b.Navigation("Gastos");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Gasto", b =>
                {
                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Persona", b =>
                {
                    b.Navigation("Gastos");

                    b.Navigation("PersonaPorTarjeta");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.Tarjetum", b =>
                {
                    b.Navigation("PersonaPorTarjeta");
                });

            modelBuilder.Entity("Gastos_BackEnd.Repository.Entity.TipoGasto", b =>
                {
                    b.Navigation("Gastos");
                });
#pragma warning restore 612, 618
        }
    }
}