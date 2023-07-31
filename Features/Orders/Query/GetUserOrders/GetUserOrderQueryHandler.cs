using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Orders.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Orders.Query.GetUserOrders
{
    public class GetUserOrderQueryHandler :IRequestHandler<GetUserOrderQuery, IEnumerable<OrderDto>>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;

          public GetUserOrderQueryHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }
          public async Task<IEnumerable<OrderDto>> Handle(GetUserOrderQuery request, CancellationToken cancellationToken)
          {
               if (request.UserId == null)
               {
                    throw new ArgumentNullException(nameof(request.UserId), "UserId cannot be null");
               }
               var query = _context.Order
                    .Include(o => o.Car)
                    .Include(o => o.User)
                    .Include(o => o.Status)
                    .Where(c => c.UserId.Contains(request.UserId));

               var orders = await query.ToListAsync(cancellationToken);

               var orderDtos = orders.Select(entity => _mapper.Map<OrderDto>(entity));
               return orderDtos;
          }
     }
}
