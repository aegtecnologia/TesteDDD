using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AegTecnologia.TesteDDD.Infra.EF
{
    public class FabricaContexto : IDesignTimeDbContextFactory<EFContext>
    {
        private const string provider = @"Data Source=(local);Initial Catalog=db_aegtecnologia;Integrated Security=True;MultipleActiveResultSets=True";


        public EFContext CreateDbContext(string[] args)
        {
            var construtor = new DbContextOptionsBuilder<EFContext>();
            construtor.UseSqlServer(provider);
            return new EFContext(construtor.Options);
        }
    }
}
