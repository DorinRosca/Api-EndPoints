using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Drives.Dto;
using MediatR;

namespace ApiEndPoints.Features.Drives.Query.GetById
{
    public class GetDriveByIdQueryHandler : IRequestHandler<GetDriveByIdQuery, DriveDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetDriveByIdQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DriveDto> Handle(GetDriveByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.DriveId == 0)
            {
                throw new ArgumentNullException(nameof(request.DriveId), "The Id parameter cannot be zero.");

            }

            var entity = await _context.Drive.FindAsync(request.DriveId);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(request.DriveId), "There is no entity with such Id.");

            }

            var model = _mapper.Map<DriveDto>(entity);
            return model;
        }
    }
}
