using ApiEndPoints.Features.Statuses.Command.Create;
using ApiEndPoints.Features.Statuses.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Statuses.EndPoints
{
     public class CreateStatus: EndpointBaseAsync.WithRequest<StatusDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public CreateStatus(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPost("addStatus")]
          public override async Task<IActionResult> HandleAsync(StatusDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new CreateStatusCommand(request),cancellationToken);
               return Ok(result);
          }
     }
}
