using EVM.Application.Interfaces.Repositories;
using EVM.Application.Interfaces.Services;
using EVM.Application.Services;
using EVM.Infrastructure.Repositories;

namespace EVM.API.Configurations
{
    public static class ServicesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IEventLogRepository, EventLogRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventLogService, EventLogService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<ICateringService, CateringService>();
        }

    }
}
