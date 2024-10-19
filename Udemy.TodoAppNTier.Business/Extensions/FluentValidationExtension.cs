using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Udemy.ToDoNTier.Common.ResponseObjects;

namespace Udemy.TodoAppNTier.Business.Extensions
{
    public static class FluentValidationExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new List<CustomValidationError>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new(){ErrorMessage = error.ErrorMessage,PropertyName = error.PropertyName});
                
            }
            return errors;
        }
    }
}
