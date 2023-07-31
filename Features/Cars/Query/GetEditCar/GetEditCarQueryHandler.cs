using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Cars.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Cars.Query.GetEditCar
{
    public class GetEditCarQueryHandler : IRequestHandler<GetEditCarQuery, CarEditDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetEditCarQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CarEditDto> Handle(GetEditCarQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                throw new ArgumentNullException(nameof(request.Id), "The Id cannot be zero");
            }
            var model = await _context.Car.FindAsync(request.Id);

            if (model == null)
            {
                throw new ArgumentNullException(nameof(request.Id), "There is no entity with such Id");
            }

            var Dto = _mapper.Map<CarEditDto>(model);

            Dto.Brand = await _context.Brand.ToListAsync(cancellationToken);
            Dto.Drive = await _context.Drive.ToListAsync(cancellationToken);
            Dto.FuelType = await _context.FuelType.ToListAsync(cancellationToken);
            Dto.Transmission = await _context.Transmission.ToListAsync(cancellationToken);
            Dto.Vehicle = await _context.Vehicle.ToListAsync(cancellationToken);
            return Dto;
        }
    }
}
