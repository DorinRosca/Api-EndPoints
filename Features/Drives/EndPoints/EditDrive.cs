using ApiEndPoints.Features.Drives.Command.Edit;
using ApiEndPoints.Features.Drives.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Drives.EndPoints
{
     public class EditDrive : EndpointBaseAsync.WithRequest<DriveDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public EditDrive( IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPut("editDrive/{id}")]

          public override async Task<IActionResult> HandleAsync(DriveDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new EditDriveCommand(request), cancellationToken);
               if (result)
               {
                    return Ok(result);

               }
               return Problem();
          }
     }
}
