using ApiEndPoints.Features.Transmissions.Command.Edit;
using ApiEndPoints.Features.Transmissions.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Transmissions.EndPoints
{
     public class EditTransmission : EndpointBaseAsync.WithRequest<TransmissionDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public EditTransmission( IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPut("editTransmission/{id}")]

          public override async Task<IActionResult> HandleAsync(TransmissionDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new EditTransmissionCommand(request), cancellationToken);
               if (result)
               {
                    return Ok(result);

               }
               return Problem();
          }
     }
}
