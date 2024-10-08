using CarManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Domain.Interfaces.Repositories
{
    public interface ICarRepository : IRepository<Cars>
    {
        Task<Cars> FindByCarId(int carId);
    }
}
