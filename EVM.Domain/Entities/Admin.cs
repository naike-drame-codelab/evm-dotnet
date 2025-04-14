using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    public class Admin : IUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Role Role { get; set; }
        public Guid Salt { get; set; }
    }
}
