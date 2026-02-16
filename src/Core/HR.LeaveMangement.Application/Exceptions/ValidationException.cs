using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace HR.LeaveMangement.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; }

        public ValidationException(ValidationResult validationResult)
            : base("Validation failed")
        {
            Errors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
