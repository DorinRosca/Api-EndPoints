using ApiEndPoints.Features.Brands.Dto;
using ApiEndPoints.Features.Brands.Query.GetAll;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiEndPoints.Features.Brands.EndPoints
{
     public class GetAllBrands : EndpointBaseAsync.WithoutRequest.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public GetAllBrands(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }
          [HttpGet("getAllBrands")]
          public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               var brands = await _appCache.GetOrAddAsync("AllBrands.Get", () => _mediator.Send(new GetAllBrandQuery(),cancellationToken),DateTime.Now.AddHours(4));
               if (brands.IsNullOrEmpty())
               {
                    return NotFound();
               }
               return Ok(brands);
          }
     }
}
