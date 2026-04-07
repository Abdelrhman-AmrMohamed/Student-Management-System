using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Data.Entities;
using AutoMapper;
namespace SchoolProject.Core.Mapping.StudentsMapper
{
    public partial class StudentProfile
    {
        public void StudentByIDQueryMapping() 
        {
         CreateMap<Students,GetStudentByIdQueryDTO>().ForMember(dest=>dest.DepartmentName,opt=>opt.MapFrom(src=>src.Department.DName));
        }
    }
}
