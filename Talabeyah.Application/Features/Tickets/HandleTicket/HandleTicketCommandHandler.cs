using MediatR;
using Talabeyah.Application.Interfaces;

namespace Talabeyah.Application.Features.Tickets.HandleTicket
{
    public class HandleTicketCommandHandler : IRequestHandler<HandleTicketCommand, Unit>
    {
        private readonly ITicketRepository _repository;

        public HandleTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(request.TicketId);

            if (ticket != null && !ticket.IsHandled)
            {
                ticket.IsHandled = true;
                await _repository.UpdateAsync(ticket);
            }

            return Unit.Value;
        }
    }
}