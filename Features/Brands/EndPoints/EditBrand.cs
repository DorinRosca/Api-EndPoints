using ApiEndPoints.Features.Brands.Command.Edit;
using ApiEndPoints.Features.Brands.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Brands.EndPoints
{
     public class EditBrand : EndpointBaseAsync.WithRequest<BrandDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public EditBrand(IAppCache appCache, IMediator mediator)
          {
               _appCache = appCache;
               _mediator = mediator;
          }
          [HttpPut("edit/{id}")]

          public override async Task<IActionResult> HandleAsync(BrandDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new EditBrandCommand(request),cancellationToken);
               if (result)
               {
                    _appCache.Remove("AllBrands.Get");
                    _appCache.Remove("BrandById.Get: "+ request.BrandId);
                    return Ok(result);

               }
               return Problem();
          }
     }
}
