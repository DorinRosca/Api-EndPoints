using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Brands.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Brands.Query.GetAll
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<BrandDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllBrandQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _context.Brand.ToListAsync(cancellationToken);
            var result = dataList.Select(entity => _mapper.Map<BrandDto>(entity));
            return result;
        }
    }
}
