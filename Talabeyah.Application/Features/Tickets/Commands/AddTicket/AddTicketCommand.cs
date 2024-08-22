using MediatR;

namespace Talabeyah.Application.Features.Tickets.Commands.AddTicket
{
    public class AddTicketCommand : IRequest<int>
    {
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
