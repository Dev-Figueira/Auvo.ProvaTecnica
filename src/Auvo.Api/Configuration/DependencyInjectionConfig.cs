using Auvo.Busness.Interfaces;
using Auvo.Busness.Notificacao;
using Auvo.Busness.Services;
using Auvo.Data.Context;
using Auvo.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Auvo.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AuvoDbContext>();
            services.AddScoped<IRegistroRepository, RegistroRepository>();
            services.AddScoped<IPontoRepository, PontoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IPontoService, ServicePonto>();
            services.AddScoped<IRegistroService, ServiceRegistro>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
