using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Gastos_BackEnd.Repository.Entity;

public partial class GastosDbContext : DbContext
{
    public GastosDbContext()
    {
    }

    public GastosDbContext(DbContextOptions<GastosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<IngresoPorPersona> IngresoPorPersonas { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Periodo> Periodos { get; set; }

    public virtual DbSet<PeriodoPorGasto> PeriodoPorGastos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<TarjetaPorPeriodo> TarjetaPorPeriodos { get; set; }

    public virtual DbSet<Tarjetum> Tarjeta { get; set; }

    public virtual DbSet<TipoGasto> TipoGastos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GastosDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Categoriald).HasName("PK__Categori__F35292A991230A17");

            entity.Property(e => e.Categoriald).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gasto>(entity =>
        {
            entity.HasKey(e => e.GastoId).HasName("PK__Gasto__815BB0F042970835");

            entity.ToTable("Gasto");

            entity.Property(e => e.GastoId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NombreGasto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CategorialdNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.Categoriald)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Gasto__Categoria__35BCFE0A");

            entity.HasOne(d => d.PersonaldNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.Personald)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Gasto__Personald__34C8D9D1");

            entity.HasOne(d => d.Tarjeta).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.TarjetaId)
                .HasConstraintName("FK__Gasto__TarjetaId__37A5467C");

            entity.HasOne(d => d.TipoGastoldNavigation).WithMany(p => p.Gastos)
                .HasForeignKey(d => d.TipoGastold)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Gasto__TipoGasto__36B12243");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.Ingresold).HasName("PK__Ingreso__DBF5AF368BA5BEE0");

            entity.ToTable("Ingreso");

            entity.Property(e => e.Ingresold).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<IngresoPorPersona>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("IngresoPorPersona");

            entity.HasOne(d => d.IngresoldNavigation).WithMany()
                .HasForeignKey(d => d.Ingresold)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IngresoPo__Ingre__45F365D3");

            entity.HasOne(d => d.PersonaldNavigation).WithMany()
                .HasForeignKey(d => d.Personald)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__IngresoPo__Perso__46E78A0C");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Movimientold).HasName("PK__Movimien__BF912077B5AA5E24");

            entity.ToTable("Movimiento");

            entity.Property(e => e.Movimientold).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Gasto).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.GastoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Gasto__3B75D760");
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.HasKey(e => e.Periodold).HasName("PK__Periodo__0ADCD0AC013116D5");

            entity.ToTable("Periodo");

            entity.Property(e => e.Periodold).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Tarjeta).WithMany(p => p.Periodos)
                .HasForeignKey(d => d.TarjetaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Periodo__Tarjeta__2E1BDC42");
        });

        modelBuilder.Entity<PeriodoPorGasto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PeriodoPorGasto");

            entity.HasOne(d => d.Gasto).WithMany()
                .HasForeignKey(d => d.GastoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PeriodoPo__Gasto__440B1D61");

            entity.HasOne(d => d.PeriodoldNavigation).WithMany()
                .HasForeignKey(d => d.Periodold)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PeriodoPo__Perio__4316F928");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Personald).HasName("PK__Persona__7C35C71847E88CC5");

            entity.ToTable("Persona");

            entity.Property(e => e.Personald).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TarjetaPorPeriodo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TarjetaPorPeriodo");

            entity.Property(e => e.TarjetaId).HasColumnName("TarjetaId ");

            entity.HasOne(d => d.PeriodoldNavigation).WithMany()
                .HasForeignKey(d => d.Periodold)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TarjetaPo__Perio__412EB0B6");

            entity.HasOne(d => d.Tarjeta).WithMany()
                .HasForeignKey(d => d.TarjetaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TarjetaPo__Tarje__403A8C7D");
        });

        modelBuilder.Entity<Tarjetum>(entity =>
        {
            entity.HasKey(e => e.TarjetaId).HasName("PK__Tarjeta__C8250776213C208B");

            entity.Property(e => e.TarjetaId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoGasto>(entity =>
        {
            entity.HasKey(e => e.TipoGastold).HasName("PK__TipoGast__C00FC16A74B21049");

            entity.ToTable("TipoGasto");

            entity.Property(e => e.TipoGastold).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
