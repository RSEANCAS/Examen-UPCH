using CarManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Application.Commands
{
    public class DeleteCarCommandRequest : IRequest<ResponseDTO<DeleteCarCommandResponse>>
    {
        public int CarId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public string UserDeleted { get; set; }
    }

    public class DeleteCarCommandResponse
    {
        public int CarId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? UserDeleted { get; set; }
    }
}
