using System.Drawing.Text;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Cars.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Cars.Query.GetDetails
{
    public class GetCarDetailsQueryHandler : IRequestHandler<GetCarDetailsQuery, CarCreateDto>
     {
          private readonly DataContext _context;

          public GetCarDetailsQueryHandler(DataContext context)
          {
               _context = context;
          }
          public async Task<CarCreateDto> Handle(GetCarDetailsQuery request, CancellationToken cancellationToken)
          {

               var Dto = new CarCreateDto
               {
                    Brand = await _context.Brand.ToListAsync(cancellationToken),
                    Drive = await _context.Drive.ToListAsync(cancellationToken),
                    FuelType = await _context.FuelType.ToListAsync(cancellationToken),
                    Transmission = await _context.Transmission.ToListAsync(cancellationToken),
                    Vehicle = await _context.Vehicle.ToListAsync(cancellationToken)
               };

               return Dto;
          }
     }
}
