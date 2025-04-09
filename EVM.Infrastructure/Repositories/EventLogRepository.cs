using EVM.Application.Interfaces.Repositories;
using EVM.Domain.Entities;

namespace EVM.Infrastructure.Repositories
{
    public class EventLogRepository(EventVenueManagerContext ctx) : RepositoryBase<EventLog>(ctx), IEventLogRepository
    {
    }
}
