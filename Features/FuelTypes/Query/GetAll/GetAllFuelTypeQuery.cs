using ApiEndPoints.Features.FuelTypes.Dto;
using MediatR;

namespace ApiEndPoints.Features.FuelTypes.Query.GetAll
{
    public class GetAllFuelTypeQuery : IRequest<IEnumerable<FuelTypeDto>>
    {
    }
}
