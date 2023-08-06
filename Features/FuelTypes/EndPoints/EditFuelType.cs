using ApiEndPoints.Features.FuelTypes.Command.Edit;
using ApiEndPoints.Features.FuelTypes.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.FuelTypes.EndPoints
{
     public class EditFuelType : EndpointBaseAsync.WithRequest<FuelTypeDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public EditFuelType( IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPut("editFuelType/{id}")]

          public override async Task<IActionResult> HandleAsync(FuelTypeDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new EditFuelTypeCommand(request), cancellationToken);
               if (result)
               {
                    return Ok(result);

               }
               return Problem();
          }
     }
}
