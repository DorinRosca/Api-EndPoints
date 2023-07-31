using ApiEndPoints.Features.Drives.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Drives.Command.Edit
{
    public class EditDriveCommand : IRequest<bool>
    {
        public int DriveId { get; set; }
        [Required, StringLength(50)]
        public string DriveName { get; set; }

        public EditDriveCommand(DriveDto model)
        {
            DriveId = model.DriveId;
            DriveName = model.DriveName;
        }
    }
}
