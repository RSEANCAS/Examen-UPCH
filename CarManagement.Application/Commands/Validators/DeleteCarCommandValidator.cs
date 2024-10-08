using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Application.Commands.Validators
{
    public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommandRequest>
    {
        public DeleteCarCommandValidator()
        {
            RuleFor(car => car.CarId).NotEmpty().WithMessage("CarId is required");
            RuleFor(car => car.UserDeleted).NotEmpty().WithMessage("UserDeleted is required");
        }
    }
}
