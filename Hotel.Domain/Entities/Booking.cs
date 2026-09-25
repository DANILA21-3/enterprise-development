namespace Hotel.Domain;

/// <summary>
/// Бронирование клиентов гостиницы
/// </summary>
public class Booking
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public required int Id { get; set; }

	/// <summary>
	/// Дата заселения
	/// </summary>
	public required DateOnly DateArrival { get; set; }

	/// <summary>
	/// Количество дней проживания клиента
	/// </summary>
	public required int DayCount { get; set; }

}
