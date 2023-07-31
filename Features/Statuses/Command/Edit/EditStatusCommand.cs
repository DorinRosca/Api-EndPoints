using MediatR;
using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Statuses.Dto;

namespace ApiEndPoints.Features.Statuses.Command.Edit
{
    public class EditStatusCommand : IRequest<bool>
    {
        public int StatusId { get; set; }
        [Required, StringLength(50)]
        public string StatusName { get; set; }

        public EditStatusCommand(StatusDto model)
        {
            StatusId = model.StatusId;
            StatusName = model.StatusName;
        }
    }
}
