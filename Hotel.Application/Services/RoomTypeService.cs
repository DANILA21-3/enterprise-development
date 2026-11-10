using Hotel.Application.Interfaces;
using Hotel.Application.Mapping;
using Hotel.Contracts.DTO;
using Hotel.Contracts.Request;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;

namespace Hotel.Application.Services;

/// <summary>
/// Сервис для управления типами комнат
/// </summary>
public class RoomTypeService(IRepository<RoomType> repository)
    : CrudService<RoomType, RoomTypeRequest, RoomTypeDto>(repository), IRoomTypeService
{
    /// <summary>
    /// Создание сущности типа комнаты из запроса
    /// </summary>
    protected override Task<RoomType> BuildEntityAsync(RoomTypeRequest request, int id)
    {
        return Task.FromResult(new RoomType
        {
            Id = id,
            Category = request.Category!.Value,
            RoomArea = request.RoomArea!.Value,
            BedCount = request.BedCount!.Value,
            HasBathroom = request.HasBathroom!.Value,
            Price = request.Price!.Value
        });
    }

    /// <summary>
    /// Копирование обновленных значений в существующую сущность типа комнаты
    /// </summary>
    protected override void CopyValues(RoomType source, RoomType target)
    {
        target.Category = source.Category;
        target.RoomArea = source.RoomArea;
        target.BedCount = source.BedCount;
        target.HasBathroom = source.HasBathroom;
        target.Price = source.Price;
    }

    /// <summary>
    /// Преобразование сущности типа комнаты в DTO
    /// </summary>
    protected override RoomTypeDto ToDto(RoomType entity) => entity.ToDto();
}