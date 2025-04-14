using EVM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Domain.Entities
{
    public class Client : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid Salt { get; set; }
        public string? PhoneNumber { get; set; } = null!;
        public Role Role { get; set; } = Role.Client;
        
        public ICollection<Event>? Events { get; set; }
    }
}
