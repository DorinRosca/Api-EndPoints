using ApiEndPoints.Features.Vehicles.Dto;
using MediatR;

namespace ApiEndPoints.Features.Vehicles.Query.GetById
{
    public class GetVehicleByIdQuery : IRequest<VehicleDto>
    {
        public byte VehicleId { get; set; }

        public GetVehicleByIdQuery(byte id)
        {
            VehicleId = id;
        }
    }
}
