using Microsoft.Extensions.DependencyInjection;
using Talabeyah.Application.Features.Tickets.Commands.AddTicket;
using Talabeyah.Application.Features.Tickets.HandleTicket;
using Talabeyah.Application.Features.Tickets.Queries.GetTickets;

namespace Talabeyah.Application
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AddTicketCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetTicketsQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(HandleTicketCommandHandler).Assembly));
            return services;
        }
    }
}
