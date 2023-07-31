using ApiEndPoints.Features.Vehicles.Dto;
using MediatR;

namespace ApiEndPoints.Features.Vehicles.Query.GetAll
{
    public record GetAllVehicleQuery : IRequest<IEnumerable<VehicleDto>>;
}
