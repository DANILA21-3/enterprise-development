namespace Hotel.Contracts.DTO;

/// <summary>
/// Dto для передачи информации о бронировании
/// </summary>
/// <param name="Id">Id бронирования</param>
/// <param name="DateArrivial">Дата заселения</param>
/// <param name="DayCount">Количество дней проживания</param>
/// <param name="Client">Клиент</param>
/// <param name="Room">Комната</param>
public sealed record BookingDto(
    int Id,
    DateTime DateArrivial,
    int DayCount,
    ClientDto Client,
    RoomDto Room);
