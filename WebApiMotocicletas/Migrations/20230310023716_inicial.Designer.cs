﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiMotocicletas;

#nullable disable

namespace WebApiMotocicletas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230310023716_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApiMotocicletas.Entidades.motocicletas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("modeloId")
                        .HasColumnType("int");

                    b.Property<int>("proveedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Motocicletas");
                });

            modelBuilder.Entity("WebApiMotocicletas.Entidades.proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MotocicletasId")
                        .HasColumnType("int");

                    b.Property<string>("RFC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("motos_disponibles")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MotocicletasId");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("WebApiMotocicletas.Entidades.proveedor", b =>
                {
                    b.HasOne("WebApiMotocicletas.Entidades.motocicletas", "motocicletas")
                        .WithMany("proveedor")
                        .HasForeignKey("MotocicletasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("motocicletas");
                });

            modelBuilder.Entity("WebApiMotocicletas.Entidades.motocicletas", b =>
                {
                    b.Navigation("proveedor");
                });
#pragma warning restore 612, 618
        }
    }
}
