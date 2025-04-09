using EVM.Application.Interfaces.Repositories;
using EVM.Application.Interfaces.Services;
using EVM.Domain.Entities;
using EVM.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace EVM.Application.Services
{
    public class EventLogService(IEventLogRepository eventLogRepository, ILogger<EventLogService> logger) : IEventLogService
    {
        public async Task LogEventAsync(int clientId, EventType eventType, string source, string message, object? details = null)
        {
            try
            {
                EventLog logEntry = new EventLog
                {
                    ClientId = clientId,
                    Timestamp = DateTime.UtcNow,
                    EventType = eventType,
                    Source = source,
                    Message = message,
                    DetailsJson = details != null ? System.Text.Json.JsonSerializer.Serialize(details) : null
                };

                await eventLogRepository.AddAsync(logEntry);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error while trying to add the event log.");
            }
        }
    }
}
