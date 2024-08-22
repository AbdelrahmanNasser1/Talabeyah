using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Talabeyah.Infrastructure.Context;

namespace Talabeyah.Infrastructure.Engines
{
    public class HandleTicketsBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public HandleTicketsBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<TicketDbContext>();

                    var tickets = await context.Tickets
                        .Where(t => !t.IsHandled && DateTime.UtcNow - t.CreatedAt >= TimeSpan.FromMinutes(60))
                        .ToListAsync(stoppingToken);

                    foreach (var ticket in tickets)
                    {
                        ticket.IsHandled = true;
                    }

                    await context.SaveChangesAsync(stoppingToken);
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
