using ApiEndPoints.Features.Brands.Command.Create;
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

          public CreateBrand(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPost("add")]
          public override async Task<IActionResult> HandleAsync(BrandDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = _mediator.Send(new CreateBrandCommand(request),cancellationToken).Result;
               return Ok(result);
          }
     }
}
