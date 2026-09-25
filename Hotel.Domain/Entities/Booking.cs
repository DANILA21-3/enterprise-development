namespace Hotel.Domain;

public class Booking
{
	public required int Id { get; set; }

	public required DateOnly DateArrival { get; set; }
	public required int DayCount { get; set; }

}
