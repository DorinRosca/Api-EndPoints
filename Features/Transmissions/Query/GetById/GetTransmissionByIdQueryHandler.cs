using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Transmissions.Dto;
using MediatR;

namespace ApiEndPoints.Features.Transmissions.Query.GetById
{
    public class GetTransmissionByIdQueryHandler : IRequestHandler<GetTransmissionByIdQuery, TransmissionDto>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetTransmissionByIdQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TransmissionDto> Handle(GetTransmissionByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.TransmissionId == 0)
            {
                throw new ArgumentNullException(nameof(request.TransmissionId), "The Id parameter cannot be zero.");

            }

            var entity = await _context.Transmission.FindAsync(request.TransmissionId);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(request.TransmissionId), "There is no entity with such Id.");

            }

            var model = _mapper.Map<TransmissionDto>(entity);
            return model;
        }
    }
}
