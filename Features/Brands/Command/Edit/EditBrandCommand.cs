using ApiEndPoints.Features.Brands.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Brands.Command.Edit
{
    public record  EditBrandCommand(BrandDto model) : IRequest<bool>
    {
        public int BrandId = model.BrandId;
        [Required, StringLength(50)]
        public string BrandName = model.BrandName;

    }
}
