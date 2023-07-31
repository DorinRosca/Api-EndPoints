using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Orders.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Orders.Query.GetOrders
{
    public class GetOrdersQueryHandler:IRequestHandler<GetOrdersQuery, IEnumerable<OrderDto>>
    {
         private readonly DataContext _context;
         private readonly IMapper _mapper;

         public GetOrdersQueryHandler(DataContext context, IMapper mapper)
         {
              _context = context;
              _mapper = mapper;
         }

         public async Task<IEnumerable<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
         {
              var query = await _context.Order
                   .Include(o => o.Car)
                   .Include(o => o.User)
                   .Include(o => o.Status)
                   .ToListAsync(cancellationToken);
              var orders = query.Select(entity => _mapper.Map<OrderDto>(entity));
              return orders;
          }
    }
}
