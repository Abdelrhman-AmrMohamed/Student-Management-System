using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interface;
using SchoolProject.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Queries.Handlers
{
    public class StudentHandler : ResponseHandler,IRequestHandler<GetStudentListQuery, Response<List<GetStudentListQueryDTO>>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public StudentHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        #region HandleFucntion
        public async Task <Response<List<GetStudentListQueryDTO>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var StudentList=await _studentService.GetListStudentAsync();
            var StudentListMapper = _mapper.Map<List<GetStudentListQueryDTO>>(StudentList);
            return Success(StudentListMapper);
        }
        #endregion
    }
}
