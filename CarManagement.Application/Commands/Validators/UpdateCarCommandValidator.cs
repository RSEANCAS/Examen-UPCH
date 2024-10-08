using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Application.Commands.Validators
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommandRequest>
    {
        public UpdateCarCommandValidator()
        {
            RuleFor(car => car.CarId).NotEmpty().WithMessage("CarId is required");
            RuleFor(car => car.Make).NotEmpty().WithMessage("Make is required");
            RuleFor(car => car.Model).NotEmpty().WithMessage("Model is requited");
            RuleFor(car => car.Year).LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Year must be less than or equal to {0}");
            RuleFor(car => car.Type).NotEmpty().WithMessage("Type is required");
            RuleFor(car => car.Seats).GreaterThan(0).WithMessage("Seats must be greater than 0");
            RuleFor(car => car.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(car => car.UserUpdated).NotEmpty().WithMessage("UserUpdated is required");
        }
    }
}
