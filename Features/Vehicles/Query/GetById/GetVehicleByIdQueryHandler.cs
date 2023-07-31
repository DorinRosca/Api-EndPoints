using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Vehicles.Dto;
using MediatR;

namespace ApiEndPoints.Features.Vehicles.Query.GetById
{
    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, VehicleDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetVehicleByIdQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<VehicleDto> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.VehicleId == 0)
            {
                throw new ArgumentNullException(nameof(request.VehicleId), "The Id parameter cannot be zero.");

            }

            var entity = await _context.Vehicle.FindAsync(request.VehicleId);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(request.VehicleId), "There is no entity with such Id.");

            }

            var model = _mapper.Map<VehicleDto>(entity);
            return model;
        }
    }
}
