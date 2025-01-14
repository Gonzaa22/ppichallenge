﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PPIChallengeAPI.Conexion;

#nullable disable

namespace PPIChallengeAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PPIChallengeAPI.Models.Entities.Activo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precioUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ticker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoActivo")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Activos");
                });

            modelBuilder.Entity("PPIChallengeAPI.Models.Entities.Estado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcionEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("PPIChallengeAPI.Models.Entities.Orden", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("activoNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("cuentaID")
                        .HasColumnType("int");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<string>("estadoDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("montoTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("operacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("PPIChallengeAPI.Models.Entities.TipoActivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposActivo");
                });
#pragma warning restore 612, 618
        }
    }
}
