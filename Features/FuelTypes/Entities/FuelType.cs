﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.FuelTypes.Entities
{
    [Table("FuelType")]
    public class FuelType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte FuelTypeId { get; set; }

        [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
        public string FuelTypeName { get; set; }

    }
}
