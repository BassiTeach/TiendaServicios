﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaServicios.Api.Compra.Persistencia;

#nullable disable

namespace TiendaServicios.Api.Compra.Migrations
{
    [DbContext(typeof(CompraContexto))]
    [Migration("20250412195556_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("TiendaServicios.Api.Compra.Modelo.Carrito", b =>
                {
                    b.Property<int>("CarritoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CarritoId"));

                    b.Property<string>("CarritoGuid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CarritoId");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("TiendaServicios.Api.Compra.Modelo.CarritoDetalle", b =>
                {
                    b.Property<int>("CarritoDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CarritoDetalleId"));

                    b.Property<string>("CarritoDetalleGuid")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CarritoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProductSeleccionado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CarritoDetalleId");

                    b.HasIndex("CarritoId");

                    b.ToTable("CarritoDetalle");
                });

            modelBuilder.Entity("TiendaServicios.Api.Compra.Modelo.CarritoDetalle", b =>
                {
                    b.HasOne("TiendaServicios.Api.Compra.Modelo.Carrito", "Carrito")
                        .WithMany("ListaDetalleCompra")
                        .HasForeignKey("CarritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrito");
                });

            modelBuilder.Entity("TiendaServicios.Api.Compra.Modelo.Carrito", b =>
                {
                    b.Navigation("ListaDetalleCompra");
                });
#pragma warning restore 612, 618
        }
    }
}
