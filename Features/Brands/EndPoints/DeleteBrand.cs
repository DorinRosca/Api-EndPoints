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

          public DeleteBrand(IMediator mediator)
          {
               _mediator = mediator;
          }
          [HttpDelete("deleteBrand/{id}")]
          public override async Task<IActionResult> HandleAsync(byte id, CancellationToken cancellationToken = new CancellationToken())
          {
               var result = await _mediator.Send(new DeleteBrandCommand(id),cancellationToken);
               if (result)
               {

                    return Ok(result);
               }
               return Problem();
          }
     }
}
