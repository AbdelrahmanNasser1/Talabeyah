using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talabeyah.Application.Interfaces;
using Talabeyah.Infrastructure.Context;
using Talabeyah.Infrastructure.Engines;
using Talabeyah.Infrastructure.Services;

namespace Talabeyah.Infrastructure
{
    public static class InfrastructureServiceRegisteration
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketDbContext>(opt =>
                                        opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddHostedService<HandleTicketsBackgroundService>();

            return services;
        }
    }
}
