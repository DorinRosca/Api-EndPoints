using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Transmissions.Dto
{
    public class TransmissionDto
    {
         public byte TransmissionId { get; set; }

        [Required, StringLength(50)]
        public string TransmissionName { get; set; }
    }
}
