using Hotel.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Contracts.Request;

/// <summary>
/// Обработка запросов на создание сущностей
/// </summary>
public sealed class RoomTypeRequest
{
    [Required]
    public RoomCategory? Category { get; init; }

    [Required, Range(1, 1000)]
    public int? RoomArea { get; init; }

    [Required, Range(1, 20)]
    public int? BedCount { get; init; }

    [Required]
    public bool? HasBathroom { get; init; }

    [Required, Range(1, 10_000_000)]
    public int? Price { get; init; }
}