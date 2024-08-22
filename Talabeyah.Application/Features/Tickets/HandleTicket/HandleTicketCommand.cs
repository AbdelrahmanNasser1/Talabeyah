using MediatR;

namespace Talabeyah.Application.Features.Tickets.HandleTicket
{
    public class HandleTicketCommand : IRequest<Unit>
    {
        public int TicketId { get; set; }
    }
}
