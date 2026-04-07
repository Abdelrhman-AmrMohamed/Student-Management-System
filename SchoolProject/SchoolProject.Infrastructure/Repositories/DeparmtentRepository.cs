using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Repositories.Bases;

public class DepartmentRepository : GenericRepositoryAsync<Students>
{
    #region Fields
    private readonly DbSet<Departments> _Department;
    #endregion

    #region Constructors
    public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _Department = dbContext.Set<Departments>();
    }
    #endregion

    #region HandleFunctions
    #endregion
}