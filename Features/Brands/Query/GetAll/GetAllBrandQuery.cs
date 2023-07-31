using ApiEndPoints.Features.Brands.Dto;
using MediatR;

namespace ApiEndPoints.Features.Brands.Query.GetAll
{
    public class GetAllBrandQuery : IRequest<IEnumerable<BrandDto>>
    {
    }
}
