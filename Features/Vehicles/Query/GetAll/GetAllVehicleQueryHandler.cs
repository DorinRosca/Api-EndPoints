using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Vehicles.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Vehicles.Query.GetAll
{
    public class GetAllVehicleQueryHandler : IRequestHandler<GetAllVehicleQuery, IEnumerable<VehicleDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllVehicleQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<VehicleDto>> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _context.Vehicle.ToListAsync(cancellationToken);
            var result = dataList.Select(entity => _mapper.Map<VehicleDto>(entity));
            return result;
        }
    }
}
