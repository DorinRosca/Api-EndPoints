using ApiEndPoints.Features.Brands.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Brands.Command.Create
{
    public record CreateBrandCommand(BrandDto model) : IRequest<bool>
    {
         [Required, StringLength(50)] 
          public string BrandName = model.BrandName;

    }
}
