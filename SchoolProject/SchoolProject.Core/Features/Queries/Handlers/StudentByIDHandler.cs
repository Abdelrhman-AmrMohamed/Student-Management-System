using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Queries.Handlers
{
    public class StudentByIDHandler : ResponseHandler, IRequestHandler<GetStudentByIDQuery, Response<GetStudentByIdQueryDTO>>
    {
        #region Fields
        IStudentService _studentService;
        IMapper _mapper;
        IMemoryCache _cahce;
        #endregion
        public StudentByIDHandler(IStudentService studentService, IMapper mapper, IMemoryCache cache)
        {
            _cahce = cache;
            _studentService = studentService;
            _mapper = mapper;
        }
        #region Constructors
        #endregion
        #region HandleFunctions
        public async Task<Response<GetStudentByIdQueryDTO>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            if (_cahce.TryGetValue(CacheKeys.GetStudentList, out List<GetStudentListQueryDTO> cachedstudents))
            {
                var cachedStudent = cachedstudents.FirstOrDefault(s => s.StudID == request.ID);
                if (cachedStudent != null)
                    return Success(_mapper.Map<GetStudentByIdQueryDTO>(cachedStudent));
            }
            var student = await _studentService.GetStudentByIDAsync(request.ID);
            if (student == null) return NotFound<GetStudentByIdQueryDTO>();
            var studentDTO = _mapper.Map<GetStudentByIdQueryDTO>(student);
            return Success(studentDTO);
        }
        #endregion
    }
}