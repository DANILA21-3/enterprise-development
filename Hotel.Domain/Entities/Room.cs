/// <summary>
/// 
/// </summary>
public class HotelRoom
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Номер гостиничной комнаты
    /// </summary>
    public required int HotelRoomNumber { get; set; }

    /// <summary>
    /// Этаж комнаты
    /// </summary>
    public required int HotelRoomFloor { get; set; }

    /// <summary>
    /// Наличие балкона
    /// </summary>
    public required bool HasBalcony { get; set; }

    /// <summary>
    /// Тип гостиничного номера
    /// </summary>
    public required int HotelRoomType { get; set; }

}
