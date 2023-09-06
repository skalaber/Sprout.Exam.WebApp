using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sprout.Exam.Common.DataTransferObjects;

namespace Sprout.Exam.WebApp.Validators
{
    public class CalculateRequestValidator : AbstractValidator<CalculateRequestDto>
    {
        public CalculateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.WorkedDays).NotEmpty().When(x => !x.AbsentDays.HasValue);
            RuleFor(x => x.WorkedDays).Must(x => x.Value >= 0).When(x => x.WorkedDays.HasValue);

            RuleFor(x => x.AbsentDays).NotEmpty().When(x => !x.WorkedDays.HasValue);
            RuleFor(x => x.AbsentDays).Must(x => x.Value >= 0).When(x => x.AbsentDays.HasValue);
        }
    }
}
