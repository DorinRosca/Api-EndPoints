using ApiEndPoints.Features.Drives.Command.Create;
using ApiEndPoints.Features.Drives.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Drives.EndPoints
{
     public class CreateDrive: EndpointBaseAsync.WithRequest<DriveDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public CreateDrive(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPost("addDrive")]
          public override async Task<IActionResult> HandleAsync(DriveDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new CreateDriveCommand(request),cancellationToken);
               return Ok(result);
          }
     }
}
