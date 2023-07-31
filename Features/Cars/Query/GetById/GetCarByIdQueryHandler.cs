using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Cars.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Cars.Query.GetById
{
    public class GetCarByIdQueryHandler :IRequestHandler<GetCarByIdQuery, CarDto>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;

          public GetCarByIdQueryHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
          {
               if (request.CarId == 0)
               {
                    throw new ArgumentNullException(nameof(request.CarId), "The Id cannot be zero");
               }
               var result = await _context.Car
                    .Include(c => c.Brand)
                    .Include(c => c.FuelType)
                    .Include(c => c.Transmission)
                    .Include(c => c.Drive)
                    .Include(c => c.Vehicle)
                    .FirstOrDefaultAsync(c => c.CarId == request.CarId, cancellationToken);
               var car = _mapper.Map<CarDto>(result);
               return car;
          }
     }
}
