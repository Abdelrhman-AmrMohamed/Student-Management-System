using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Service.Interface;
using SchoolProject.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Queries.Handlers
{
    public class StudentByIDHandler : ResponseHandler, IRequestHandler<GetStudentByIDQuery, Response<GetStudentByIdQueryDTO>>
    {
        #region Fields
        IStudentService _studentService;
        IMapper _mapper;
        #endregion
        public StudentByIDHandler(IStudentService studentService,IMapper mapper)
        {
            
            _studentService = studentService;
            _mapper = mapper;
        }
        #region Constructors
        #endregion
        #region HandleFunctions
        public async Task<Response<GetStudentByIdQueryDTO>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student=await _studentService.GetStudentByIDAsync(request.ID);
            if (student == null) return NotFound<GetStudentByIdQueryDTO>();
            var studentDTO=_mapper.Map<GetStudentByIdQueryDTO>(student);
            return Success(studentDTO);
        }
        #endregion
    }
}