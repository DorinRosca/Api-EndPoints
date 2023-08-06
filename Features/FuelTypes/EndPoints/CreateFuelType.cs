using ApiEndPoints.Features.FuelTypes.Command.Create;
using ApiEndPoints.Features.FuelTypes.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.FuelTypes.EndPoints
{
     public class CreateFuelType: EndpointBaseAsync.WithRequest<FuelTypeDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;

          public CreateFuelType(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPost("addFuelType")]
          public override async Task<IActionResult> HandleAsync(FuelTypeDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new CreateFuelTypeCommand(request),cancellationToken);
               return Ok(result);
          }
     }
}
