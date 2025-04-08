using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Domain.Entities
{
    public class Client : User
    {
        public ICollection<Event>? Events { get; set; }
    }
}
