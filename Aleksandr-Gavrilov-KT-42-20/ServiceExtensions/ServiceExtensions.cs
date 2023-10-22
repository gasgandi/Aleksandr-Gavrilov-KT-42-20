using Aleksandr_Gavrilov_KT_42_20.Interfaces.StudentsInterfaces;

namespace Aleksandr_Gavrilov_KT_42_20.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
