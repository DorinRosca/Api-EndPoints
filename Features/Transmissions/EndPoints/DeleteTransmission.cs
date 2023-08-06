using ApiEndPoints.Features.Transmissions.Command.Delete;
using ApiEndPoints.Features.Transmissions.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Transmissions.EndPoints
{
     public class DeleteTransmission : EndpointBaseAsync.WithRequest<byte>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public DeleteTransmission(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpDelete("deleteTransmission/{id}")]
          public override async Task<IActionResult> HandleAsync(byte id, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new DeleteTransmissionCommand(id),cancellationToken);
               if (result)
               {

                    return Ok(result);
               }
               return Problem();
          }
     }
}
