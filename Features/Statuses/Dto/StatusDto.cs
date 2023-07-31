using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Statuses.Dto
{
    public class StatusDto
    {
        public byte StatusId { get; set; }

        [Required, StringLength(50)]
        public string StatusName { get; set; }
    }
}
