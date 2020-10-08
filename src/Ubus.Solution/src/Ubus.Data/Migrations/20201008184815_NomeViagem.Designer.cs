﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ubus.Data.Context;

namespace Ubus.Data.Migrations
{
    [DbContext(typeof(UbusContext))]
    [Migration("20201008184815_NomeViagem")]
    partial class NomeViagem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ubus.Business.Models.AdicionalItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("AdicionalItens");
                });

            modelBuilder.Entity("Ubus.Business.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Itens");
                });

            modelBuilder.Entity("Ubus.Business.Models.Motorista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Motoristas");
                });

            modelBuilder.Entity("Ubus.Business.Models.MotoristaViagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MotoristaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ViagemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MotoristaId");

                    b.HasIndex("ViagemId");

                    b.ToTable("MotoristaViagens");
                });

            modelBuilder.Entity("Ubus.Business.Models.Rota", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Itinerario")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Rotas");
                });

            modelBuilder.Entity("Ubus.Business.Models.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Ubus.Business.Models.Viagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Chegada")
                        .HasColumnType("datetime");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("RotaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Saida")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RotaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Viagens");
                });

            modelBuilder.Entity("Ubus.Business.Models.AdicionalItem", b =>
                {
                    b.HasOne("Ubus.Business.Models.Item", "Item")
                        .WithMany("AdicionalItens")
                        .HasForeignKey("ItemId")
                        .IsRequired();

                    b.HasOne("Ubus.Business.Models.Veiculo", "Veiculo")
                        .WithMany("Adicionais")
                        .HasForeignKey("VeiculoId")
                        .IsRequired();
                });

            modelBuilder.Entity("Ubus.Business.Models.MotoristaViagem", b =>
                {
                    b.HasOne("Ubus.Business.Models.Motorista", "Motorista")
                        .WithMany()
                        .HasForeignKey("MotoristaId")
                        .IsRequired();

                    b.HasOne("Ubus.Business.Models.Viagem", "Viagem")
                        .WithMany()
                        .HasForeignKey("ViagemId")
                        .IsRequired();
                });

            modelBuilder.Entity("Ubus.Business.Models.Viagem", b =>
                {
                    b.HasOne("Ubus.Business.Models.Rota", "Rota")
                        .WithMany()
                        .HasForeignKey("RotaId")
                        .IsRequired();

                    b.HasOne("Ubus.Business.Models.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
