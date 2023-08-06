using ApiEndPoints.Features.Transmissions.Command.Create;
using ApiEndPoints.Features.Transmissions.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Transmissions.EndPoints
{
     public class CreateTransmission: EndpointBaseAsync.WithRequest<TransmissionDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public CreateTransmission(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPost("addTransmission")]
          public override async Task<IActionResult> HandleAsync(TransmissionDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new CreateTransmissionCommand(request),cancellationToken);
               return Ok(result);
          }
     }
}
