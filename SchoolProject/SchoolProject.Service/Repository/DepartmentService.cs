using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interface;
namespace SchoolProject.Service.Repository
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        DepartmentRepository _Dept;
        #endregion
        #region Construcotrs
        public DepartmentService(DepartmentRepository dept)
        {
            _Dept = dept;
        }
        #endregion
        #region Handle Functions
        public async Task<List<Departments>> GetListDepartmentAsync()
        {
            var departments = await _Dept.GetTableNoTracking<Departments>().ToListAsync();
            return departments;
        }
        #endregion


    }
}
