using EVM.Application.Interfaces.Repositories;
using EVM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Infrastructure.Repositories
{
    internal class TicketRepository(EventVenueManagerContext ctx) : RepositoryBase<Ticket>(ctx), ITicketRepository
    {
    }
}
