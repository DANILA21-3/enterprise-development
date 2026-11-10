using Hotel.Application.Interfaces;
using Hotel.Application.Mapping;
using Hotel.Contracts.DTO;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;

namespace Hotel.Application.Services;

public class AnalyticsService(IRepository<Booking> bookingRepository) : IAnalyticsService
{
    public async Task<IReadOnlyList<ClientDto>> GetClientsByRoomTypeAsync(int roomTypeId)
    {
        var bookings = await bookingRepository.GetAllAsync();
        return bookings
            .Where(b => b.Room.RoomType.Id == roomTypeId)
            .Select(b => b.Client)
            .DistinctBy(c => c.Id)
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ThenBy(c => c.Patronymic)
            .Select(c => c.ToDto())
            .ToList();
    }

    public async Task<IReadOnlyList<int>> GetBookedRoomsAsync(DateTime date)
    {
        var bookings = await bookingRepository.GetAllAsync();
        return bookings
            .Where(b => b.DateArrival <= date && b.DateArrival.AddDays(b.DayCount) >= date)
            .Select(b => b.Room.Number)
            .Distinct()
            .OrderBy(n => n)
            .ToList();
    }

    public async Task<IReadOnlyList<int>> GetTop5BookedRoomsAsync()
    {
        var bookings = await bookingRepository.GetAllAsync();
        return bookings
            .GroupBy(b => b.Room.Number)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .Take(5)
            .Select(g => g.Key)
            .ToList();
    }

    public async Task<IReadOnlyList<WorkFrequencyDto>> GetBookingsCountPerRoomAsync()
    {
        var bookings = await bookingRepository.GetAllAsync();
        return bookings
            .GroupBy(b => b.Room.Number)
            .OrderBy(g => g.Key)
            .Select(g => new WorkFrequencyDto(g.Key, g.Count()))
            .ToList();
    }

    public async Task<IReadOnlyList<RepeatVisitDto>> GetTop5ClientsByStayAsync()
    {
        var bookings = await bookingRepository.GetAllAsync();
        return bookings
            .GroupBy(b => b.Client.Id)
            .OrderByDescending(g => g.Sum(b => b.DayCount * b.Room.RoomType.Price))
            .ThenBy(g => g.Key)
            .Take(5)
            .Select(g => new RepeatVisitDto(g.Key, g.Sum(b => b.DayCount * b.Room.RoomType.Price)))
            .ToList();
    }
}