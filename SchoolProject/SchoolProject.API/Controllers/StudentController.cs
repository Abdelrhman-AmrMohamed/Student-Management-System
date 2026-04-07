using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Commands.Model;
using SchoolProject.Core.Features.Queries.Models;
namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {

        [HttpGet("/Student/List")]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }
        [HttpGet("/Student/ByID")]
        public async Task<IActionResult> GetStudentByID(int id)
        {
            var response = await Mediator.Send(new GetStudentByIDQuery(id));
            return NewResult(response);
        }
        [HttpPost("/Add/Student")]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand StudentFromRequest)
        {
            var response = await Mediator.Send(StudentFromRequest);
            return NewResult(response);
        }
        [HttpPut("/Edit/Student /{id}")]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand StudentFromRequest)
        {
            var response = await Mediator.Send(StudentFromRequest);
            return NewResult(response);
        }
        [HttpDelete("/Edit/Student/{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}
