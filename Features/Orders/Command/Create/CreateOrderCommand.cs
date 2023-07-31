﻿using System.ComponentModel.DataAnnotations;
using ApiEndPoints.Attribute;
using ApiEndPoints.Features.Cars.Entities;
using ApiEndPoints.Features.Orders.Dto;
using ApiEndPoints.Features.Statuses.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ApiEndPoints.Features.Orders.Command.Create
{
    public record CreateOrderCommand :IRequest<bool>
     {
          public int OrderId { get; set; }
          [Required]
          public int CarId { get; set; }
          [Required]
          public Car Car { get; set; }
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

          public CreateOrderCommand(OrderDto model)
          {
               CarId = model.CarId;
               Car = model.Car;
               UserId = model.UserId;
               User = model.User;
               RentalStartDate = model.RentalStartDate;
               RentalEndDate = model.RentalEndDate;
               TotalAmount = model.TotalAmount;
               StatusId = model.StatusId;
               Status = model.Status;
               Now = DateTime.Today;
          }
     }
}
