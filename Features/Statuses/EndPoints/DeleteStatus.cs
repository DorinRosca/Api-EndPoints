using ApiEndPoints.Features.Statuses.Command.Delete;
using ApiEndPoints.Features.Statuses.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Statuses.EndPoints
{
     public class DeleteStatus : EndpointBaseAsync.WithRequest<byte>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public DeleteStatus(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpDelete("deleteStatus/{id}")]
          public override async Task<IActionResult> HandleAsync(byte id, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new DeleteStatusCommand(id), cancellationToken);
               if (result)
               {
                    return Ok(result);
               }
               return Problem();
          }
     }
}
