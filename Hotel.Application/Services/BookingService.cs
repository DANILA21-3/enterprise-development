using Hotel.Application.Interfaces;
using Hotel.Application.Mapping;
using Hotel.Contracts.DTO;
using Hotel.Contracts.Request;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;

namespace Hotel.Application.Services;

public class BookingService(
    IRepository<Booking> repository,
    IRepository<Client> clientRepository,
    IRepository<Room> roomRepository)
    : CrudService<Booking, BookingRequest, BookingDto>(repository), IBookingService
{
    protected override async Task<Booking> BuildEntityAsync(BookingRequest request, int id)
    {
        var client = await clientRepository.GetByIdAsync(request.ClientId!.Value);
        if (client == null) throw new KeyNotFoundException($"Клиент(Id={request.ClientId}) не найден");

        var room = await roomRepository.GetByIdAsync(request.RoomId!.Value);
        if (room == null) throw new KeyNotFoundException($"Комната(Id={request.RoomId}) не найдена");

        return new Booking
        {
            Id = id,
            DateArrival = request.DateArrival!.Value,
            DayCount = request.DayCount!.Value,
            Client = client,
            Room = room
        };
    }

    protected override void CopyValues(Booking source, Booking target)
    {
        target.DateArrival = source.DateArrival;
        target.DayCount = source.DayCount;
        target.Client = source.Client;
        target.Room = source.Room;
    }

    protected override BookingDto ToDto(Booking entity) => entity.ToDto();
}