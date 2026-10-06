using Hotel.Domain.Entities;
using Hotel.Domain.Enums;
using Xunit;

namespace Hotel.Tests;

/// <summary>
/// Юнит-тесты по заданным сущностям
/// </summary>
public class HotelTests( HotelFixture fixture ) : IClassFixture <HotelFixture>
{
    /// <summary>
    /// Информация о клиентах, проживающих в номерах указанного типа
    /// </summary>
    [Fact]
	public void FindClientByTypeRoom()
	{
        // Id указанного типа комнаты
        var SelectedTypeRoomId = 4;
        
        // Ожидаемый результат
        string[] CheckResult =
        [
            "5 Киркоров Филипп Бедросович 30.04.1967 4932 104581 РФ",
            "9 Yoon Suk-Yeol 18.12.1960 M48129384 KR"
        ];

        var Result = fixture.Bookings
            .Where(booking => booking.Room.RoomType.Id == SelectedTypeRoomId)
            .Select(booking => booking.Client)
            .DistinctBy(client => client.Id)
            .OrderBy(client => client.Id)
            .ThenBy(client => client.LastName)
            .ThenBy(client => client.FirstName)
            .ThenBy(client => client.Patronymic)
            .Select(client => $"{client.Id} {client.LastName} {client.FirstName}" +
                              (string.IsNullOrEmpty(client.Patronymic) ? "" : $" {client.Patronymic}") +
                              $" {client.BirthDate:dd.MM.yyyy} {client.NumberPassport} {client.Citizenship}")
            .ToList();

        Assert.Equal(CheckResult, Result);
    }

    /// <summary>
    /// Информация о забронированных номерах
    /// </summary>
    [Fact]
    public void RoomBooked()
    {
        // Заданное время для теста
        var CurrentDay = new DateTime(2019, 04, 13);

        // Ожидаемый результат
        string[] CheckResult = 
        [
            "4 1 Нет economy 10 1 Нет 2700",
            "6 1 Нет standart 15 1 Нет 4000"
        ];

        var NumberRooms = fixture.Bookings
            .Where(booking => booking.DateArrival <= CurrentDay && booking.DateArrival.AddDays(booking.DayCount) >= CurrentDay)
            .Select(booking => 
                $"{booking.Room.Number} {booking.Room.Floor} " +$"{(booking.Room.HasBalcony ? "Да" : "Нет")} " +
                $"{booking.Room.RoomType.Category} {booking.Room.RoomType.RoomArea} " +     
                $"{booking.Room.RoomType.BedCount} " +
                $"{(booking.Room.RoomType.HasBathroom ? "Да" : "Нет")} " +        
                $"{booking.Room.RoomType.Price}")
            .Distinct()
            .OrderBy(number => number)
            .ToList();
        
        Assert.Equal(CheckResult, NumberRooms);
    }

    /// <summary>
    /// Топ 5 наиболее часто бронируемых номеров
    /// </summary>
    [Fact]
    public void Top5MostFrequentlyBookedRooms()
    {
        // Ожидаемый результат
        int[] CheckResultNumber = [18, 3, 6, 7, 1];

        var NumberRooms = fixture.Bookings
            .GroupBy(booking => booking.Room.Number)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key)
            .Take(5)
            .Select(group => group.Key)
            .ToList();

        Assert.Equal(CheckResultNumber, NumberRooms);
    }

    /// <summary>
    /// Число бронирований для каждого номера
    /// </summary>
    [Fact]
    public void CountBookingsForEachRoom()
    {
        // Ожидаемый результат
        int[] CheckResult = [1, 2, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 3];

        var Result = fixture.Bookings
            .GroupBy(booking => booking.Room.Number)
            .OrderBy(group => group.Key)
            .Select(group => group.Count())
            .ToList();

        Assert.Equal(CheckResult, Result);
    }

    /// <summary>
    /// Топ 5 клиентов по суммарной стоимости проживания
    /// </summary>
    [Fact]
    public void Top5ClientsByTotalStay()
    {
        // Ожидаемый результат
        int[] CheckResultId = [9, 1, 8, 3, 0];

        var ResultId = fixture.Bookings
            .GroupBy(booking => booking.Client.Id)
            .OrderByDescending(group => group.Sum(booking => booking.DayCount * booking.Room.RoomType.Price))
            .ThenBy(group => group.Key)
            .Take(5)
            .Select(group => group.Key)
            .ToList();

        Assert.Equal(CheckResultId, ResultId);
    }
}
