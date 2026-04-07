using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Queries.Handlers
{
    public class DepartmentListHandler : ResponseHandler, IRequestHandler<GetDepartmentListQuery, Response<List<GetDepartmentListQueryDTO>>>
    {
        #region Fields
        private readonly IDepartmentService _DepartmentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public DepartmentListHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _DepartmentService = departmentService;
            _mapper = mapper;
        }
        #endregion
        #region HandleFucntion

        public async Task<Response<List<GetDepartmentListQueryDTO>>> Handle(
       GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departmentList = await _DepartmentService.GetListDepartmentAsync();
            var deparMapper = _mapper.Map<List<GetDepartmentListQueryDTO>>(departmentList);
            return Success(deparMapper);
        }
        #endregion
    }
}
