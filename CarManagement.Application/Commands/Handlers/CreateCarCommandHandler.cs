using CarManagement.Application.Commands.Validators;
using CarManagement.Application.DTOs;
using CarManagement.Application.Helpers.Extensions;
using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces.Repositories;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Application.Commands.Handlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommandRequest, ResponseDTO<CreateCarCommandResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly CreateCarCommandValidator _createCarCommandValidator;

        public CreateCarCommandHandler(
            ICarRepository carRepository,
            CreateCarCommandValidator createCarCommandValidator
            )
        {
            _carRepository = carRepository;
            _createCarCommandValidator = createCarCommandValidator;
        }

        public async Task<ResponseDTO<CreateCarCommandResponse>> Handle(CreateCarCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new ResponseDTO<CreateCarCommandResponse>(); 

            var validate = _createCarCommandValidator.Validate(request);
            response.Success = validate.IsValid;

            if (response.Success)
            {
                var car = request.MapPropertiesTo<Cars>();

                if (car != null)
                {
                    await _carRepository.AddAsync(car);
                    await _carRepository.SaveChangesAsync();
                    response.Success = true;
                    response.Result = car.MapPropertiesTo<CreateCarCommandResponse>();
                    return response;
                }
            }

            response.Success = false;
            response.Message = "Los datos enviados son inválidos";
            return response;
        }
    }
}
