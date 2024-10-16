using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Udemy.TodoAppNTier.Dtos.WorkDtos;

namespace Udemy.TodoAppNTier.Business.ValidationRules
{
    public class WorkCreateDtoValidator:AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Defination).NotEmpty();

        }

        private bool NotBeYavuz(string arg)
        {
            return arg != "Yavuz" && arg!= "yavuz";
        }
    }
}
