using userRole.Repository.Implementation;
using userRole.Repository.Interface;
using userRole.Service.Implementation;
using userRole.Service.Interface;

namespace webApi
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}