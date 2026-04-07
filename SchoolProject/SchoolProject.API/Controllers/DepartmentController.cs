using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Queries.Models;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet("/Department/List")]
        public async Task<IActionResult> GetDepartmentList()
        {
            var response = await Mediator.Send(new GetDepartmentListQuery());
            return NewResult(response);
        }
    }
}
