using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Vehicles.Entities;
using MediatR;

namespace ApiEndPoints.Features.Vehicles.Command.Create
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, bool>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = _mapper.Map<Vehicle>(request);
            await _context.Vehicle.AddAsync(vehicle, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
