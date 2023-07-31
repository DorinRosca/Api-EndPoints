using ApiEndPoints.Features.FuelTypes.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.FuelTypes.Command.Create
{
    public class CreateFuelTypeCommand : IRequest<bool>
    {
        [Required, StringLength(50)]
        public string FuelTypeName { get; set; }

        public CreateFuelTypeCommand(FuelTypeDto model)
        {
            FuelTypeName = model.FuelTypeName;
        }
    }
}
