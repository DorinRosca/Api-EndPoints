using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiEndPoints.Features.Brands.Entities;
using ApiEndPoints.Features.Drives.Entities;
using ApiEndPoints.Features.FuelTypes.Entities;
using ApiEndPoints.Features.Transmissions.Entities;
using ApiEndPoints.Features.Vehicles.Entities;

namespace ApiEndPoints.Features.Cars.Dto
{
    public class CarCreateDto
    {
        public int CarId { get; set; }
        [Required]
        public byte VehicleId { get; set; }

        [Required]
        public byte BrandId { get; set; }
        [Required]
        [StringLength(50)]
        public string ModelName { get; set; }
        [Required]
        [Range(1, short.MaxValue)]
        public short Year { get; set; }
        [Required]
        public byte FuelTypeId { get; set; }
        [Required]
        public byte TransmissionId { get; set; }
        [Required]
        public byte DriveId { get; set; }

        [Required]
        [Range(1, double.PositiveInfinity)]
        public byte[] Image { get; set; }
        public decimal PricePerDay { get; set; }
        public List<Brand> Brand { get; set; }
        public List<Drive> Drive { get; set; }
        public List<FuelType> FuelType { get; set; }
        public List<Transmission> Transmission { get; set; }
        public List<Vehicle> Vehicle { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

    }
}
