using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Interface
{
    public interface IDepartmentService
    {
        public Task<List<Departments>> GetListDepartmentAsync();

    }
}
