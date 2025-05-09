﻿using EVM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Domain.Entities
{
    public interface IUser
    {
        int Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        Guid Salt { get; set; }
        Role Role { get; set; }

    }
}
