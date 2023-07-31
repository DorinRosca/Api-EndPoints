﻿using MediatR;

namespace ApiEndPoints.Features.Cars.Command.Delete
{
     public record DeleteCarCommand(int carId) :IRequest<bool>
     {
          public int CarId = carId;

     }
}