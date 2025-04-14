using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVM.Application.DTO;

namespace EVM.Application.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<LoginFormResultDTO> LoginAsync(LoginFormDTO dto);
        
    }
}
