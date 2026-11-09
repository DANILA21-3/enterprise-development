using Hotel.Application.Interfaces;
using Hotel.Contracts.DTO;
using Hotel.Contracts.Request;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;

namespace Hotel.Application.Services;

public class RoomTypeService(IRepository<RoomType> repository)
    : CrudService<RoomType, RoomTypeRequest, RoomTypeDto>(repository), IRoomTypeService
{
    protected override Task<RoomType> BuildEntityAsync(RoomTypeRequest request, int id) =>
        Task.FromResult(new RoomType
        {
            Id = id,
            Category = request.Category!.Value,
            RoomArea = request.RoomArea!.Value,
            BedCount = request.BedCount!.Value,
            HasBathroom = request.HasBathroom!.Value,
            Price = request.Price!.Value
        });

    protected override void CopyValues(RoomType source, RoomType target)
    {
        target.Category = source.Category;
        target.RoomArea = source.RoomArea;
        target.BedCount = source.BedCount;
        target.HasBathroom = source.HasBathroom;
        target.Price = source.Price;
    }

    protected override RoomTypeDto ToDto(RoomType entity) => entity.ToDto();
}