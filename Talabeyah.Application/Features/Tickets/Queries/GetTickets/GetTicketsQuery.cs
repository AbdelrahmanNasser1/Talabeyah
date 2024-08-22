using MediatR;
using Talabeyah.Application.Common.Dtos;
using Talabeyah.Application.Common.Helper;

namespace Talabeyah.Application.Features.Tickets.Queries.GetTickets
{
    public class GetTicketsQuery : IRequest<PaginatedList<TicketDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
