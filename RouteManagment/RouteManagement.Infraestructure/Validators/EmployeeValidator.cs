using FluentValidation;
using RouteManagment.Core.DTOs;
using System.ComponentModel.DataAnnotations;

namespace RouteManagement.Infraestructure.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.Email)
                .NotNull()
                .EmailAddress();

        }

  

    }
}
