using ApiEndPoints.Features.Brands.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ApiEndPoints.Features.Brands.Command.Edit
{
    public record  EditBrandCommand(BrandDto Model) : IRequest<bool>
    {
        public int BrandId = Model.BrandId;
        [Required, StringLength(50)]
        public string BrandName = Model.BrandName;

    }
}
