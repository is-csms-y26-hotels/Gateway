using Gateway.Application.Contracts.Dto.Rooms;
using Gateway.Application.Contracts.GrpcClients;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;

[ApiController]
[Route("api/room")]
public class RoomController : ControllerBase
{
    private readonly IGrpcRoomClient _roomClient;

    public RoomController(IGrpcRoomClient roomClient)
    {
        _roomClient = roomClient;
    }

    /// <summary>
    /// Adds a new room.
    /// </summary>
    /// <response code="200">Room added</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateRoom(
        [FromQuery] long hotelId,
        [FromQuery] long roomNumber,
        [FromQuery] RoomType roomType,
        [FromQuery] decimal price,
        CancellationToken cancellationToken)
    {
        await _roomClient.CreateRoomAsync(hotelId, roomNumber, roomType, price, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Updates room price.
    /// </summary>
    /// <response code="200">Room price changed</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateRoom(
        [FromQuery] long roomId,
        [FromQuery] decimal price,
        CancellationToken cancellationToken)
    {
        await _roomClient.UpdateRoomPriceAsync(roomId, price, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Soft delete room.
    /// </summary>
    /// <response code="200">Room deleted</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteRoom(
        [FromQuery] long roomId,
        CancellationToken cancellationToken)
    {
        await _roomClient.SoftDeleteRoomAsync(roomId, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Gets a rooms list by hotel and room type.
    /// </summary>
    /// <returns>Rooms list</returns>
    /// <response code="200">Returns Rooms list </response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpGet("get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRoom(
        [FromQuery] long hotelId,
        [FromQuery] RoomType roomType,
        [FromQuery] long cursor,
        [FromQuery] int pageSize,
        CancellationToken cancellationToken)
    {
        System.Collections.ObjectModel.Collection<RoomDto> result = await _roomClient.GetRoomsByHotelIdAsync(hotelId, roomType, cursor, pageSize, cancellationToken);
        return Ok(result);
    }
}