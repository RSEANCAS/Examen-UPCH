using CarManagement.Application.DTOs;
using CarManagement.Application.Helpers.Extensions;
using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Application.Commands.Handlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommandRequest, ResponseDTO<UpdateCarCommandResponse>>
    {
        private readonly ICarRepository _carRepository;

        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<ResponseDTO<UpdateCarCommandResponse>> Handle(UpdateCarCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new ResponseDTO<UpdateCarCommandResponse>();

            var car = await _carRepository.FindByCarId(request.CarId);

            if (car != null)
            {
                car.Assign(request);
                _carRepository.Update(car);
                await _carRepository.SaveChangesAsync();
                response.Success = true;
                response.Result = car.MapPropertiesTo<UpdateCarCommandResponse>();
                return response;
            }

            response.Message = "Ocurrió un error";
            return response;
        }
    }
}
