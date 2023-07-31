using ApiEndPoints.Features.Vehicles.Dto;
using MediatR;

namespace ApiEndPoints.Features.Vehicles.Command.Edit
{
    public class EditVehicleCommand : IRequest<bool>
    {
        public byte VehicleId { get; set; }
        public string VehicleName { get; set; }
        public byte SeatsNumber { get; set; }


        public EditVehicleCommand(VehicleDto model)
        {
            VehicleId = model.VehicleId;
            VehicleName = model.VehicleName;
            SeatsNumber = model.SeatsNumber;
        }
    }
}
