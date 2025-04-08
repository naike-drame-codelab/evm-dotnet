using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public TicketType Type { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public int QuantitySold { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public required Event Event { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; } // Nullable if ticket is created but not yet assigned
        public Customer? Customer { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public bool IsUsed { get; set; } = false;
    }
}
