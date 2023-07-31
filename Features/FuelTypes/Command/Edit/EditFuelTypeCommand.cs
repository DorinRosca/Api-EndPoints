using ApiEndPoints.Features.FuelTypes.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.FuelTypes.Command.Edit
{
    public class EditFuelTypeCommand : IRequest<bool>
    {
        public int FuelTypeId { get; set; }
        [Required, StringLength(50)]
        public string FuelTypeName { get; set; }

        public EditFuelTypeCommand(FuelTypeDto model)
        {
            FuelTypeId = model.FuelTypeId;
            FuelTypeName = model.FuelTypeName;
        }
    }
}
