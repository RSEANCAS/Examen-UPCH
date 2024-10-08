using CarManagement.Application.Commands;
using CarManagement.Application.Helpers.Extensions;
using CarManagement.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.API.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarCommand request, [FromHeader(Name = "UserSesion")] string userSesion)
        {
            var requestData = request.MapPropertiesTo<CreateCarCommandRequest>();
            requestData.UserCreated = userSesion;
            requestData.CreatedAt = DateTime.Now;
            return Ok(await _mediator.Send(requestData));
        }

        [HttpPut("update/{carId:int}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int carId, [FromBody] UpdateCarCommand request, [FromHeader(Name = "UserSesion")] string userSesion)
        {
            var requestData = request.MapPropertiesTo<UpdateCarCommandRequest>();
            requestData.CarId = carId;
            requestData.UserUpdated = userSesion;
            requestData.UpdatedAt = DateTime.Now;
            return Ok(await _mediator.Send(requestData));
        }

        [HttpDelete("delete/{carId:int}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int carId, [FromHeader(Name = "UserSesion")] string userSesion)
        {
            var requestData = new DeleteCarCommandRequest();
            requestData.CarId = carId;
            requestData.IsDeleted = true;
            requestData.UserDeleted = userSesion;
            requestData.DeletedAt = DateTime.Now;
            return Ok(await _mediator.Send(requestData));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllCar()
        {
            return Ok(await _mediator.Send(new GetAllCarQueryRequest{ }));
        }
    }
}
