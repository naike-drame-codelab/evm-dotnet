using EVM.Application.Interfaces.Repositories;
using EVM.Application.Interfaces.Services;
using EVM.Domain.Enums;

namespace EVM.Application.Services
{
    public class TicketService(ITicketRepository ticketRepository) : ITicketService
    {
        public async Task<bool> IsTicketAvailable(Guid eventId, TicketType ticketType, int quantity)
        {
            var tickets = await ticketRepository.FindWhereAsync(t =>
                t.EventId == eventId && t.Type == ticketType);

            var ticket = tickets.FirstOrDefault();
            if (ticket == null)
            {
                throw new KeyNotFoundException($"No tickets of type {ticketType} found for event {eventId}.");
            }

            return ticket.QuantityAvailable - ticket.QuantitySold >= quantity;
        }

    }
}
