using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Repositories.Bases;

public interface IStudentRepositories : IGenericRepositoryAsync<Students>
{
    Task<List<Students>> GetStudentListAsync();
}