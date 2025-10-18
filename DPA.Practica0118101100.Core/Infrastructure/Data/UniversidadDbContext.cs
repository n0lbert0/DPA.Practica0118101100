using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DPA.Practica0118101100.Core.Infrastructure.Data;

public partial class UniversidadDbContext : DbContext
{
    public UniversidadDbContext()
    {
    }

    public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carrera { get; set; }

    public virtual DbSet<Estudiante> Estudiante { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=UniversidadDB;User=sa;Pwd=123456789;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrera__3214EC07EC2AD38A");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC0784A5516E");

            entity.HasIndex(e => e.Correo, "IX_Estudiante_Correo");

            entity.HasIndex(e => e.Correo, "UQ__Estudian__60695A1995C35B93").IsUnique();

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Materno).HasMaxLength(50);
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Paterno).HasMaxLength(50);

            entity.HasOne(d => d.Carrera).WithMany(p => p.Estudiante)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estudiante_Carrera");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
