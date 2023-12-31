﻿using ApiEndPoints.Features.Brands.Command.Create;
using ApiEndPoints.Features.Brands.Dto;
using Ardalis.ApiEndpoints;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndPoints.Features.Brands.EndPoints
{
     public class CreateBrand: EndpointBaseAsync.WithRequest<BrandDto>.WithResult<IActionResult>
     {
          private readonly IMediator _mediator;
          private readonly IAppCache _appCache;

          public CreateBrand(IMediator mediator, IAppCache cache)
          {
               _mediator = mediator;
               _appCache=cache;
          }
          [HttpPost("addBrand")]
          public override async Task<IActionResult> HandleAsync(BrandDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new CreateBrandCommand(request),cancellationToken);
               _appCache.Remove("AllBrands.Get");
               return Ok(result);
          }
     }
}
