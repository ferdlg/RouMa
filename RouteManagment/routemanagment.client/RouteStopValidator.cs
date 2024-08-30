using FluentValidation;
using RouteManagment.Core.DTOs;

namespace RouteManagement.Infraestructure.Validators
{
    public class RouteStopValidator : AbstractValidator<RouteStopDto>
    {
        public RouteStopValidator()
        {
        // Validations rules for each field

            RuleFor(routeStop => routeStop.StopId)
                .NotNull();

            RuleFor(routeStop => routeStop.RouteId)
                .NotNull();
        }
    }
}
