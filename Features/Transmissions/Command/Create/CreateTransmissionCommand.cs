using MediatR;
using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Features.Transmissions.Dto;

namespace ApiEndPoints.Features.Transmissions.Command.Create
{
    public record CreateTransmissionCommand : IRequest<bool>
    {

        [Required, StringLength(50)]
        public string TransmissionName { get; set; }

        public CreateTransmissionCommand(TransmissionDto model)
        {
            TransmissionName = model.TransmissionName;
        }
    }
}
