using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Statuses.Dto;
using MediatR;

namespace ApiEndPoints.Features.Statuses.Query.GetAll
{
    public record GetAllStatusQuery : IRequest<IEnumerable<StatusDto>>;
}
