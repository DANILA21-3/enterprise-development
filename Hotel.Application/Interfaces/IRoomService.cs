using Hotel.Contracts.DTO;
using Hotel.Contracts.Request;

namespace Hotel.Application.Interfaces;

public interface IRoomService : ICrudService<RoomRequest, RoomDto>
{
}