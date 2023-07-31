using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Cars.Dto;
using MediatR;

namespace ApiEndPoints.Features.Cars.Command.Edit
{
    public record EditCarCommand(CarEditDto model):IRequest<bool>
     {
          public int CarId = model.CarId;
          [Required]
          public byte VehicleId = model.VehicleId;
          [Required]
          public byte BrandId = model.BrandId;

          [Required]
          [StringLength(50)]
          public string ModelName = model.ModelName;

          [Range(1, short.MaxValue)]
          public short Year = model.Year;

          [Required]
          public byte FuelTypeId = model.FuelTypeId;

          [Required] public byte TransmissionId = model.TransmissionId;
          [Required]
          public byte DriveId = model.DriveId;
          [Required]
          [Range(1, double.PositiveInfinity)]
          public decimal PricePerDay = model.PricePerDay;

          public byte[] Image = model.Image;
          public IFormFile ImageFile = model.ImageFile;

     }
}
