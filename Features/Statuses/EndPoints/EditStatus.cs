using ApiEndPoints.Features.Statuses.Command.Edit;
using ApiEndPoints.Features.Statuses.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Statuses.EndPoints
{
     public class EditStatus : EndpointBaseAsync.WithRequest<StatusDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public EditStatus( IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPut("editStatus/{id}")]

          public override async Task<IActionResult> HandleAsync(StatusDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new EditStatusCommand(request), cancellationToken);
               if (result)
               {
                    return Ok(result);

               }
               return Problem();
          }
     }
}
