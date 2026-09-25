using Hotel.Domain.Enums;


public class RoomType
{
    public required int Id { get; set; }

    public required RoomCategory Category { get; set; }

    public required int RoomArea { get; set; }
    public required int BedCount {  get; set; }
    public required bool SetBathroom { get; set; }

    public required int HasBathroom { get; }

}
