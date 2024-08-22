using Talabeyah.Domain.Entities;

namespace Talabeyah.Application.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> GetByIdAsync(int id);
        Task<IEnumerable<Ticket>> GetTicketsAsync(int pageNumber, int pageSize);
        Task<int> GetTotalCountAsync();
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
    }
}
