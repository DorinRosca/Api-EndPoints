using ApiEndPoints.Features.Vehicles.Command.Edit;
using ApiEndPoints.Features.Vehicles.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Vehicles.EndPoints
{
     public class EditVehicle : EndpointBaseAsync.WithRequest<VehicleDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public EditVehicle( IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPut("editVehicle/{id}")]

          public override async Task<IActionResult> HandleAsync(VehicleDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new EditVehicleCommand(request), cancellationToken);
               if (result)
               {
                    return Ok(result);

               }
               return Problem();
          }
     }
}
