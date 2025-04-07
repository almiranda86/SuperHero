using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SuperHero.Infrastructure.Extensions
{
    public static class ValidationExtensions
    {
        public static ValidationProblemDetails ToValidationProblemDetails(this ValidationException exception)
        {
            var error = new ValidationProblemDetails();

            foreach (var validationFailure in exception.Errors)
            {
                if (error.Errors.ContainsKey(validationFailure.PropertyName))
                {
                    error.Errors[validationFailure.PropertyName] = error.Errors[validationFailure.PropertyName].Concat(new[] { validationFailure.ErrorMessage }).ToArray();
                }

                error.Errors.Add(new KeyValuePair<string, string[]>(
                validationFailure.PropertyName,
                new[] { validationFailure.ErrorMessage }));
            }

            return error;
        }
    }
}
