using Talabeyah.Application.Common.Dtos;
using Talabeyah.Application.Common.Helper;
using Talabeyah.Application.Interfaces;

namespace Talabeyah.Application.Features.Tickets.Queries.GetTickets
{
    public class GetTicketsQueryHandler
    {
        private readonly ITicketRepository _repository;

        public GetTicketsQueryHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedList<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {

            var tickets = await _repository.GetTicketsAsync(request.PageNumber, request.PageSize);
            var totalCount = await _repository.GetTotalCountAsync();

            var ticketDtos = tickets.Select(t => new TicketDto
            {
                Id = t.Id,
                CreatedAt = t.CreatedAt,
                PhoneNumber = t.PhoneNumber,
                Governorate = t.Governorate,
                City = t.City,
                District = t.District,
                IsHandled = t.IsHandled,
                StatusColor = CalculateStatusColor(t.CreatedAt)
            }).ToList();

            return new PaginatedList<TicketDto>(ticketDtos, totalCount, request.PageNumber, request.PageSize);
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
