using ApiEndPoints.Features.FuelTypes.Command.Delete;
using ApiEndPoints.Features.FuelTypes.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.FuelTypes.EndPoints
{
     public class DeleteFuelType : EndpointBaseAsync.WithRequest<byte>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public DeleteFuelType(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
          }
          [HttpDelete("deleteFuelType/{id}")]
          public override async Task<IActionResult> HandleAsync(byte id, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new DeleteFuelTypeCommand(id), cancellationToken);
               if (result)
               {

                    return Ok(result);
               }
               return Problem();
          }
     }
}
