using Hotel.Contracts.DTO;

namespace Hotel.Application.Interfaces;

public interface IAnalyticsService
{
    public Task<IReadOnlyList<ClientDto>> GetClientsByRoomTypeAsync(int roomTypeId);
    public Task<IReadOnlyList<int>> GetBookedRoomsAsync(DateTime date);
    public Task<IReadOnlyList<int>> GetTop5BookedRoomsAsync();
    public Task<IReadOnlyList<WorkFrequencyDto>> GetBookingsCountPerRoomAsync();
    public Task<IReadOnlyList<RepeatVisitDto>> GetTop5ClientsByStayAsync();
}