﻿using System.ComponentModel.DataAnnotations;

namespace TARge21Shop.Core.Domain.Car
{
    public class Car
    {
        [Key]

        public Guid? Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string FuelType { get; set; }
        public int Price { get; set; }
        public int EnginePower { get; set; }
        public int Mileage { get; set; }
        public int PreviousOwners { get; set; }
        public DateTime BuiltDate { get; set; }
        public DateTime MaintanceDate { get; set; }
    }
}