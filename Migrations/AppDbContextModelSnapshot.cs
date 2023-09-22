﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareControle.Context;

#nullable disable

namespace SosftwareControle2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoftwareControle.Models.Administrador", b =>
                {
                    b.Property<int>("AdministradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdministradorId"));

                    b.Property<int?>("RelatorioId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("AdministradorId");

                    b.HasIndex("RelatorioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Admnistradores");
                });

            modelBuilder.Entity("SoftwareControle.Models.CriarOrdem", b =>
                {
                    b.Property<int>("CriarOrdemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CriarOrdemId"));

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FerramentaId")
                        .HasColumnType("int");

                    b.Property<int>("NivelUrgencia")
                        .HasColumnType("int");

                    b.Property<DateTime>("PrazoMaximo")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RelatorioId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CriarOrdemId");

                    b.HasIndex("FerramentaId");

                    b.HasIndex("RelatorioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CriarOrdem");
                });

            modelBuilder.Entity("SoftwareControle.Models.Ferramenta", b =>
                {
                    b.Property<int>("FerramentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FerramentaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RelatorioId")
                        .HasColumnType("int");

                    b.HasKey("FerramentaId");

                    b.HasIndex("RelatorioId");

                    b.ToTable("Ferramentas");
                });

            modelBuilder.Entity("SoftwareControle.Models.OrdensFeitas", b =>
                {
                    b.Property<int>("OrdensFeitasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdensFeitasId"));

                    b.Property<int>("CriarOrdemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FerramentaId")
                        .HasColumnType("int");

                    b.Property<int?>("RelatorioId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("OrdensFeitasId");

                    b.HasIndex("CriarOrdemId");

                    b.HasIndex("FerramentaId");

                    b.HasIndex("RelatorioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("OrdensFeitas");
                });

            modelBuilder.Entity("SoftwareControle.Models.Relatorio", b =>
                {
                    b.Property<int>("RelatorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RelatorioId"));

                    b.HasKey("RelatorioId");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("SoftwareControle.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<bool>("IsAdministrador")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RelatorioId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RelatorioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SoftwareControle.Models.Administrador", b =>
                {
                    b.HasOne("SoftwareControle.Models.Relatorio", null)
                        .WithMany("Administradores")
                        .HasForeignKey("RelatorioId");

                    b.HasOne("SoftwareControle.Models.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SoftwareControle.Models.CriarOrdem", b =>
                {
                    b.HasOne("SoftwareControle.Models.Ferramenta", "Ferramenta")
                        .WithMany("CriarOrdens")
                        .HasForeignKey("FerramentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareControle.Models.Relatorio", null)
                        .WithMany("CriarOrdens")
                        .HasForeignKey("RelatorioId");

                    b.HasOne("SoftwareControle.Models.Usuarios", "Usuario")
                        .WithMany("CriarOrdens")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ferramenta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SoftwareControle.Models.Ferramenta", b =>
                {
                    b.HasOne("SoftwareControle.Models.Relatorio", null)
                        .WithMany("Ferramentas")
                        .HasForeignKey("RelatorioId");
                });

            modelBuilder.Entity("SoftwareControle.Models.OrdensFeitas", b =>
                {
                    b.HasOne("SoftwareControle.Models.CriarOrdem", "CriarOrdem")
                        .WithMany("OrdensFeitas")
                        .HasForeignKey("CriarOrdemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareControle.Models.Ferramenta", "Ferramenta")
                        .WithMany()
                        .HasForeignKey("FerramentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareControle.Models.Relatorio", null)
                        .WithMany("OrdensFeitas")
                        .HasForeignKey("RelatorioId");

                    b.HasOne("SoftwareControle.Models.Usuarios", "Usuario")
                        .WithMany("OrdensFeitas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CriarOrdem");

                    b.Navigation("Ferramenta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SoftwareControle.Models.Usuarios", b =>
                {
                    b.HasOne("SoftwareControle.Models.Relatorio", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("RelatorioId");
                });

            modelBuilder.Entity("SoftwareControle.Models.CriarOrdem", b =>
                {
                    b.Navigation("OrdensFeitas");
                });

            modelBuilder.Entity("SoftwareControle.Models.Ferramenta", b =>
                {
                    b.Navigation("CriarOrdens");
                });

            modelBuilder.Entity("SoftwareControle.Models.Relatorio", b =>
                {
                    b.Navigation("Administradores");

                    b.Navigation("CriarOrdens");

                    b.Navigation("Ferramentas");

                    b.Navigation("OrdensFeitas");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("SoftwareControle.Models.Usuarios", b =>
                {
                    b.Navigation("CriarOrdens");

                    b.Navigation("OrdensFeitas");
                });
#pragma warning restore 612, 618
        }
    }
}
