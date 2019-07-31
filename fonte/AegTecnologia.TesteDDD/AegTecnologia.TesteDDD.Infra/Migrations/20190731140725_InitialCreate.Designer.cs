﻿// <auto-generated />
using AegTecnologia.TesteDDD.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AegTecnologia.TesteDDD.Infra.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20190731140725_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AegTecnologia.TesteDDD.Domain.Dominios.Contato", b =>
                {
                    b.Property<int>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade")
                        .HasMaxLength(150);

                    b.Property<string>("Email")
                        .HasMaxLength(150);

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .HasMaxLength(15);

                    b.Property<string>("UF")
                        .HasMaxLength(2);

                    b.HasKey("ContatoId");

                    b.ToTable("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}