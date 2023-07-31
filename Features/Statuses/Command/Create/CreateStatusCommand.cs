using MediatR;
using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Statuses.Dto;

namespace ApiEndPoints.Features.Statuses.Command.Create
{
    public record CreateStatusCommand : IRequest<bool>
    {

        [Required, StringLength(50)]
        public string StatusName { get; set; }

        public CreateStatusCommand(StatusDto model)
        {
            StatusName = model.StatusName;
        }
    }
}
