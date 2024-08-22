using MediatR;
using Talabeyah.Application.Common.Dtos;

namespace Talabeyah.Application.Features.Tickets.Queries.GetTicketByID
{
    public class GetTicketByIdQuery : IRequest<TicketDto>
    {
        public int TicketId { get; set; }
    }
}
