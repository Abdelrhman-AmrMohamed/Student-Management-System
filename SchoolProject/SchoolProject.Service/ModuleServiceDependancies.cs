using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Interface;
using SchoolProject.Service.Repository;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependancies
    {
        public static IServiceCollection AddServiceDependancies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}

