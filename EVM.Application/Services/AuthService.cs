using EVM.Application.DTO;
using EVM.Application.Interfaces.Repositories;
using EVM.Domain.Entities;

namespace EVM.Application.Services
{
    public class AuthService(IClientRepository clientRepository, IAdminRepository adminRepository)
    {
        public async Task<LoginFormResultDTO> LoginAsync(LoginFormDTO dto)
        {
            Client? client = await clientRepository.FindOneWhereAsync(c => (c.Email == dto.UsernameOrEmail || c.Name == dto.UsernameOrEmail) && c.Password == dto.Password);
            if (client != null)
            {
                return new LoginFormResultDTO(client);
            }

            Admin? admin = await adminRepository.FindOneWhereAsync(a => (a.Email == dto.UsernameOrEmail || a.Username == dto.UsernameOrEmail) && a.Password == dto.Password);
            if (admin != null)
            {
                return new LoginFormResultDTO(admin);
            }

            throw new UnauthorizedAccessException("Invalid email or password.");
        }
    }
}
