using ApiEndPoints.Features.Brands.Command.Delete;
using ApiEndPoints.Features.Brands.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Brands.EndPoints
{
     public class DeleteBrand : EndpointBaseAsync.WithRequest<byte>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public DeleteBrand(IMediator mediator, IAppCache appCache)
          {
               _mediator = mediator;
               _appCache = appCache;
          }
          [HttpDelete("delete/{id}")]
          public override async Task<IActionResult> HandleAsync(byte id, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = _mediator.Send(new DeleteBrandCommand(id),cancellationToken).Result;
               if (result)
               {
                    _appCache.Remove("AllBrands.Get");
                    _appCache.Remove("BrandById.Get: "+ id);

                    return Ok(result);
               }
               return Problem();
          }
     }
}
