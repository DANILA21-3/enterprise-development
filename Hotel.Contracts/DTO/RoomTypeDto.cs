using Hotel.Domain.Enums;

namespace Hotel.Contracts.DTO;

public sealed record RoomTypeDto(
    int Id,
    RoomCategory Category,
    int RoomArea,
    int BedCount,
    bool HasBathroom,
    int Price);