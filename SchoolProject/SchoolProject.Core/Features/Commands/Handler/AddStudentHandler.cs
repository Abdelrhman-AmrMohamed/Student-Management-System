using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Commands.Model;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Commands.Handler
{
    public class AddStudentHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>,
                                                      IRequestHandler<EditStudentCommand, Response<string>>,
                                                      IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        IStudentService _studentService;
        IMapper _mapper;
        #endregion
        #region Constructors
        public AddStudentHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region HandleFunctions 
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //map between request and student
            var studentmapper = _mapper.Map<Students>(request);
            //add
            var result = await _studentService.AddStudentAsync(studentmapper);
            //check condition //return response 
            if (result == "Success") return Created<string>("Added Successfully");
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check if it null 
            var result = await _studentService.GetStudentByIDAsync(request.id);
            if (result == null) return NotFound<string>("Student not found");
            //if not map it
            var studentMapper = _mapper.Map<Students>(request);
            //calling service
            var finalresult = await _studentService.EditStudentAsync(studentMapper);
            if (finalresult == "Success") return Created<string>("Edited Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _studentService.GetStudentByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Student not found");
            var student = await _studentService.DeleteStudentAsync(result);
            if (student == "Deleted") return Success<string>("Deleted Success");
            else return BadRequest<string>();
        }

        #endregion

    }
}
