using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Queries.Models
{
    public class GetStudentByIDQuery:IRequest<Response<GetStudentByIdQueryDTO>>
    {
        public int ID  { get; set; }
        public GetStudentByIDQuery(int id)
        {
            ID=id;
        }
    }
}
