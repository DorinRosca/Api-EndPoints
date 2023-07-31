using ApiEndPoints.Features.Cars.Dto;
using MediatR;

namespace ApiEndPoints.Features.Cars.Query.GetDetails
{
    public class GetCarDetailsQuery :IRequest<CarCreateDto>
     {
     }
}
