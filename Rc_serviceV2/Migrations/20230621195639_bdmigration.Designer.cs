﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rc_serviceV2.Models;

#nullable disable

namespace Rc_serviceV2.Migrations
{
    [DbContext(typeof(Rc_serviceContext))]
    [Migration("20230621195639_bdmigration")]
    partial class bdmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Rc_serviceV2.Models.Contratacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EstadosId")
                        .HasColumnType("int")
                        .HasColumnName("Estados_Id");

                    b.Property<int?>("OfertasIdOfertas")
                        .HasColumnType("int")
                        .HasColumnName("Ofertas_Id_Ofertas");

                    b.HasKey("Id");

                    b.HasIndex("EstadosId");

                    b.HasIndex("OfertasIdOfertas");

                    b.ToTable("Contratacion", (string)null);
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TipoEstado")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Tipo_Estado");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Inmueble", b =>
                {
                    b.Property<int>("IdInmueble")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Inmueble");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInmueble"), 1L, 1);

                    b.Property<string>("DetallesInmueble")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Detalles_Inmueble");

                    b.Property<string>("PropietariosIdPropietario")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Propietarios_Id_Propietario");

                    b.Property<string>("TipoInmueble")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Tipo_Inmueble");

                    b.Property<string>("UbicacionId")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Ubicacion_Id");

                    b.HasKey("IdInmueble")
                        .HasName("PK__Inmueble__DB51280D52C0DB2F");

                    b.HasIndex("PropietariosIdPropietario");

                    b.ToTable("Inmuebles");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Logeo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contraseña")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Usuario")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Logeo", (string)null);
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Oferta", b =>
                {
                    b.Property<int>("IdOfertas")
                        .HasColumnType("int")
                        .HasColumnName("Id_Ofertas");

                    b.Property<int?>("InmueblesIdInmueble")
                        .HasColumnType("int")
                        .HasColumnName("Inmuebles_Id_Inmueble");

                    b.Property<int?>("ServiciosIdServicio")
                        .HasColumnType("int")
                        .HasColumnName("Servicios_Id_Servicio");

                    b.HasKey("IdOfertas")
                        .HasName("PK__Ofertas__C41D869B515051DE");

                    b.HasIndex("InmueblesIdInmueble");

                    b.HasIndex("ServiciosIdServicio");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.PrestadoresDeServicio", b =>
                {
                    b.Property<string>("IdPrestador")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Id_Prestador");

                    b.Property<string>("Celular")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastnamePrestador")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Lastname_Prestador");

                    b.Property<string>("NamePrestador")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Name_Prestador");

                    b.Property<int?>("ServiciosIdServicio")
                        .HasColumnType("int")
                        .HasColumnName("Servicios_Id_Servicio");

                    b.Property<string>("UbicacionId")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Ubicacion_Id");

                    b.HasKey("IdPrestador")
                        .HasName("PK__Prestado__25950CC513D8503B");

                    b.HasIndex("ServiciosIdServicio");

                    b.ToTable("Prestadores_de_servicios", (string)null);
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Propietario", b =>
                {
                    b.Property<string>("IdPropietario")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Id_Propietario");

                    b.Property<string>("Celular")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastnamePropietario")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Lastname_Propietario");

                    b.Property<string>("NamePropietario")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Name_Propietario");

                    b.Property<string>("UbicacionId")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Ubicacion_Id");

                    b.HasKey("IdPropietario")
                        .HasName("PK__Propieta__7360E97DC02ECF4F");

                    b.ToTable("Propietarios");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Servicio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"), 1L, 1);

                    b.Property<string>("DetallesServicio")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Detalles_Servicio");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("TipoServicio")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Tipo_Servicio");

                    b.HasKey("IdServicio")
                        .HasName("PK__Servicio__5B1345F056719A2D");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Contratacion", b =>
                {
                    b.HasOne("Rc_serviceV2.Models.Estado", "Estados")
                        .WithMany("Contratacions")
                        .HasForeignKey("EstadosId")
                        .HasConstraintName("FK__Contratac__Estad__49C3F6B7");

                    b.HasOne("Rc_serviceV2.Models.Oferta", "OfertasIdOfertasNavigation")
                        .WithMany("Contratacions")
                        .HasForeignKey("OfertasIdOfertas")
                        .HasConstraintName("FK__Contratac__Ofert__48CFD27E");

                    b.Navigation("Estados");

                    b.Navigation("OfertasIdOfertasNavigation");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Inmueble", b =>
                {
                    b.HasOne("Rc_serviceV2.Models.Propietario", "PropietariosIdPropietarioNavigation")
                        .WithMany("Inmuebles")
                        .HasForeignKey("PropietariosIdPropietario")
                        .HasConstraintName("FK__Inmuebles__Propi__3B75D760");

                    b.Navigation("PropietariosIdPropietarioNavigation");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Oferta", b =>
                {
                    b.HasOne("Rc_serviceV2.Models.Inmueble", "InmueblesIdInmuebleNavigation")
                        .WithMany("Oferta")
                        .HasForeignKey("InmueblesIdInmueble")
                        .HasConstraintName("FK__Ofertas__Inmuebl__4316F928");

                    b.HasOne("Rc_serviceV2.Models.Servicio", "ServiciosIdServicioNavigation")
                        .WithMany("Oferta")
                        .HasForeignKey("ServiciosIdServicio")
                        .HasConstraintName("FK__Ofertas__Servici__440B1D61");

                    b.Navigation("InmueblesIdInmuebleNavigation");

                    b.Navigation("ServiciosIdServicioNavigation");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.PrestadoresDeServicio", b =>
                {
                    b.HasOne("Rc_serviceV2.Models.Servicio", "ServiciosIdServicioNavigation")
                        .WithMany("PrestadoresDeServicios")
                        .HasForeignKey("ServiciosIdServicio")
                        .HasConstraintName("FK__Prestador__Servi__403A8C7D");

                    b.Navigation("ServiciosIdServicioNavigation");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Estado", b =>
                {
                    b.Navigation("Contratacions");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Inmueble", b =>
                {
                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Oferta", b =>
                {
                    b.Navigation("Contratacions");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Propietario", b =>
                {
                    b.Navigation("Inmuebles");
                });

            modelBuilder.Entity("Rc_serviceV2.Models.Servicio", b =>
                {
                    b.Navigation("Oferta");

                    b.Navigation("PrestadoresDeServicios");
                });
#pragma warning restore 612, 618
        }
    }
}
