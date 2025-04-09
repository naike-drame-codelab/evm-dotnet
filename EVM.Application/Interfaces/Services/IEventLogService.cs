using EVM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Interfaces.Services
{
    public interface IEventLogService
    {
        Task LogEventAsync(int clientId, EventType eventType, string source, string message, object? details = null);
    }
}
