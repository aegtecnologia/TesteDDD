using AegTecnologia.TesteDDD.Domain.Dominios;
using Microsoft.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AegTecnologia.TesteDDD.Infra.EF.Configurations;

namespace AegTecnologia.TesteDDD.Infra.EF
{
    //referencias: 
    //https://www.devmedia.com.br/entity-framework-core-criando-bases-de-dados-com-migrations/36776
    //https://medium.com/@speedforcerun/implementing-idesigntimedbcontextfactory-in-asp-net-core-2-0-2-1-3718bba6db84

    public class EFContext : DbContext
    {
        public EFContext() { }

        public EFContext(DbContextOptions<EFContext> opcoes)
            : base(opcoes)
        {

        }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("dbo");

            ConfiguraContato(modelBuilder);
        }

        private void ConfiguraContato(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contato>(e =>
            {
                e.ToTable("Contatos");
                e.HasKey(p => p.ContatoId);
                e.Property(p => p.ContatoId).ValueGeneratedOnAdd();
                e.Property(p => p.PrimeiroNome).HasMaxLength(50).IsRequired();
                e.Property(p => p.NomeCompleto).HasMaxLength(150).IsRequired();
                e.Property(p => p.Email).HasMaxLength(150);
                e.Property(p => p.Telefone).HasMaxLength(15);
                e.Property(p => p.Cidade).HasMaxLength(150);
                e.Property(p => p.UF).HasMaxLength(2);            
            });

        }

    }


}
