using CarManagement.Application.Commands;
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

namespace CarManagement.Application.Queries.Handlers
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQueryRequest, ResponseDTO<List<GetAllCarQueryResponse>>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<ResponseDTO<List<GetAllCarQueryResponse>>> Handle(GetAllCarQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new ResponseDTO<List<GetAllCarQueryResponse>>();

            var cars = await _carRepository.GetAllAsync();

            response.Success = true;
            response.Result = cars.MapCollectionTo<Cars, GetAllCarQueryResponse>().ToList();
            return response;
        }
    }
}
