using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Application.Objects.DataValidators
{
    public class WarningDtoValidator : AbstractValidator<ErrorDto>
    {
        public WarningDtoValidator(IWarrningRepo repo)
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Minimum length is 2!")
                .MaximumLength(20).WithMessage("Maximum length is 20!");

            RuleFor(c => c.CategoryId)
               .NotEmpty().WithMessage("Select category!");

            RuleFor(c => c.PriorityId)
               .NotEmpty().WithMessage("Select priority!"); ;

            RuleFor(c => c.UserId)
               .NotEmpty();

        }

    }
}
