using ApiEndPoints.Features.Vehicles.Command.Create;
using ApiEndPoints.Features.Vehicles.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Vehicles.EndPoints
{
     public class CreateVehicle: EndpointBaseAsync.WithRequest<VehicleDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public CreateVehicle(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPost("addVehicle")]
          public override async Task<IActionResult> HandleAsync(VehicleDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new CreateVehicleCommand(request),cancellationToken);
               return Ok(result);
          }
     }
}
