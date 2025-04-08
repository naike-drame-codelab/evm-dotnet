using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    public class Customer : User
    {
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Evaluation>? Evaluations { get; set; }
    }
}
