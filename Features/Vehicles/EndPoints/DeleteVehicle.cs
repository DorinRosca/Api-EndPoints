using ApiEndPoints.Features.Vehicles.Command.Delete;
using ApiEndPoints.Features.Vehicles.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Vehicles.EndPoints
{
     public class DeleteVehicle : EndpointBaseAsync.WithRequest<byte>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public DeleteVehicle(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpDelete("deleteVehicle/{id}")]
          public override async Task<IActionResult> HandleAsync(byte id, CancellationToken cancellationToken = new CancellationToken())
          {
               var result =  await _mediator.Send(new DeleteVehicleCommand(id), cancellationToken);
               if (result)
               {
                    return Ok(result);
               }
               return Problem();
          }
     }
}
