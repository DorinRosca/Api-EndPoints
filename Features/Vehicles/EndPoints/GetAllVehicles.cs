using ApiEndPoints.Features.Vehicles.Dto;
using ApiEndPoints.Features.Vehicles.Query.GetAll;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiEndPoints.Features.Vehicles.EndPoints
{
     public class GetAllVehicles : EndpointBaseAsync.WithoutRequest.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public GetAllVehicles(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }
          [HttpGet("getAllVehicles")]
          public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               var vehicles = await _appCache.GetOrAddAsync("AllVehicles.Get", () => _mediator.Send(new GetAllVehicleQuery(),cancellationToken), DateTime.Now.AddHours(4));
               if (vehicles.IsNullOrEmpty())
               {
                    return NotFound();
               }
               return Ok(vehicles);
          }
     }
}
