using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using ApiEndPoints.Attribute;
using ApiEndPoints.Features.Cars.Entities;
using ApiEndPoints.Features.Statuses.Entities;

namespace ApiEndPoints.Features.Orders.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        [Required]
        public int CarId { get; set; }

        public Car Car { get; set; }
        [Required]

        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        [Required]
        [EarlierThanNow(ErrorMessage = "Start date cannot be earlier than the current date.")]
        public DateTime RentalStartDate { get; set; }

        [Required]
        [RentalEndDate(ErrorMessage = "End date cannot be earlier than the start date.")]
        public DateTime RentalEndDate { get; set; }

        public DateTime Now { get; set; }
        public double TotalAmount { get; set; }

        public byte StatusId { get; set; }
        public Status Status { get; set; }

        public OrderDto()
        {
            Now = DateTime.Today;
        }
    }
}
