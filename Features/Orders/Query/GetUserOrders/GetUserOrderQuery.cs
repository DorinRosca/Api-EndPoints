using ApiEndPoints.Features.Orders.Dto;
using MediatR;

namespace ApiEndPoints.Features.Orders.Query.GetUserOrders
{
    public record GetUserOrderQuery(string Id) :IRequest<IEnumerable<OrderDto>>
     {
          public string UserId = Id;
     }
}
