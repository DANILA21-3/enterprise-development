using Hotel.Application.Interfaces;
using Hotel.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IRoomTypeService, RoomTypeService>();
        services.AddScoped<IRoomService, RoomService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IAnalyticsService, AnalyticsService>();

        return services;
    }
}