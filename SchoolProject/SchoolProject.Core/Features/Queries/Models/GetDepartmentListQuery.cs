using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;

namespace SchoolProject.Core.Features.Queries.Models
{
    public class GetDepartmentListQuery : IRequest<Response<List<GetDepartmentListQueryDTO>>>
    {
    }
}
