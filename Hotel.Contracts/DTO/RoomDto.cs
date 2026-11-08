namespace Hotel.Contracts.DTO;

public sealed record RoomDto(
    int Id,
    int Number,
    int Floor,
    bool HasBalcony,
    RoomTypeDto RoomType);