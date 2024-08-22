using MediatR;
using Talabeyah.Application.Common.Dtos;
using Talabeyah.Application.Interfaces;

namespace Talabeyah.Application.Features.Tickets.Queries.GetTicketByID
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketDto>
    {
        private readonly ITicketRepository _repository;

        public GetTicketByIdQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(request.TicketId);

            if (ticket == null)
            {
                return null;
            }

            // Map by this and can Use AutoMapper
            var ticketDto = new TicketDto
            {
                Id = ticket.Id,
                CreatedAt = ticket.CreatedAt,
                PhoneNumber = ticket.PhoneNumber,
                Governorate = ticket.Governorate,
                City = ticket.City,
                District = ticket.District,
                IsHandled = ticket.IsHandled,
                StatusColor = CalculateStatusColor(ticket.CreatedAt)
            };

            return ticketDto;
        }
        private string CalculateStatusColor(DateTime createdAt)
        {
            var timeSinceCreation = DateTime.UtcNow - createdAt;
            if (timeSinceCreation.TotalMinutes >= 60) return "Red";
            if (timeSinceCreation.TotalMinutes >= 45) return "Blue";
            if (timeSinceCreation.TotalMinutes >= 30) return "Green";
            return "Yellow";
        }
    }
}