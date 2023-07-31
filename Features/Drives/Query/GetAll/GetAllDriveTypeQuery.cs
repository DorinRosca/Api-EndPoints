using ApiEndPoints.Features.Drives.Dto;
using MediatR;

namespace ApiEndPoints.Features.Drives.Query.GetAll
{
    public class GetAllDriveQuery : IRequest<IEnumerable<DriveDto>>
    {
    }
}
