using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Entities;
using EVM.Domain.Enums;

namespace EVM.Application.DTO
{
    public record class LoginFormResultDTO(IUser u)
    {
        public int Id { get; set; } = u.Id;
        public string Name { get; set; } = u is Client client ? client.Name : "Admin";
        public string Email { get; set; } = u.Email;
        public Role Role { get; set; } = u.Role;

    }
}
