﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Domain.Entities
{
    public class Cars
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public int Seats { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt {  get; set; }
        public string UserCreated { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UserUpdated { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? UserDeleted { get; set; }
    }
}
