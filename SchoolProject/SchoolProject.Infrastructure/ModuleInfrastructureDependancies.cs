using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Repositories.Bases;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependancies
    {
        public static IServiceCollection AddInfrastructureDependancies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepositories, StudentRepository>();
            services.AddTransient<DepartmentRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
