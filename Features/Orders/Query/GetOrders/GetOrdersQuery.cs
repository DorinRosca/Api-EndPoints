using ApiEndPoints.Features.Orders.Dto;
using MediatR;

namespace ApiEndPoints.Features.Orders.Query.GetOrders
{
    public record GetOrdersQuery : IRequest<IEnumerable<OrderDto>>;
}
