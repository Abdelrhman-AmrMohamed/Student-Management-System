using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.DTO;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Service.Interface;
using System.Text.Json;

namespace SchoolProject.Core.Features.Queries.Handlers
{
    public class DepartmentListHandler : ResponseHandler, IRequestHandler<GetDepartmentListQuery, Response<List<GetDepartmentListQueryDTO>>>
    {
        #region Fields
        private readonly IDepartmentService _DepartmentService;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        #endregion
        #region Constructor
        public DepartmentListHandler(IDepartmentService departmentService, IMapper mapper, IDistributedCache cache)
        {
            _cache = cache;
            _DepartmentService = departmentService;
            _mapper = mapper;
        }
        #endregion
        #region HandleFucntion

        public async Task<Response<List<GetDepartmentListQueryDTO>>> Handle(
       GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var cahceingdata = await _cache.GetStringAsync("GetDepartmentList");
            if (cahceingdata != null)
            {
                var data = JsonSerializer.Deserialize<List<GetDepartmentListQueryDTO>>(cahceingdata);
                return Success(data);
            }
            var departmentList = await _DepartmentService.GetListDepartmentAsync();
            var deparMapper = _mapper.Map<List<GetDepartmentListQueryDTO>>(departmentList);
            var cachingdataintoredis = JsonSerializer.Serialize(deparMapper);
            await _cache.SetStringAsync("GetDepartmentList", cachingdataintoredis,
       new DistributedCacheEntryOptions
       {
           AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
       });
            return Success(deparMapper);
        }
        #endregion
    }
}
