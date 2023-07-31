using MediatR;

namespace ApiEndPoints.Features.FuelTypes.Command.Delete
{
    public class DeleteFuelTypeCommand : IRequest<bool>
    {

        public byte FuelTypeId { get; set; }
        public DeleteFuelTypeCommand(byte fuelTypeId)
        {
            FuelTypeId = fuelTypeId;
        }


    }
}
