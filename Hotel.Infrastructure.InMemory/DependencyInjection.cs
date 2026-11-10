using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Infrastructure.InMemory;

public static class DependencyInjection
{
    public static IServiceCollection AddInMemoryInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<HotelSession>();

        services.AddSingleton<IRepository<Client>>(sp => sp.GetRequiredService<HotelSession>().Clients);
        services.AddSingleton<IRepository<Room>>(sp => sp.GetRequiredService<HotelSession>().Rooms);
        services.AddSingleton<IRepository<RoomType>>(sp => sp.GetRequiredService<HotelSession>().RoomTypes);
        services.AddSingleton<IRepository<Booking>>(sp => sp.GetRequiredService<HotelSession>().Bookings);

        return services;
    }
}