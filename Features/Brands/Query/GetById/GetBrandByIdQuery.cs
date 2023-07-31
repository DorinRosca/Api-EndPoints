using ApiEndPoints.Features.Brands.Dto;
using MediatR;

namespace ApiEndPoints.Features.Brands.Query.GetById
{
    public record GetBrandByIdQuery(byte Id) : IRequest<BrandDto>
    {
         public byte BrandId = Id;
    }
}
