using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Statuses.Command.Delete
{
    public record DeleteStatusCommand : IRequest<bool>
    {
        public byte StatusId { get; set; }

        public DeleteStatusCommand(byte Id)
        {
            StatusId = Id;
        }
    }
}
