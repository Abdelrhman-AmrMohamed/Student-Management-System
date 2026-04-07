using FluentValidation;
using SchoolProject.Core.Features.Commands.Model;
using SchoolProject.Service.Interface;

namespace SchoolProject.Core.Features.Commands.Validators
{
    public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
    {


        #region Fields
        IStudentService _studentService;
        #endregion
        #region Constructors
        public EditStudentCommandValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationsRules();
            ApplyValidationCustomRules();
        }

        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Can't Be Empty").
                NotNull().WithMessage("Name Can't Be NULL").
                MaximumLength(200).WithMessage("Maximum Length Must Be 20");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address Can't Be Empty").
                NotNull().WithMessage("Address Can't Be NULL").
                MaximumLength(200).WithMessage("Maximum Length Must Be 20");
        }
        public async void ApplyValidationCustomRules()
        {
            RuleFor(x => x.Name).MustAsync(async (request, name, CancellationToken) =>
            {
                var exist = await _studentService.IsNameExistAndNotSameIdAsync(name, request.id);
                return !exist;
            }).WithMessage("Name already exists");
        }
        #endregion
    }
}
