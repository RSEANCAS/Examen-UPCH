using CarManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Application.Commands
{
    public class CreateCarCommand
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateCarCommandRequest : IRequest<ResponseDTO<CreateCarCommandResponse>>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserCreated { get; set; }
    }

    public class CreateCarCommandResponse
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserCreated { get; set; }
    }
}
