using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Transmissions.Dto;
using MediatR;

namespace ApiEndPoints.Features.Transmissions.Query.GetAll
{
    public record GetAllTransmissionQuery : IRequest<IEnumerable<TransmissionDto>>;
}
