using FluentValidation;
using Sprout.Exam.Common.DataTransferObjects;

namespace Sprout.Exam.WebApp.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.Tin).NotEmpty();
            RuleFor(x => x.Birthdate).NotEmpty();
            RuleFor(x => x.TypeId).NotEmpty();
        }
    }
}
