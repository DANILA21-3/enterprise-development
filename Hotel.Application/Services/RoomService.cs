using Hotel.Application.Interfaces;
using Hotel.Application.Mapping;
using Hotel.Contracts.DTO;
using Hotel.Contracts.Request;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;

namespace Hotel.Application.Services;

public class RoomService(IRepository<Room> repository, IRepository<RoomType> roomTypeRepository)
    : CrudService<Room, RoomRequest, RoomDto>(repository), IRoomService
{
    protected override async Task<Room> BuildEntityAsync(RoomRequest request, int id)
    {
        var roomType = await roomTypeRepository.GetByIdAsync(request.RoomTypeId!.Value);
        if (roomType == null) throw new KeyNotFoundException($"Тип комнаты(Id={request.RoomTypeId}) не найден");

        return new Room
        {
            Id = id,
            Number = request.Number!.Value,
            Floor = request.Floor!.Value,
            HasBalcony = request.HasBalcony!.Value,
            RoomType = roomType
        };
    }

    protected override void CopyValues(Room source, Room target)
    {
        target.Number = source.Number;
        target.Floor = source.Floor;
        target.HasBalcony = source.HasBalcony;
        target.RoomType = source.RoomType;
    }

    protected override RoomDto ToDto(Room entity) => entity.ToDto();
}