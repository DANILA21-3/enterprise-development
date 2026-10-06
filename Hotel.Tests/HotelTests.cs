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
        var selectedTypeRoomId = 4;
        
        // Ожидаемый результат
        string[] checkResult =
        [
            "6 Киркоров Филипп Бедросович 30.04.1967 4932 104581 РФ",
            "10 Yoon Suk-Yeol 18.12.1960 M48129384 KR"
        ];

        var result = fixture.Bookings
            .Where(booking => booking.Room.RoomType.Id == selectedTypeRoomId)
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

        Assert.Equal(checkResult, result);
    }

    /// <summary>
    /// Информация о забронированных номерах
    /// </summary>
    [Fact]
    public void RoomBooked()
    {
        // Заданное время для теста
        var currentDay = new DateTime(2019, 04, 13);

        // Ожидаемый результат
        string[] checkResult = 
        [
            "4 1 Нет Economy 10 1 Нет 2700",
            "6 1 Нет Standart 15 1 Нет 4000"
        ];

        var numberRooms = fixture.Bookings
            .Where(booking => booking.DateArrival <= currentDay && booking.DateArrival.AddDays(booking.DayCount) >= currentDay)
            .Select(booking => 
                $"{booking.Room.Number} {booking.Room.Floor} " +$"{(booking.Room.HasBalcony ? "Да" : "Нет")} " +
                $"{booking.Room.RoomType.Category} {booking.Room.RoomType.RoomArea} " +     
                $"{booking.Room.RoomType.BedCount} " +
                $"{(booking.Room.RoomType.HasBathroom ? "Да" : "Нет")} " +        
                $"{booking.Room.RoomType.Price}")
            .Distinct()
            .OrderBy(number => number)
            .ToList();
        
        Assert.Equal(checkResult, numberRooms);
    }

    /// <summary>
    /// Топ 5 наиболее часто бронируемых номеров
    /// </summary>
    [Fact]
    public void Top5MostFrequentlyBookedRooms()
    {
        // Ожидаемый результат
        int[] checkResultNumber = [18, 3, 6, 7, 1];

        var numberRooms = fixture.Bookings
            .GroupBy(booking => booking.Room.Number)
            .OrderByDescending(group => group.Count())
            .ThenBy(group => group.Key)
            .Take(5)
            .Select(group => group.Key)
            .ToList();

        Assert.Equal(checkResultNumber, numberRooms);
    }

    /// <summary>
    /// Число бронирований для каждого номера
    /// </summary>
    [Fact]
    public void CountBookingsForEachRoom()
    {
        // Ожидаемый результат
        int[] checkResult = [1, 2, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 3];

        var result = fixture.Bookings
            .GroupBy(booking => booking.Room.Number)
            .OrderBy(group => group.Key)
            .Select(group => group.Count())
            .ToList();

        Assert.Equal(checkResult, result);
    }

    /// <summary>
    /// Топ 5 клиентов по суммарной стоимости проживания
    /// </summary>
    [Fact]
    public void Top5ClientsByTotalStay()
    {
        // Ожидаемый результат
        int[] checkResultId = [10, 2, 9, 4, 1];

        var resultId = fixture.Bookings
            .GroupBy(booking => booking.Client.Id)
            .OrderByDescending(group => group.Sum(booking => booking.DayCount * booking.Room.RoomType.Price))
            .ThenBy(group => group.Key)
            .Take(5)
            .Select(group => group.Key)
            .ToList();

        Assert.Equal(checkResultId, resultId);
    }
}
