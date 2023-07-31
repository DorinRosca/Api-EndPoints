using AutoMapper;
using ApiEndPoints.Data;
using ApiEndPoints.Features.Transmissions.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiEndPoints.Features.Transmissions.Query.GetAll
{
    public class GetAllTransmissionQueryHandler : IRequestHandler<GetAllTransmissionQuery, IEnumerable<TransmissionDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllTransmissionQueryHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransmissionDto>> Handle(GetAllTransmissionQuery request, CancellationToken cancellationToken)
        {
            var dataList = await _context.Transmission.ToListAsync(cancellationToken);
            var result = dataList.Select(entity => _mapper.Map<TransmissionDto>(entity));
            return result;
        }
    }
}
