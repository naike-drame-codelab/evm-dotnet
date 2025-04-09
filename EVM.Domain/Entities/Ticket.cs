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
        public Guid Id { get; set; }
        public TicketType Type { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvailable { get; set; }
        public int QuantitySold { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsUsed { get; set; }

        public Guid EventId { get; set; }
        public Event? Event { get; set; }

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
