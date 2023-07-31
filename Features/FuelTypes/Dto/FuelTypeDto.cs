using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.FuelTypes.Dto
{
    public class FuelTypeDto
    {
        public byte FuelTypeId { get; set; }

        [Required, StringLength(50)]
        public string FuelTypeName { get; set; }
    }
}
