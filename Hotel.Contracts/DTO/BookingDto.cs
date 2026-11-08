namespace Hotel.Contracts.DTO;

public sealed record BookingDto(
    int Id,
    DateTime DateArrivial,
    int DayCount,
    ClientDto Client,
    RoomDto Room);
