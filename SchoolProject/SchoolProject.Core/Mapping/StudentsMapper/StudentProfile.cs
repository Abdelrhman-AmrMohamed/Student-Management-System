using AutoMapper;

namespace SchoolProject.Core.Mapping.StudentsMapper
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            StudentByIDQueryMapping();
            AddStudentCommandMapping();
            EditStudentCommandMapping();
        }

    }
}
