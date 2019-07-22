using AegTecnologia.TesteDDD.Domain.Dominios;
using Microsoft.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AegTecnologia.TesteDDD.Infra.EF.Configurations;

namespace AegTecnologia.TesteDDD.Infra.EF
{
    //referencia: https://www.devmedia.com.br/entity-framework-core-criando-bases-de-dados-com-migrations/36776
    public class EFContext : DbContext
    {
        public EFContext() { }

        public EFContext(DbContextOptions<EFContext> opcoes)
            : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Contato>(new ContatoConfiguration());
        }

    }


}
