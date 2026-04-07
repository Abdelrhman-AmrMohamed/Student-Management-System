using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Queries.Models
{
    public class GetStudentListQuery:IRequest<Response<List<GetStudentListQueryDTO>>>
    {
    }
}
