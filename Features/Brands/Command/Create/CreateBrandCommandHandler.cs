using ApiEndPoints.Data;
using ApiEndPoints.Features.Brands.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Brands.Command.Create
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, bool>
    {
        private readonly DataContext _context;
        public CreateBrandCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var Brand = new Brand
            {
                BrandName = request.BrandName
            };
            await _context.Brand.AddAsync(Brand, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
