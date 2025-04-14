using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Interfaces.Security
{
    public interface ITokenManager
    {
        public string CreateToken(int id, string email, string role);
    }
}
