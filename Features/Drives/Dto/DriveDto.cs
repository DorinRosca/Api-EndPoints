using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Drives.Dto
{
    public class DriveDto
    {
        [Required]
        public byte DriveId { get; set; }

        [Required, StringLength(50)]
        public string DriveName { get; set; }
    }
}
