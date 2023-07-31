using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.FuelTypes.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.FuelTypes.Query.GetAll
{
    public class GetAllFuelTypeQueryHandler : IRequestHandler<GetAllFuelTypeQuery, IEnumerable<FuelTypeDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllFuelTypeQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuelTypeDto>> Handle(GetAllFuelTypeQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _context.FuelType.ToListAsync(cancellationToken);
            var result = dataList.Select(entity => _mapper.Map<FuelTypeDto>(entity));
            return result;
        }
    }
}
