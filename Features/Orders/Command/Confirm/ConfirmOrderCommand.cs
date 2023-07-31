using MediatR;

namespace ApiEndPoints.Features.Orders.Command.Confirm
{
     public record ConfirmOrderCommand(int Id) : IRequest<bool>
     {
          public int Id = Id;
     }
}
