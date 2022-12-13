using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProgramacionFinal2.Models
{
    public partial class ProyectoFinalP2Context : DbContext
    {
        public ProyectoFinalP2Context()
        {
        }

        public ProyectoFinalP2Context(DbContextOptions<ProyectoFinalP2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Aula> Aulas { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Profesor> Profesors { get; set; } = null!;
        public virtual DbSet<Provincium> Provincia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__ALUMNO__460B4740F9190715");

                entity.ToTable("ALUMNO");

                entity.HasIndex(e => e.Matricula, "UQ__ALUMNO__0FB9FB4FA6561CEF")
                    .IsUnique();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("FK_Provincia");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK__AREA__2FC141AA26C6DC8D");

                entity.ToTable("AREA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.IdAula)
                    .HasName("PK__AULA__D861CCCB6159F95E");

                entity.ToTable("AULA");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__DEPARTAM__787A433D7182E74F");

                entity.ToTable("DEPARTAMENTO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__EMPLEADO__CE6D8B9E570613FD");

                entity.ToTable("EMPLEADO");

                entity.HasIndex(e => e.Codigo, "UQ__EMPLEADO__06370DACFCED814F")
                    .IsUnique();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK_Departamento");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("PK__PROFESOR__C377C3A1E40B8AFE");

                entity.ToTable("PROFESOR");

                entity.HasIndex(e => e.Codigo, "UQ__PROFESOR__06370DAC75C63BAF")
                    .IsUnique();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Profesors)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK_Area");
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__PROVINCI__EED7445550466BE9");

                entity.ToTable("PROVINCIA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
