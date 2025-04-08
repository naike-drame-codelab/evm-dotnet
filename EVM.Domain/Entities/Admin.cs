using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Domain.Enums;

namespace EVM.Domain.Entities
{
    public class Admin : User
    {
        public string Permissions { get; set; } = "Full Access";

    }
}
