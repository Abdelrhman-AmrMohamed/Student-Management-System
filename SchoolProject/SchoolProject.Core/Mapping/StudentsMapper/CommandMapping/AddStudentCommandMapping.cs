using AutoMapper;
using SchoolProject.Core.Features.Commands.Model;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolProject.Core.Mapping.StudentsMapper
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand, Students>().ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DeptID));
        }
    }
}
