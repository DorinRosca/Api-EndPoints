﻿using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Brands.Entities;
using ApiEndPoints.Features.Drives.Entities;
using ApiEndPoints.Features.FuelTypes.Entities;
using ApiEndPoints.Features.Transmissions.Entities;
using ApiEndPoints.Features.Vehicles.Entities;

namespace ApiEndPoints.Features.Cars.Dto
{
    public class CarDto
    {
        public int CarId { get; set; }
        [Required]
        public byte BrandId { get; set; }
        [Required]
        public byte VehicleId { get; set; }
        [StringLength(50)]
        public string ModelName { get; set; }
        [Required]
        [Range(0, short.MaxValue)]
        public short Year { get; set; }
        [Required]
        public byte FuelTypeId { get; set; }
        [Required]
        public byte TransmissionId { get; set; }
        [Required]
        public byte DriveId { get; set; }
        [Required]
        [Range(0, double.PositiveInfinity)]

        public decimal PricePerDay { get; set; }
        [Required]
        public byte[] Image { get; set; }

        public Vehicle Vehicle { get; set; }
        public Brand Brand { get; set; }
        public FuelType FuelType { get; set; }
        public Transmission Transmission { get; set; }
        public Drive Drive { get; set; }
        [Range(0, double.MaxValue)]
        public IFormFile ImageFile { get; set; }

    }
}