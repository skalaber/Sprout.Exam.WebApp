using FluentValidation;
using Sprout.Exam.Common.DataTransferObjects;

namespace Sprout.Exam.WebApp.Validators
{
    public class EditEmployeeValidator : AbstractValidator<EditEmployeeDto>
    {
        public EditEmployeeValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Tin).NotEmpty();
            RuleFor(x => x.Birthdate).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
        }
    }
}
