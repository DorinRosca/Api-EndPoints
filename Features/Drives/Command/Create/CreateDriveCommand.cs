using ApiEndPoints.Features.Drives.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Drives.Command.Create
{
    public class CreateDriveCommand : IRequest<bool>
    {
        [Required, StringLength(50)]
        public string DriveName { get; set; }

        public CreateDriveCommand(DriveDto model)
        {
            DriveName = model.DriveName;
        }
    }
}
