using System.ComponentModel.DataAnnotations.Schema;

namespace EVM.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public required User Client { get; set; }

    }
}