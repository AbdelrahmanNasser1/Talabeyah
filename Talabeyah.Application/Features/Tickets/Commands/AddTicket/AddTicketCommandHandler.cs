using MediatR;
using Talabeyah.Application.Interfaces;
using Talabeyah.Domain.Entities;

namespace Talabeyah.Application.Features.Tickets.Commands.AddTicket
{
    public class AddTicketCommandHandler : IRequestHandler<AddTicketCommand, int>
    {
        private readonly ITicketRepository _repository;
        public AddTicketCommandHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AddTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket
            {
                CreatedAt = DateTime.UtcNow,
                PhoneNumber = request.PhoneNumber,
                Governorate = request.Governorate,
                City = request.City,
                District = request.District,
                IsHandled = false
            };

            await _repository.AddAsync(ticket);
            return ticket.Id;
        }
    }
}
