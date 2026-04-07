using SchoolProject.Core.Features.Commands.Model;
using SchoolProject.Data.Entities;
namespace SchoolProject.Core.Mapping.StudentsMapper
{
    public partial class StudentProfile
    {
        public void EditStudentCommandMapping()
        {
            CreateMap<EditStudentCommand, Students>().ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DeptID))
                .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.id));
        }
    }
}
