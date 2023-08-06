using ApiEndPoints.Features.Drives.Dto;
using ApiEndPoints.Features.Drives.Query.GetAll;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiEndPoints.Features.Drives.EndPoints
{
     public class GetAllDrives : EndpointBaseAsync.WithoutRequest.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public GetAllDrives(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }
          [HttpGet("getAllDrives")]
          public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
          {
               var Drives = await _appCache.GetOrAddAsync("AllDrives.Get", () => _mediator.Send(new GetAllDriveQuery(),cancellationToken), DateTime.Now.AddHours(4));
               if (Drives.IsNullOrEmpty())
               {
                    return NotFound();
               }
               return Ok(Drives);
          }
     }
}
