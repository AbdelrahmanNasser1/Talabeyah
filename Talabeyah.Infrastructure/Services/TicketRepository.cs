using Microsoft.EntityFrameworkCore;
using Talabeyah.Application.Interfaces;
using Talabeyah.Domain.Entities;
using Talabeyah.Infrastructure.Context;

namespace Talabeyah.Infrastructure.Services
{
    public class TicketRepository : ITicketRepository
    {

        private readonly TicketDbContext _context;

        public TicketRepository(TicketDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(int pageNumber, int pageSize)
        {
            return await _context.Tickets
                .OrderByDescending(t => t.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Tickets.CountAsync();
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }
}
