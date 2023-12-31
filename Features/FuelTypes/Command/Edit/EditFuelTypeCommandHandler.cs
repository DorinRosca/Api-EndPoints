﻿using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.FuelTypes.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.FuelTypes.Command.Edit
{
    public class EditFuelTypeCommandHandler : IRequestHandler<EditFuelTypeCommand, bool>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EditFuelTypeCommandHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Handle(EditFuelTypeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "The model parameter cannot be null.");
            }

            var entity = _mapper.Map<FuelType>(request);
            _context.Entry(entity).State = EntityState.Modified;

            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
