using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Cars.Dto;
using MediatR;

namespace ApiEndPoints.Features.Cars.Query.GetEditCar
{
    public record GetEditCarQuery(int Id) : IRequest<CarEditDto>
    {
        public int Id = Id;

    }
}
