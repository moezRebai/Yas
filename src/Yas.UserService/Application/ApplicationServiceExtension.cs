using Yas.UserService.Application.Interfaces;
using Yas.UserService.Application.Providers;

namespace Yas.UserService.Application
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IUserProvider, UserProvicer>();
        }
    }
}
