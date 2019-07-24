using AegTecnologia.TesteDDD.Infra.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AegTecnologia.TesteDDD.Infra.DI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            var connectionString = "Data Source=(local);Initial Catalog=db_aegtecnologia;Integrated Security=True;MultipleActiveResultSets=True";

            // Registra o contexto do EFCore
            services.AddDbContext<EFContext>(options => options.UseSqlServer(connectionString));
            

            //// Registra o contexto do IdentityCore
            //services.AddIdentity<Usuario, IdentityRole>()
            //   .AddEntityFrameworkStores<EFContext>()
            //   .AddDefaultUI(UIFramework.Bootstrap4)
            //   .AddErrorDescriber<PortugueseIdentityErrorDescriber>()
            //   .AddDefaultTokenProviders();

            //services.AddTransient<IEmailSender, EmailSender>();
            //services.AddScoped<IUserClaimsPrincipalFactory<Usuario>, ClaimsIdentityFactory>();

            //// Registra as camadas lógicas da aplicação
            //services.Scan(scan => scan
            //    .FromAssemblies(Assembly.GetExecutingAssembly())
            //        .AddClasses(c => c.AssignableTo(typeof(IBaseRepository)))
            //            .AsImplementedInterfaces()
            //            .WithTransientLifetime()
            //        .AddClasses(c => c.AssignableTo(typeof(IValidator<>)))
            //            .AsImplementedInterfaces()
            //            .WithTransientLifetime()
            //        .AddClasses(c => c.AssignableTo(typeof(IBaseService)))
            //            .AsImplementedInterfaces()
            //            .WithTransientLifetime()
            //        .AddClasses(c => c.AssignableTo<IUnitOfWork>())
            //            .AsImplementedInterfaces()
            //            .WithTransientLifetime()
            //        .AddClasses(c => c.AssignableTo(typeof(IJobAdapter)))
            //            .AsImplementedInterfaces()
            //            .WithTransientLifetime()
            //        .AddClasses(c => c.AssignableTo(typeof(IJobService<,>)))
            //            .AsImplementedInterfaces()
            //            .WithTransientLifetime()
            //    );

            return services;
        }
    }
}
