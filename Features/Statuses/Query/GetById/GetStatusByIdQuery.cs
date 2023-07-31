using ApiEndPoints.Features.Statuses.Dto;
using MediatR;

namespace ApiEndPoints.Features.Statuses.Query.GetById
{
    public record GetStatusByIdQuery : IRequest<StatusDto>
    {
        public byte StatusId { get; set; }

        public GetStatusByIdQuery(byte Id)
        {
            StatusId = Id;
        }
    }
}
