using EVM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Interfaces.Services
{
    public interface ITicketService
    {
        public Task<bool> IsTicketAvailable(Guid eventId, TicketType ticketType, int quantity);
    }
}
