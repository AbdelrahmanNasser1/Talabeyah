using Microsoft.EntityFrameworkCore;
using Talabeyah.Domain.Entities;


namespace Talabeyah.Infrastructure.Context
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options) : base(options) { }
        public DbSet<Ticket> Tickets { get; set; }

    }
}
