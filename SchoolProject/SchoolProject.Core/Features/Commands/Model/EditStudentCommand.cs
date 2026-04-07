using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Commands.Model
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DeptID { get; set; }
    }
}
