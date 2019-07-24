using AegTecnologia.TesteDDD.Domain.Dominios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AegTecnologia.TesteDDD.Infra.EF.Configurations
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contatos");

            builder.HasKey(e => e.ContatoId);

            builder.Property(e => e.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.NomeCompleto)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.PrimeiroNome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Telefone)
                .HasMaxLength(13)
                .IsRequired();

        }
    }
}
