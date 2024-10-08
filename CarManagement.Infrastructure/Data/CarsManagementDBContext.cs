using CarManagement.Domain.Entities;
using CarManagement.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Infrastructure.Data
{
    public class CarsManagementDBContext : DbContext
    {
        public CarsManagementDBContext(DbContextOptions<CarsManagementDBContext> options) : base(options) { }
        public DbSet<Cars> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
