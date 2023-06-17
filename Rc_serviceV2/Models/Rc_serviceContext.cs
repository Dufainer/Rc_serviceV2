using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rc_serviceV2.Models
{
    public partial class Rc_serviceContext : DbContext
    {
        public Rc_serviceContext()
        {
        }

        public Rc_serviceContext(DbContextOptions<Rc_serviceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contratacion> Contratacions { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Inmueble> Inmuebles { get; set; } = null!;
        public virtual DbSet<Logeo> Logeos { get; set; } = null!;
        public virtual DbSet<Oferta> Ofertas { get; set; } = null!;
        public virtual DbSet<PrestadoresDeServicio> PrestadoresDeServicios { get; set; } = null!;
        public virtual DbSet<Propietario> Propietarios { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=Rc_service;integrated security=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contratacion>(entity =>
            {
                entity.ToTable("Contratacion");

                entity.Property(e => e.EstadosId).HasColumnName("Estados_Id");

                entity.Property(e => e.OfertasIdOfertas).HasColumnName("Ofertas_Id_Ofertas");

                entity.HasOne(d => d.Estados)
                    .WithMany(p => p.Contratacions)
                    .HasForeignKey(d => d.EstadosId)
                    .HasConstraintName("FK__Contratac__Estad__49C3F6B7");

                entity.HasOne(d => d.OfertasIdOfertasNavigation)
                    .WithMany(p => p.Contratacions)
                    .HasForeignKey(d => d.OfertasIdOfertas)
                    .HasConstraintName("FK__Contratac__Ofert__48CFD27E");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.TipoEstado)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Estado");
            });

            modelBuilder.Entity<Inmueble>(entity =>
            {
                entity.HasKey(e => e.IdInmueble)
                    .HasName("PK__Inmueble__DB51280D52C0DB2F");

                entity.Property(e => e.IdInmueble).HasColumnName("Id_Inmueble");

                entity.Property(e => e.DetallesInmueble)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Detalles_Inmueble");

                entity.Property(e => e.PropietariosIdPropietario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Propietarios_Id_Propietario");

                entity.Property(e => e.TipoInmueble)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Inmueble");

                entity.Property(e => e.UbicacionId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Ubicacion_Id");

                entity.HasOne(d => d.PropietariosIdPropietarioNavigation)
                    .WithMany(p => p.Inmuebles)
                    .HasForeignKey(d => d.PropietariosIdPropietario)
                    .HasConstraintName("FK__Inmuebles__Propi__3B75D760");
            });

            modelBuilder.Entity<Logeo>(entity =>
            {
                entity.ToTable("Logeo");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.IdOfertas)
                    .HasName("PK__Ofertas__C41D869B515051DE");

                entity.Property(e => e.IdOfertas)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Ofertas");

                entity.Property(e => e.InmueblesIdInmueble).HasColumnName("Inmuebles_Id_Inmueble");

                entity.Property(e => e.ServiciosIdServicio).HasColumnName("Servicios_Id_Servicio");

                entity.HasOne(d => d.InmueblesIdInmuebleNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.InmueblesIdInmueble)
                    .HasConstraintName("FK__Ofertas__Inmuebl__4316F928");

                entity.HasOne(d => d.ServiciosIdServicioNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.ServiciosIdServicio)
                    .HasConstraintName("FK__Ofertas__Servici__440B1D61");
            });

            modelBuilder.Entity<PrestadoresDeServicio>(entity =>
            {
                entity.HasKey(e => e.IdPrestador)
                    .HasName("PK__Prestado__25950CC513D8503B");

                entity.ToTable("Prestadores_de_servicios");

                entity.Property(e => e.IdPrestador)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Id_Prestador");

                entity.Property(e => e.Celular)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastnamePrestador)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Lastname_Prestador");

                entity.Property(e => e.NamePrestador)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Name_Prestador");

                entity.Property(e => e.ServiciosIdServicio).HasColumnName("Servicios_Id_Servicio");

                entity.Property(e => e.UbicacionId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Ubicacion_Id");

                entity.HasOne(d => d.ServiciosIdServicioNavigation)
                    .WithMany(p => p.PrestadoresDeServicios)
                    .HasForeignKey(d => d.ServiciosIdServicio)
                    .HasConstraintName("FK__Prestador__Servi__403A8C7D");
            });

            modelBuilder.Entity<Propietario>(entity =>
            {
                entity.HasKey(e => e.IdPropietario)
                    .HasName("PK__Propieta__7360E97DC02ECF4F");

                entity.Property(e => e.IdPropietario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Id_Propietario");

                entity.Property(e => e.Celular)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastnamePropietario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Lastname_Propietario");

                entity.Property(e => e.NamePropietario)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Name_Propietario");

                entity.Property(e => e.UbicacionId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Ubicacion_Id");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__Servicio__5B1345F056719A2D");

                entity.Property(e => e.IdServicio).HasColumnName("Id_Servicio");

                entity.Property(e => e.DetallesServicio)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Detalles_Servicio");

                entity.Property(e => e.TipoServicio)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_Servicio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
