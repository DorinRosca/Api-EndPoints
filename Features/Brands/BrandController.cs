using ApiEndPoints.Features.Brands.Command.Create;
using ApiEndPoints.Features.Brands.Command.Delete;
using ApiEndPoints.Features.Brands.Command.Edit;
using ApiEndPoints.Features.Brands.Query.GetAll;
using ApiEndPoints.Features.Brands.Query.GetById;
using ApiEndPoints.Features.Brands.Dto;
using LazyCache;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiEndPoints.Features.Brands
{
     [ApiController]
     [Route("[controller]")]
     public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAppCache _appCache;

        public BrandController(IMediator mediator, IAppCache appCache)
        {
             _mediator = mediator;
             _appCache = appCache;
        }
          [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _appCache.GetOrAddAsync("AllBrands.Get", () => _mediator.Send(new GetAllBrandQuery()));
            if (brands.IsNullOrEmpty())
            {
                 return NotFound();
            }
            return Ok(brands);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody]BrandDto model)
        {
             _appCache.Remove("AllBrands.Get");
             var result = _mediator.Send(new CreateBrandCommand(model)).Result;
                return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
                var result = _mediator.Send(new DeleteBrandCommand(id)).Result;
                if (result)
                {
                     _appCache.Remove("AllBrands.Get");
                     _appCache.Remove("BrandById.Get: "+ id);

                         return Ok(result);
                } 
                return Problem();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit([FromBody]BrandDto model)
        {
             var result = await _mediator.Send(new EditBrandCommand(model));
            if (result)
            {
                 _appCache.Remove("AllBrands.Get");
                 _appCache.Remove("BrandById.Get: "+ model.BrandId);
                 return Problem();

             }
             return Problem();
        }
    }
}
