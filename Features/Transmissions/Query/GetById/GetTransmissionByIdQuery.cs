using ApiEndPoints.Features.Transmissions.Dto;
using MediatR;

namespace ApiEndPoints.Features.Transmissions.Query.GetById
{
    public record GetTransmissionByIdQuery : IRequest<TransmissionDto>
    {
        public byte TransmissionId { get; set; }

        public GetTransmissionByIdQuery(byte Id)
        {
            TransmissionId = Id;
        }
    }
}
