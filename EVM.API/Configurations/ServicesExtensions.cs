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
            services.AddScoped<IEventLogRepository, EventLogRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventLogService, EventLogService>();
        }

    }
}
