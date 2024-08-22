using MediatR;
using Microsoft.AspNetCore.Mvc;
using Talabeyah.Application.Common.Dtos;
using Talabeyah.Application.Common.Helper;
using Talabeyah.Application.Features.Tickets.Commands.AddTicket;
using Talabeyah.Application.Features.Tickets.HandleTicket;
using Talabeyah.Application.Features.Tickets.Queries.GetTicketByID;
using Talabeyah.Application.Features.Tickets.Queries.GetTickets;

namespace Talabeyah.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // 1. Get a paginated list of tickets
        [HttpGet]
        public async Task<ActionResult<PaginatedList<TicketDto>>> GetTickets([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetTicketsQuery { PageNumber = pageNumber, PageSize = pageSize };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // 2. Create a new ticket
        [HttpPost]
        public async Task<ActionResult<int>> CreateTicket([FromBody] AddTicketCommand command)
        {
            var ticketId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTicketById), new { id = ticketId }, ticketId);
        }

        // 3. Get a ticket by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetTicketById(int id)
        {
            var query = new GetTicketByIdQuery { TicketId = id };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // 4. Handle a ticket (mark it as handled)
        [HttpPut("{id}/handle")]
        public async Task<ActionResult> HandleTicket(int id)
        {
            var command = new HandleTicketCommand { TicketId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
