using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Queries.Handlers
{
    public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListQueryDTO>>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        #endregion
        #region Constructor
        public StudentHandler(IStudentService studentService, IMapper mapper, IMemoryCache cache)
        {
            _cache = cache;
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        #region HandleFucntion
        public async Task<Response<List<GetStudentListQueryDTO>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {

            if (_cache.TryGetValue(CacheKeys.GetStudentList, out List<GetStudentListQueryDTO> cachestudentlist))
                return Success(cachestudentlist);
            var StudentList = await _studentService.GetListStudentAsync();
            var StudentListMapper = _mapper.Map<List<GetStudentListQueryDTO>>(StudentList);
            _cache.Set(CacheKeys.GetStudentList, StudentListMapper, TimeSpan.FromMinutes(10));
            return Success(StudentListMapper);
        }
        #endregion
    }
}
