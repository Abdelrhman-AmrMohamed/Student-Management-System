using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Data.Entities;
namespace SchoolProject.Core.Mapping.StudentsMapper

{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Students, GetStudentListQueryDTO>().ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
