using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Statuses.Dto;
using MediatR;

namespace ApiEndPoints.Features.Statuses.Query.GetById
{
    public class GetStatusByIdQueryHandler : IRequestHandler<GetStatusByIdQuery, StatusDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetStatusByIdQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StatusDto> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.StatusId == 0)
            {
                throw new ArgumentNullException(nameof(request.StatusId), "The Id parameter cannot be zero.");

            }

            var entity = await _context.Status.FindAsync(request.StatusId);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(request.StatusId), "There is no entity with such Id.");

            }

            var model = _mapper.Map<StatusDto>(entity);
            return model;
        }
    }
}
