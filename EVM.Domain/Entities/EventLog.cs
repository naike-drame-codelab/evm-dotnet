using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    public class EventLog
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public EventType EventType { get; set; }
        public string Source { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? DetailsJson { get; set; }

        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
