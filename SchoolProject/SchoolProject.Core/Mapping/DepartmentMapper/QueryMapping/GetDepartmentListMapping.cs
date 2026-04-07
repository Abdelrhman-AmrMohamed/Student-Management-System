using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Data.Entities;
namespace SchoolProject.Core.Mapping.DepartmentMapper
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentListMap()
        {
            CreateMap<Departments, GetDepartmentListQueryDTO>();

        }
    }
}
