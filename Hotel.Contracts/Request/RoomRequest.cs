using System.ComponentModel.DataAnnotations;

namespace Hotel.Contracts.Request;

/// <summary>
/// Обработка запросов на создание сущностей
/// </summary>
public sealed class RoomRequest
{
    [Required, Range(1, 10000)]
    public int? Number { get; init; }

    [Required, Range(-5, 200)]
    public int? Floor { get; init; }

    [Required]
    public bool? HasBalcony { get; init; }

    [Required, Range(1, int.MaxValue)]
    public int? RoomTypeId { get; init; }
}