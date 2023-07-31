using MediatR;
using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Transmissions.Dto;

namespace ApiEndPoints.Features.Transmissions.Command.Edit
{
    public class EditTransmissionCommand : IRequest<bool>
    {
        public int TransmissionId { get; set; }

        [Required, StringLength(50)]
        public string TransmissionName { get; set; }
        public EditTransmissionCommand(TransmissionDto model)
        {
            TransmissionId = model.TransmissionId;
            TransmissionName = model.TransmissionName;
        }
    }
}
