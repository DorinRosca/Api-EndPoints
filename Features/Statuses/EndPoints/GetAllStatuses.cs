using ApiEndPoints.Features.Statuses.Dto;
using ApiEndPoints.Features.Statuses.Query.GetAll;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiEndPoints.Features.Statuses.EndPoints
{
     public class GetAllStatuses : EndpointBaseAsync.WithoutRequest.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public GetAllStatuses(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }
          [HttpGet("getAllStatuses")]
          public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               var Statuses = await _appCache.GetOrAddAsync("AllStatuses.Get", () => _mediator.Send(new GetAllStatusQuery(),cancellationToken), DateTime.Now.AddHours(4));
               if (Statuses.IsNullOrEmpty())
               {
                    return NotFound();
               }
               return Ok(Statuses);
          }
     }
}
