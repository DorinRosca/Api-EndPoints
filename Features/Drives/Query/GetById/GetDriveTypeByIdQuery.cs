using ApiEndPoints.Features.Drives.Dto;
using MediatR;

namespace ApiEndPoints.Features.Drives.Query.GetById
{
    public class GetDriveByIdQuery : IRequest<DriveDto>
    {
        public byte DriveId { get; set; }

        public GetDriveByIdQuery(byte Id)
        {
            DriveId = Id;
        }
    }
}
