using Hotel.Domain.Enums;

/// <summary>
/// Тип гостиничного номера
/// </summary>
public class HotelRoomType
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Категория гостиничного номера
    /// </summary>
    public required HotelRoomCategory Category { get; set; }

    /// <summary>
    /// Площадь гостиничного номера
    /// </summary>
    public required int HotelRoomArea { get; set; }

    /// <summary>
    /// Количество кроватей
    /// </summary>
    public required int BedCount {  get; set; }

    /// <summary>
    /// Наличие ванны/душа
    /// </summary>
    public required bool HasBathroom { get; set; }

}
