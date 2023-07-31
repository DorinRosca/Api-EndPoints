using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Drives.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Drives.Query.GetAll
{
    public class GetAllDriveQueryHandler : IRequestHandler<GetAllDriveQuery, IEnumerable<DriveDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllDriveQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DriveDto>> Handle(GetAllDriveQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _context.Drive.ToListAsync(cancellationToken);
            var result = dataList.Select(entity => _mapper.Map<DriveDto>(entity));
            return result;
        }
    }
}
