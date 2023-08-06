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

          public EditBrand(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpPut("editBrand/{id}")]

          public override async Task<IActionResult> HandleAsync(BrandDto request, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new EditBrandCommand(request), cancellationToken);
               if (result)
               {
                    return Ok(result);

               }
               return Problem();
          }
     }
}
