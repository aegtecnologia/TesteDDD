using AegTecnologia.TesteDDD.Infra.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Hangfire.Console;
using Microsoft.AspNetCore.Builder;

namespace AegTecnologia.TesteDDD.Infra.DI.Extensions
{
    public static class IServiceCollectionExtensions
    {

        public static IApplicationBuilder UseHangfireConfiguration(this IApplicationBuilder app)
        {
            app.UseHangfireServer();

            const string monitorPath = @"/monitor";
            app.UseHangfireDashboard(monitorPath);

            // Registra e configura a recorrência (https://crontab.guru)
            //RecurringJob.AddOrUpdate<ICalculoLimiteJobService>("calculo-limite", t => t.Register(null), cronExpression: "*/15 * * * *", timeZone: TimeZoneInfo.Local, queue: JobConstants.Queues.Automacao);
            //RecurringJob.AddOrUpdate<ICalculoConsumoJobService>("calculo-consumo", t => t.Register(null), cronExpression: "*/15 * * * *", timeZone: TimeZoneInfo.Local, queue: JobConstants.Queues.Automacao);
            //RecurringJob.AddOrUpdate<ICriticaConsumoJobService>("critica-consumo", t => t.Register(null), cronExpression: "*/15 * * * *", timeZone: TimeZoneInfo.Local, queue: JobConstants.Queues.Automacao);
            //RecurringJob.AddOrUpdate<IEfetivacaoPropostaJobService>("efetivacao-propostas", t => t.Register(null), cronExpression: "*/3 * * * *", timeZone: TimeZoneInfo.Local, queue: JobConstants.Queues.Automacao);
            //RecurringJob.AddOrUpdate<IDwJobService>("Job-DW", t => t.Register(null), cronExpression: "0 3 5 * *", timeZone: TimeZoneInfo.Local, queue: JobConstants.Queues.Automacao);

            return app;
        }

        public static IServiceCollection ConfigureHangfire(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            GlobalJobFilters.Filters.Add(new DisableConcurrentExecutionAttribute(timeoutInSeconds: 60));

            //var connectionString = "Data Source=(local);Initial Catalog=db_aegtecnologia;Integrated Security=True;MultipleActiveResultSets=True";

            services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));

            services.AddHangfire(x =>
            {
                x.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));
                x.UseConsole();
            });

            services.AddHangfireServer();

            return services;
        }
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
