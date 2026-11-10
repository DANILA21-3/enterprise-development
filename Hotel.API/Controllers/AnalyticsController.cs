using Hotel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController(IAnalyticsService service) : ControllerBase
{
    [HttpGet("clients-by-room-type/{roomTypeId:int}")]
    public async Task<IActionResult> GetClientsByRoomType(int roomTypeId) => Ok(await service.GetClientsByRoomTypeAsync(roomTypeId));

    [HttpGet("booked-rooms")]
    public async Task<IActionResult> GetBookedRooms([FromQuery] DateTime date) => Ok(await service.GetBookedRoomsAsync(date));

    [HttpGet("top5-booked-rooms")]
    public async Task<IActionResult> GetTop5() => Ok(await service.GetTop5BookedRoomsAsync());

    [HttpGet("bookings-count")]
    public async Task<IActionResult> GetCount() => Ok(await service.GetBookingsCountPerRoomAsync());

    [HttpGet("top5-clients")]
    public async Task<IActionResult> GetTop5Clients() => Ok(await service.GetTop5ClientsByStayAsync());
}