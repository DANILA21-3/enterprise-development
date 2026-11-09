using System.ComponentModel.DataAnnotations;

namespace Hotel.Contracts.Request;

/// <summary>
/// Обработка запросов на создание сущностей
/// </summary>
public sealed class BookingRequest
{
    [Required]
    public DateTime? DateArrival { get; init; }

    [Required, Range(1, 3650)]
    public int? DayCount { get; init; }

    [Required, Range(1, int.MaxValue)]
    public int? ClientId { get; init; }

    [Required, Range(1, int.MaxValue)]
    public int? RoomId { get; init; }
}