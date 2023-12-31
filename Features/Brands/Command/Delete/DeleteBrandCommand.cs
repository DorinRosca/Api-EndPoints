﻿using MediatR;

namespace ApiEndPoints.Features.Brands.Command.Delete
{
    public record DeleteBrandCommand(byte brandId) : IRequest<bool>
    {

        public byte BrandId =brandId;

    }
}
