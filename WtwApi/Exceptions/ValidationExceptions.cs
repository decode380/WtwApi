using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace WtwApi.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Se ha producido uno o más errores de validación")
        {
            Errors = new List<String>();
        }
        public List<string> Errors { get; set; }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
