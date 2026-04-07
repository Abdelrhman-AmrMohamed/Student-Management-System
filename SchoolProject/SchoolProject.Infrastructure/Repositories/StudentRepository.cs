using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Repositories.Bases;

public class StudentRepository : GenericRepositoryAsync<Students>, IStudentRepositories
{
    #region Fields
    private readonly DbSet<Students> _students;
    #endregion

    #region Constructors
    public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _students = dbContext.Set<Students>();
    }
    #endregion

    #region HandleFunctions
    public async Task<List<Students>> GetStudentListAsync()
    {
        return await _students.Include(x => x.Department).ToListAsync();
    }
    #endregion
}