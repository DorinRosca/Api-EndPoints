using ApiEndPoints.Features.Cars.Dto;
using MediatR;

namespace ApiEndPoints.Features.Cars.Query.GetById
{
    public record GetCarByIdQuery(int carId) :IRequest<CarDto>
     {
          public int CarId = carId;

     }
}
