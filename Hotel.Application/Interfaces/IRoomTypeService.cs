using Hotel.Contracts.DTO;
using Hotel.Contracts.Request;

namespace Hotel.Application.Interfaces;

public interface IRoomTypeService : ICrudService<RoomTypeRequest, RoomTypeDto>
{
}