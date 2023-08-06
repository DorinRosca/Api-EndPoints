using ApiEndPoints.Features.Drives.Command.Delete;
using ApiEndPoints.Features.Drives.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Drives.EndPoints
{
     public class DeleteDrive : EndpointBaseAsync.WithRequest<byte>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public DeleteDrive(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpDelete("deleteDrive/{id}")]
          public override async Task<IActionResult> HandleAsync(byte id, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new DeleteDriveCommand(id), cancellationToken);
               if (result)
               {

                    return Ok(result);
               }
               return Problem();
          }
     }
}
