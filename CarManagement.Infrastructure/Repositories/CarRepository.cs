using CarManagement.Domain.Entities;
using CarManagement.Domain.Interfaces.Repositories;
using CarManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Infrastructure.Repositories
{
    public class CarRepository : Repository<Cars>, ICarRepository
    {
        public CarRepository(CarsManagementDBContext dbContext) : base(dbContext) { }

        public async Task<Cars> FindByCarId(int carId)
        {
            var query = (
                from a in _dbContext.Cars
                where a.CarId == carId
                select a
                         );

            var item = await query.FirstOrDefaultAsync();

            return item;
        }
    }
}
