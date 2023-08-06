using ApiEndPoints.Features.FuelTypes.Dto;
using ApiEndPoints.Features.FuelTypes.Query.GetAll;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiEndPoints.Features.FuelTypes.EndPoints
{
     public class GetAllFuelTypes : EndpointBaseAsync.WithoutRequest.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public GetAllFuelTypes(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }
          [HttpGet("getAllFuelTypes")]
          public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               var FuelTypes = await _appCache.GetOrAddAsync("AllFuelTypes.Get", () => _mediator.Send(new GetAllFuelTypeQuery(),cancellationToken), DateTime.Now.AddHours(4));
               if (FuelTypes.IsNullOrEmpty())
               {
                    return NotFound();
               }
               return Ok(FuelTypes);
          }
     }
}
