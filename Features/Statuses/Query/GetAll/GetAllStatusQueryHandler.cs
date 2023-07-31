using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Statuses.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Statuses.Query.GetAll
{
    public class GetAllStatusQueryHandler : IRequestHandler<GetAllStatusQuery, IEnumerable<StatusDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllStatusQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatusDto>> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _context.Status.ToListAsync(cancellationToken);
            var result = dataList.Select(entity => _mapper.Map<StatusDto>(entity));
            return result;
        }
    }
}
