using ApiEndPoints.Features.Transmissions.Dto;
using ApiEndPoints.Features.Transmissions.Query.GetAll;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiEndPoints.Features.Transmissions.EndPoints
{
     public class GetAllTransmissions : EndpointBaseAsync.WithoutRequest.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public GetAllTransmissions(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }
          [HttpGet("getAllTransmissions")]
          public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               var Transmissions = await _appCache.GetOrAddAsync("AllTransmissions.Get", () => _mediator.Send(new GetAllTransmissionQuery(),cancellationToken), DateTime.Now.AddHours(4));
               if (Transmissions.IsNullOrEmpty())
               {
                    return NotFound();
               }
               return Ok(Transmissions);
          }
     }
}
