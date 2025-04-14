using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public Role Role { get; set; } = Role.Customer;

        public ICollection<Ticket>? Tickets { get; set; }
        // public ICollection<Evaluation>? Evaluations { get; set; }
    }
}
