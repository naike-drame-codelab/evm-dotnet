﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.DTO
{
    public class LoginFormDTO
    {
        [Required]
        [MinLength(1)]
        public string UsernameOrEmail { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
