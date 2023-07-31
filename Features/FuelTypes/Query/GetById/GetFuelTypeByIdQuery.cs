using ApiEndPoints.Features.FuelTypes.Dto;
using MediatR;

namespace ApiEndPoints.Features.FuelTypes.Query.GetById
{
    public class GetFuelTypeByIdQuery : IRequest<FuelTypeDto>
    {
        public byte FuelTypeId { get; set; }

        public GetFuelTypeByIdQuery(byte Id)
        {
            FuelTypeId = Id;
        }
    }
}
